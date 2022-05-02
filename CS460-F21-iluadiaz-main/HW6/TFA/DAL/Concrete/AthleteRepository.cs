using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFA.Models;
using TFA.DAL.Abstract;
using TFA.DAL.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections;

namespace TFA.DAL.Concrete
{
    public class AthleteRepository : Repository<Athlete>, IAthleteRepository
    {
        private __TFADbContext _ctx;
        public AthleteRepository(__TFADbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<RaceResultDisplay> GetRaceResultsFor(string athleteName)
        {

            if (athleteName == null)
            {
                throw new System.ArgumentNullException();

            }

            List<RaceResultDisplay> results = new List<RaceResultDisplay>();

            var athletes = _ctx.Athletes.Include(a => a.RaceResults).ThenInclude(a => a.Location).Include(a => a.RaceResults).ThenInclude(a => a.Event);

            foreach (var Data in athletes)
            {
                if (Data.FullName == athleteName)
                {
                    foreach (var a in Data.RaceResults)
                    {
                        var newData = new RaceResultDisplay();
                        newData.MeetDate = a.Location.MeetDate;
                        newData.MeetName = a.Location.Title;
                        newData.Time = a.Time;
                        newData.TrackEventName = a.Event.Title;

                        results.Add(newData);

                    }
                     return results.OrderBy(a => a.TrackEventName.Length).ThenBy(a => a.TrackEventName).ToList();          
                }
            }
            return results;
        }
    }
} 
