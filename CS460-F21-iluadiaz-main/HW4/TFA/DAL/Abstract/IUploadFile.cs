using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using TFA.DAL.Concrete;

namespace TFA.DAL.Abstract
{
    public interface IUploadFile
    {
        public bool Flag(string[] data, string comparison);

        public string StoreFile(TheFile fileName, UploadModel data, IHostingEnvironment enviornment);
        public void UploadData(TheFile file, IAthleteRepository athleteRepo, ICoachRepository coachRepo, IClassificationRepository eventClassificationRepo,
        ITrackEventRepository eventRepo, ILocationRepository meetRepo, IRaceResultRepository timeRepo, ITeamRepository teamRepo, UploadModel data,
        IHostingEnvironment hostingEnvironment, __TFADbContext _ctx);
    }
}
