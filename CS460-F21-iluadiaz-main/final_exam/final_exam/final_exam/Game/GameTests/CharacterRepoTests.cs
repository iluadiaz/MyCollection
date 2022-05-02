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
    // A new version of this file containing some test methods will be available just prior to the exam.  Replace this file with that one.

    public class CharacterRepoTests
    {
        private Mock<GameDbContext> _mockContext;

        private Mock<DbSet<Character>> _mockCharacterDbSet;
        private List<Character> _characters = FakeData.Characters;
        private List<CharacterClass> _characterClass = FakeData.CharacterClasses;
        private List<Weapon> _weapons = FakeData.Weapons;
        private List<Ability> _abilities = FakeData.Abilities;
        private List<CharacterAbility> _characterAbilities = FakeData.CharacterAbilities;
        private List<CharacterWeapon> _characterWeapons = FakeData.CharacterWeapons;

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
                return _characters.Where(c => c.Id == id).First();
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

        [Test]
        public void CharacterRepo_GetAbilitiesForCharacterWithSomeAbilities_Should_ReturnOnlyTheirAbilities()
        {
            ICharacterRepository characterRepo = new CharacterRepository(_mockContext.Object);
            IEnumerable<Ability> characterAbilitiesById = characterRepo.GetAbilities(1).ToList();
            IAbilityRepository abilityrepo = new AbilityRepository(_mockContext.Object);


            var expectedList = new List<Character>
            { new Character { Id = 1, Created = DateTime.Parse("2021-12-04 12:15:44"), Level = 3 , Health = 40 , CharacterClassId = 1, Name = "John Wick"}
            };

           
            List<Ability> Abilities = new List<Ability>
        {
            new Ability { Id = 1, Name = "Throw" , Damage = 10, Cooldown = 10},
            new Ability { Id = 8, Name = "Fire"  , Damage = 35, Cooldown = 40}
        };
             List<CharacterAbility> CharacterAbilities = new List<CharacterAbility>
        {
            new CharacterAbility { Id = 1, AssignDate = DateTime.Parse("2021-12-04 13:15:44"),  CharacterId = 1, AbilityId = 1},
            new CharacterAbility { Id = 2, AssignDate = DateTime.Parse("2021-12-04 18:10:04"),  CharacterId = 1, AbilityId = 8},
  
        };

        List<Ability> z = new List<Ability>();

            List<Ability> abilities = characterAbilitiesById.ToList();

            z = abilities.ToList();

            Assert.That(z.Count, Is.EqualTo(2));
            foreach (var a in expectedList)
            {
                Assert.That(z.Any(actual => actual.Id == a.Id));
            }
            foreach (var a in Abilities)
            {
    
                Assert.That(z.Any(actual => actual.Name == a.Name));
            }
        }

        // This method tests the general function of the GetMissingAbilities method.  Use one of the fake characters
        // to show that the correct list of missing abilities is returned.  i.e. if a character has "Fire" and "Poison"
        // and the database has "Fire", "Poison", "Block", and "Evade", then this method returns the two missing ones, i.e. 
        // "Block" and "Evade"
        [Test]
        public void CharacterRepo_GetMissingAbilitiesForCharacterWithSomeAbilities_Should_ReturnMissingAbilities()
        {
            // Arrange


            // Act 


            // Assert
            Assert.Fail();  // until implemented

        }

        // Test a special case of GetMissingAbilities in the situation where the character has no abilities.  It
        // should return all abilities in this case
        [Test]
        public void CharacterRepo_GetMissingAbilitiesForCharacterWithNoAbilities_Should_ReturnAllAbilities()
        {
            // Arrange
            int characterId = 6;  // this character has no abilities in the FakeData

            // Act 


            // Assert
            Assert.Fail();  // until implemented

        }

        [Test]
        public void getCharByID()
        {
            Assert.Pass();
        }

        [TestCase(0)]
        [TestCase(-34)]
        public void ChacterRepo_InvalidID_Should_ThrowException(int characterID)
        {
            // Arrange
            ICharacterRepository characterRepo = new CharacterRepository(_mockContext.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => { characterRepo.GetCharacter(characterID); });
        }

        [Test]
        public void ChacterRepo_GetCharacterWithNoResults_Returns_NoResults()
        {
            // Arrange
            ICharacterRepository characterRepo = new CharacterRepository(_mockContext.Object);
           
            int characterID = 11;

            //implement getcharacter first
            IEnumerable<Character> characterById = characterRepo.GetCharacter(characterID);

            // Assert that this list is empty
            Assert.That(characterById.Count(), Is.EqualTo(0));
        }

        [Test]
        public void ChacterRepo_GetCharacterWithResults_Returns_Results()
        {
            // Arrange
            ICharacterRepository characterRepo = new CharacterRepository(_mockContext.Object);


            //characterRepo.GetCharacter(1);
            int characterID = 1;

        //     List<Character> Characters = new List<Character>
        //{
        //    new Character { Id = 1, Created = DateTime.Parse("2021-12-04 12:15:44"), Level = 3 , Health = 40 , CharacterClassId = 1, },//Name = "Millia Rage"},
        //    new Character { Id = 2, Created = DateTime.Parse("2021-12-03 15:00:00"), Level = 9 , Health = 23 , CharacterClassId = 3, },//Name = "Haruka Sawamura"},
        //    new Character { Id = 3, Created = DateTime.Parse("2021-12-02 03:56:11"), Level = 15, Health = 75 , CharacterClassId = 5, },//Name = "Athena Asamiya"},
        //    new Character { Id = 4, Created = DateTime.Parse("2021-11-25 07:23:08"), Level = 11, Health = 52 , CharacterClassId = 5, },//Name = "Jak"},
        //    new Character { Id = 5, Created = DateTime.Parse("2021-11-25 20:10:23"), Level = 22, Health = 300, CharacterClassId = 6, },//Name = "Kanji Tatsumi"},
        //    new Character { Id = 6, Created = DateTime.Parse("2022-11-25 20:10:23"), Level = 5,  Health = 4,  CharacterClassId = 2, }//Name = "No Name"}   // Character with no abilities
        //};

        //implement getcharacter first
        IEnumerable<Character> characterById = characterRepo.GetCharacter(characterID).ToList();

            // Assert that this list is empty
            Assert.That(characterById.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ChacterRepo_GetCharacter_Returns_Specific_Results()
        {
            // Arrange
            ICharacterRepository characterRepo = new CharacterRepository(_mockContext.Object);


            //characterRepo.GetCharacter(1);
            int characterID = 1;

            //     List<Character> Characters = new List<Character>
            //{
            //    new Character { Id = 1, Created = DateTime.Parse("2021-12-04 12:15:44"), Level = 3 , Health = 40 , CharacterClassId = 1, },//Name = "Millia Rage"},
            //    new Character { Id = 2, Created = DateTime.Parse("2021-12-03 15:00:00"), Level = 9 , Health = 23 , CharacterClassId = 3, },//Name = "Haruka Sawamura"},
            //    new Character { Id = 3, Created = DateTime.Parse("2021-12-02 03:56:11"), Level = 15, Health = 75 , CharacterClassId = 5, },//Name = "Athena Asamiya"},
            //    new Character { Id = 4, Created = DateTime.Parse("2021-11-25 07:23:08"), Level = 11, Health = 52 , CharacterClassId = 5, },//Name = "Jak"},
            //    new Character { Id = 5, Created = DateTime.Parse("2021-11-25 20:10:23"), Level = 22, Health = 300, CharacterClassId = 6, },//Name = "Kanji Tatsumi"},
            //    new Character { Id = 6, Created = DateTime.Parse("2022-11-25 20:10:23"), Level = 5,  Health = 4,  CharacterClassId = 2, }//Name = "No Name"}   // Character with no abilities
            //};

            //implement getcharacter first
            IEnumerable<Character> characterById = characterRepo.GetCharacter(characterID).ToList();


            Character x = new Character();

            x.Health = characterById.First().Health;//= characterRepo.GetCharacter(characterID).ToList();
            x.Level = characterById.First().Level;
            int y = x.Health;
            int z = x.Level;
            // Assert that this list is empty
            Assert.That(y, Is.EqualTo(40));
            Assert.That(z, Is.EqualTo(3));
        }

    }


}