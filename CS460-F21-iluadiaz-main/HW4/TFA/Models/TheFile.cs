using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using TFA.DAL.Abstract;
using TFA.DAL.Concrete;
using FileHelpers;
namespace TFA.Models
{
    [DelimitedRecord(",")]
    public class TheFile 
    {
        public IFormFile userFile { get; set; }

        public string uniqueFile { get; set; }

        public List<Athlete> athlete = null;

        public List<Classification> classification = null;

        public List<Coach> coach = null;

        public List<Team> team = null;

        public List<RaceResult> raceResult = null;

        public List<Location> location = null;

        public List<TrackEvent> trackEvent = null;

        public UploadFile upload  { get; set; }

        public int successfulRecordCount = 0;
        public int negTimes = 0;
        public int invalidEvent = 0;
        public int invalidCoach = 0;
        public int invalidTeam = 0;
        public int invalidAthleticEvent = 0;
    }
}
