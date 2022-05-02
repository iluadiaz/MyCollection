using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFA.Models;
using TFA.DAL.Abstract;
using Microsoft.EntityFrameworkCore;

namespace TFA.DAL.Concrete
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        private __TFADbContext _ctx;
        public TeamRepository(__TFADbContext ctx) : base(ctx)
        {
           _ctx = ctx;
        }

        public IEnumerable<Athlete> GetAthletesFor(string teamName)
        {
            if (teamName == null)
            {
                throw new System.ArgumentNullException();

            }

            List<Athlete> data = new List<Athlete>();

            var resultData = _ctx.Teams.Include(a=> a.Athletes);
            
            foreach (var Data in resultData)
            {
                if (Data.Name == teamName)
                {
                    data = Data.Athletes.ToList();
                }
            }
            return data.OrderBy(a => a.FullName.Split(" ")[1]);
        }

        public IEnumerable<TeamCoachPair> GetTeamsWithCoaches()
        {
            List<TeamCoachPair> data = new List<TeamCoachPair>();

            var resultData = _dbSet.Include(c => c.Coach).ToList();

            foreach (var Data in resultData)
            {
                var newData = new TeamCoachPair();
                newData.CoachName = Data.Coach.FullName;
                newData.TeamName = Data.Name;

                data.Add(newData);
            }

            var orderedData = data.OrderBy(a => a.TeamName).ToList();
            return orderedData;
        }
        public TeamCoachPair GetTeamWithCoach(string x)
        {
            TeamCoachPair data = new TeamCoachPair();

            var resultData = _dbSet.Include(c => c.Coach).ToList();

            foreach (var Data in resultData)
            {
                if (Data.Name == x)
                {
                    var newData = new TeamCoachPair();
                    newData.CoachName = Data.Coach.FullName;
                    newData.TeamName = Data.Name;

                    data = newData;
                }
            }
            return data;
        }
    }
}

