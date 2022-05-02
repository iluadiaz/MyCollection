using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFA.Models
{
    public class TeamViewModel
    {
        public List<Athlete> athleteList = null;
        //public List<Team> teamsList = null;
        public TeamCoachPair coachPair = null;
        public IEnumerable<TeamCoachPair> teamList = null;
    }
}
