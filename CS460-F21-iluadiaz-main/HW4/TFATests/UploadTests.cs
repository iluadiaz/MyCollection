using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;
using TFA.DAL.Abstract;
using TFA.DAL.Concrete;
using TFA.Models;

namespace TFATests
{
    public class UploadTests
    {
        private Mock<__TFADbContext> _mockContext;

        private Mock<DbSet<Athlete>> _mockAthleteDbSet;
        private List<Athlete> _athletes = FakeData.Athletes;

        private Mock<DbSet<Coach>> _mockCoachDbSet;
        private List<Coach> _Coaches = FakeData.Coaches;

        private Mock<DbSet<TrackEvent>> _mockEventDbSet;
        private List<TrackEvent> _events = FakeData.TrackEvents;

        private Mock<DbSet<Location>> _mockLocationDbSet;
        private List<Location> _locations = FakeData.Locations;

        private Mock<DbSet<Classification>> _mockClassificationDbSet;
        private List<Classification> _Classification = FakeData.Classifications;

        private Mock<DbSet<Team>> _mockTeamDbSet;
        private List<Team> _Team = FakeData.Teams;

        private Mock<DbSet<RaceResult>> _mockRaceResultDbSet;
        private List<RaceResult> _raceResults = FakeData.RaceResults;

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
            // Get mock dbsets
            _mockAthleteDbSet = GetMockDbSet(_athletes.AsQueryable());
            _mockCoachDbSet = GetMockDbSet(_Coaches.AsQueryable());
            _mockEventDbSet = GetMockDbSet(_events.AsQueryable());
            _mockLocationDbSet = GetMockDbSet(_locations.AsQueryable());
            _mockClassificationDbSet = GetMockDbSet(_Classification.AsQueryable());
            _mockTeamDbSet = GetMockDbSet(_Team.AsQueryable());
            _mockRaceResultDbSet = GetMockDbSet(_raceResults.AsQueryable());

            // Get the mock context
            _mockContext = new Mock<__TFADbContext>();
            _mockContext.Setup(ctx => ctx.Athletes).Returns(_mockAthleteDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Athlete>()).Returns(_mockAthleteDbSet.Object);

            _mockContext.Setup(ctx => ctx.Coaches).Returns(_mockCoachDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Coach>()).Returns(_mockCoachDbSet.Object);
            _mockContext.Setup(ctx => ctx.TrackEvents).Returns(_mockEventDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<TrackEvent>()).Returns(_mockEventDbSet.Object);
            _mockContext.Setup(ctx => ctx.Locations).Returns(_mockLocationDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Location>()).Returns(_mockLocationDbSet.Object);
            _mockContext.Setup(ctx => ctx.Classifications).Returns(_mockClassificationDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Classification>()).Returns(_mockClassificationDbSet.Object);
            _mockContext.Setup(ctx => ctx.Teams).Returns(_mockTeamDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Team>()).Returns(_mockTeamDbSet.Object);
            _mockContext.Setup(ctx => ctx.RaceResults).Returns(_mockRaceResultDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<RaceResult>()).Returns(_mockRaceResultDbSet.Object);
        }

        // Failure conditions

        [Test]
        public void LastId_Returns_Id_plus_1()
        {
            // Arrange
            IAthleteRepository athleteRepo = new AthleteRepository(_mockContext.Object);
            int id = 0;
            //lastId doesnt return actual last id, it checks for lastid and adds 1 to it,so subtract too get lastId
            id = athleteRepo.lastId() -1;
            Assert.AreEqual(id, 50);

            id = athleteRepo.lastId();
            Assert.AreEqual(id, 51);

        }

        [Test]
        public void FlagMethodReturnsFalseIfNotPresent()
        {
            string[] array = new string[100];

            array[0] = "fish";

            UploadFile x = new UploadFile();

            Assert.IsFalse(x.Flag(array, "taco"));


        }

        [Test]
        public void FlagMethodReturnsTrueIfPresent()
        {
            string[] array = new string[100];

            array[0] = "fish";

            UploadFile x = new UploadFile();

            Assert.IsTrue(x.Flag(array, "fish"));

        }
        [Test]
        public void TestsGetAll()
        {
            IAthleteRepository athleteRepo = new AthleteRepository(_mockContext.Object);

            Assert.NotNull(athleteRepo.GetAll());


        }
    }   
}
