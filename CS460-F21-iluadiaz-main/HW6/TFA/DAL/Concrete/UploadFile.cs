//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using TFA.DAL.Abstract;
//using TFA.Models;
//using Microsoft.VisualBasic.FileIO;
//using FileHelpers;
//using System.IO;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;

//namespace TFA.DAL.Concrete
//{

//    public class UploadFile : IUploadFile
//    {
//        UploadModel model = new UploadModel();
//        public bool Flag(string[] data, string comparison)
//        {
//            for (int i = 0; i < data.Length; i++)
//                if (data[i] == comparison)
//                {
//                    return true;
//                }
//            return false;
//        }

//        public string StoreFile(TheFile fileName, UploadModel model, IHostingEnvironment enviornment)
//        {
//            string uniqueFile = null;
            
//            if (fileName.userFile != null)
//            {
//                if (fileName.userFile.FileName[fileName.userFile.FileName.Length - 1] == 'v' &&
//                    fileName.userFile.FileName[fileName.userFile.FileName.Length - 2] == 's' &&
//                    fileName.userFile.FileName[fileName.userFile.FileName.Length - 3] == 'c' &&
//                    fileName.userFile.FileName[fileName.userFile.FileName.Length - 4] == '.')
//                {

//                        string uploadsFolder = Path.Combine(enviornment.WebRootPath, "Data");

//                        uniqueFile = Guid.NewGuid().ToString() + "_" + fileName.userFile.FileName;
//                        string filePath = Path.Combine(uploadsFolder, uniqueFile);

//                    fileName.userFile.CopyTo(new FileStream(filePath, FileMode.Create));

//                    return filePath;
//                }
//                else
//                {
//                    throw new Exception("received an invalid file type!");
//                }

//            }
//            else
//            {
//                throw new ArgumentNullException("received a null File!");
//            }
//        }

//        public void addAthlete(Repository<Athlete> athleteRepo, Athlete _athlete, string uniqueFile, UploadFile upload, string [] athletes)
//        {
//            var fileHelperEngine = new FileHelperEngine<UploadModel>();
//            var records = fileHelperEngine.ReadFile(@"" + uniqueFile);
//            var _athleteIDs = new Athlete();
//            for (int i = 0; i < records.Length; i++)
//            {
//                if (upload.Flag(athletes, records[i].Athlete) == false)
//                {
//                    _athlete.Name = records[i].Athlete;
//                    _athlete.Team = records[i].Team;
//                    athletes[i] = records[i].Athlete;
//                    _athleteIDs = athleteRepo.AddOrUpdate(new Athlete { Name = _athlete.Name, Team = _athlete.Team });

//                }
//            }
//        }//mifhgt need IRepos istead of repo
//        public void addCoach(Repository<Coach> coachRepo, Coach _coach, string uniqueFile, UploadFile upload, string[] coaches)
//        {
//            var fileHelperEngine = new FileHelperEngine<UploadModel>();
//            var records = fileHelperEngine.ReadFile(@"" + uniqueFile);
//            var _coachIDs = new Coach();
//            for (int i = 0; i < records.Length; i++)
//            {
//                if (upload.Flag(coaches, records[i].Coach) == false)
//                {
//                    _coach.Name = records[i].Athlete;
//                    _coach.Team = records[i].Team;
//                    coaches[i] = records[i].Athlete;
//                    _coachIDs = coachRepo.AddOrUpdate(new Coach { Name = _coach.Name, Team = _coach.Team });

//                }
//            }
//        }
//        public void addEventClassification(Repository<EventClassification> eventClassificationRepo, EventClassification _eventClassifications, 
//            string uniqueFile, UploadFile upload, string[] eventClassifications)
//        {
//            var fileHelperEngine = new FileHelperEngine<UploadModel>();
//            var records = fileHelperEngine.ReadFile(@"" + uniqueFile);
//            var _EventClassificationIDs = new EventClassification();
//            for (int i = 0; i < records.Length; i++)
//            {
//                if (upload.Flag(eventClassifications, records[i].Gender) == false)
//                {
//                    _eventClassifications.Classification = records[i].Gender;
//                    eventClassifications[i] = records[i].Gender;
//                    _EventClassificationIDs = eventClassificationRepo.AddOrUpdate(new EventClassification { Classification = _eventClassifications.Classification });
                   
//                }
//            }
//        }
//        public void addEvent(Repository<Event> eventRepo, Event _event, string uniqueFile, UploadFile upload, string[] events)
//        {
//            var fileHelperEngine = new FileHelperEngine<UploadModel>();
//            var records = fileHelperEngine.ReadFile(@"" + uniqueFile);
//            var _EventIDs = new Event();
//            for (int i = 0; i < records.Length; i++)
//            {
//                if (upload.Flag(events, records[i].Event) == false)
//                {
//                    _event.EventType = records[i].Event;
//                    events[i] = records[i].Event;
//                    _EventIDs = eventRepo.AddOrUpdate(new Event { EventType = _event.EventType });
                    
//                }
//            }
//        }
//        public void addMeet(Repository<Meet> meetRepo, Meet _meet, string uniqueFile, UploadFile upload, string[] meets)
//        {
//            var fileHelperEngine = new FileHelperEngine<UploadModel>();
//            var records = fileHelperEngine.ReadFile(@"" + uniqueFile);
//            var _EventIDs = new Event();
//            for (int i = 0; i < records.Length; i++)
//            {
//                //_meet.Date = records[i].Date;
//                _meet.Location = records[i].Location;
//                meets[i] = records[i].Date;
//                meetRepo.AddOrUpdate(new Meet { Date = _meet.Date, Location = _meet.Location });
                
//            }
//        }
//        public void addTime(Repository<Time> timeRepo, Time _time, string uniqueFile, UploadFile upload, Athlete _athleteIDs,
//            EventClassification _EventClassificationIDs, Event _EventIDs)
//        {
//            var fileHelperEngine = new FileHelperEngine<UploadModel>();
//            var records = fileHelperEngine.ReadFile(@"" + uniqueFile);
//            var _TimeIDs = new Time();
//            for (int i = 0; i < records.Length; i++)
//            {
//                if (Convert.ToDouble(records[i].Time) > 0)
//                {
//                    //_time.AthleteTimes = records[i].Time;
//                    timeRepo.AddOrUpdate(new Time() { AthleteId = _athleteIDs.Id, AthleteTimes = _time.AthleteTimes, ClassificationId = _EventClassificationIDs.Id, EventId = _EventIDs.Id });
                    
//                }
//            }
//        }
//    }
//}
