using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;
using Game.DAL.Abstract;
using Game.DAL.Concrete;
using Game.Models;

namespace GameTests
{
    public class CharacterRepoTests
    {
        private Mock<GameDbContext> _mockContext;

        private Mock<DbSet<Character>> _mockCharacterDbSet;
        private List<Character>        _characters         = FakeData.Characters;
        private List<CharacterClass>   _characterClass     = FakeData.CharacterClasses;
        private List<Weapon>           _weapons            = FakeData.Weapons;
        private List<Ability>          _abilities          = FakeData.Abilities;
        private List<CharacterAbility> _characterAbilities = FakeData.CharacterAbilities;
        private List<CharacterWeapon>  _characterWeapons   = FakeData.CharacterWeapons;

        // a helper to make dbset queryable
        private Mock<DbSet<T>> GetMockDbSet<T>(IQueryable<T> entities) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(entities.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(entities.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());
            return mockSet;
        }

        [SetUp]
        public void Setup()
        {
            _mockCharacterDbSet = GetMockDbSet(_characters.AsQueryable());
            // fake the Find method (for a single integer value passed in -- a pain since the signature for Find is (params object[] keyValues)
            _mockCharacterDbSet.Setup(a => a.Find(It.IsAny<object[]>())).Returns((object[] x) => {
                int id = (int)x[0];
                return _characters.Where(c => c.Id == id).FirstOrDefault();
            });

            _mockContext = new Mock<GameDbContext>();
            _mockContext.Setup(ctx => ctx.Characters).Returns(_mockCharacterDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Character>()).Returns(_mockCharacterDbSet.Object);
        }

        [Test]
        public void SanityTest()
        {
            Assert.Pass();
        }

        // This method tests the condition that a character has weapons but none of them are duplicates, therefore
        // this returns the correct weapons and they all have a count of 1
        [Test]
        public void CharacterRepo_GetWeaponsInfoForCharacterWithNoDuplicateWeapons_Should_ReturnOnlyCountsOf1()
        {
            // Arrange
            ICharacterRepository characterRepo = new CharacterRepository(_mockContext.Object);
            IEnumerable<WeaponInfo> weaponInfo = characterRepo.GetWeaponsInfo(1).ToList();

            // Act 
            WeaponInfo x = new WeaponInfo();

            foreach(var info in weaponInfo)
            {
                x.Name = info.Name;
                x.Count = info.Count;
            }
            List<WeaponInfo> y = weaponInfo.ToList();
            x.Count = y[0].Count;
            // Assert
            Assert.AreEqual(x.Count, 2);  // until implemented
        }

        // This method tests the condition that a character has weapons and some are duplicates, so rather
        // than reporting them multiple times this method combines them and increases their count, so the list
        // is distinct 
        [Test]
        public void CharacterRepo_GetWeaponsInfoForCharacterWithDuplicateWeapons_Should_ReturnSomeCountsGreaterThan1()
        {
            // Arrange
            ICharacterRepository characterRepo = new CharacterRepository(_mockContext.Object);
            IEnumerable<WeaponInfo> weaponInfo = characterRepo.GetWeaponsInfo(5);

            List<WeaponInfo> y = weaponInfo.ToList();

            // Act 
            WeaponInfo x = new WeaponInfo();

            foreach (var info in weaponInfo)
            {
                x.Name = info.Name;
                x.Count = info.Count;
            }

            x.Count = y[0].Count;
            // Assert
            Assert.AreEqual(x.Count, 3);  // until implemented
        }
    
    }
}