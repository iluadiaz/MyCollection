using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFA.DAL.Abstract;
using TFA.Models;
using Microsoft.VisualBasic.FileIO;
using FileHelpers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace TFA.DAL.Concrete
{

    public class UploadFile : IUploadFile
    {
        

        public bool Flag(string[] data, string comparison)
        {
            for (int i = 0; i < data.Length; i++)
                if (data[i] == comparison)
                {
                    return true;
                }
            return false;
        }

        public string StoreFile(TheFile fileName, UploadModel model, IHostingEnvironment enviornment)
        {
            string uniqueFile = null;

            if (fileName.userFile != null)
            {
                if (fileName.userFile.FileName[fileName.userFile.FileName.Length - 1] == 'v' &&
                    fileName.userFile.FileName[fileName.userFile.FileName.Length - 2] == 's' &&
                    fileName.userFile.FileName[fileName.userFile.FileName.Length - 3] == 'c' &&
                    fileName.userFile.FileName[fileName.userFile.FileName.Length - 4] == '.')
                {

                    string uploadsFolder = Path.Combine(enviornment.WebRootPath, "Data");

                    uniqueFile = Guid.NewGuid().ToString() + "_" + fileName.userFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFile);

                    fileName.userFile.CopyTo(new FileStream(filePath, FileMode.Create));

                    return filePath;
                }
                else
                {
                    throw new Exception("received an invalid file type!");
                }
            }
            else
            {
                throw new ArgumentNullException("received a null File!");
            }
        }

      
        public void UploadData(TheFile file, IAthleteRepository athleteRepo, ICoachRepository coachRepo, IClassificationRepository eventClassificationRepo,
            ITrackEventRepository eventRepo, ILocationRepository meetRepo, IRaceResultRepository timeRepo, ITeamRepository teamRepo, UploadModel data,
            IHostingEnvironment hostingEnvironment, __TFADbContext _ctx)
        {

            string uniqueFile = null;
            UploadFile upload = new UploadFile();
            Athlete _athlete = new Athlete();
            Coach _coach = new Coach();
            TrackEvent _event = new TrackEvent();
            Classification _eventClassifications = new Classification();
            Location _meet = new Location();
            RaceResult _time = new RaceResult();
            Team _team = new Team();

            bool flag = true;

            if (file.userFile != null)
            {
                uniqueFile = upload.StoreFile(file, data, hostingEnvironment);

                var fileHelperEngine = new FileHelperEngine<UploadModel>();
                var records = fileHelperEngine.ReadFile(@"" + uniqueFile);

                string[] athletes = new string[records.Length], coaches = new string[records.Length], events = new string[records.Length],
                         eventClassifications = new string[records.Length], meets = new string[records.Length], teams = new string[records.Length];

                var _athleteIDs = new Athlete();
                var _EventClassificationIDs = new Classification();
                var _EventIDs = new TrackEvent();
                var _coachIDs = new Coach();
                var _meetIDs = new Location();
                var _teamIDs = new Team();
                var _timeIDs = new RaceResult();

                int coachID = coachRepo.lastId();
                int eventID = eventRepo.lastId();
                int eventClassificationID = eventClassificationRepo.lastId();
                int meetID = meetRepo.lastId();
                int teamID = teamRepo.lastId();
                int athleteID = athleteRepo.lastId();
                int timeID = timeRepo.lastId();

                for (int i = 1; i < records.Length; i++)
                {
                    if (upload.Flag(coaches, records[i].Coach) == false)
                    {
                        _coach.FullName = records[i].Coach;
                        coaches[i] = records[i].Coach;
                        _coachIDs = coachRepo.AddOrUpdate(new Coach { FullName = _coach.FullName });
                        _coachIDs.Id = coachID; 
                        coachID++;
                        file.successfulRecordCount++;
                    }
                    if (upload.Flag(events, records[i].Event) == false)
                    {
                        _event.Title = records[i].Event;
                        events[i] = records[i].Event;
                        _EventIDs = eventRepo.AddOrUpdate(new TrackEvent { Title = _event.Title});
                        _EventIDs.Id = eventID;
                        eventID++;
                        file.successfulRecordCount++;
                    }
                    if (upload.Flag(eventClassifications, records[i].Gender) == false)
                    {
                        _eventClassifications.Name = records[i].Gender;
                        eventClassifications[i] = records[i].Gender;
                        _EventClassificationIDs = eventClassificationRepo.AddOrUpdate(new Classification { Name = _eventClassifications.Name});
                    }
                    if (upload.Flag(meets, records[i].Date) == false)
                    {
                        _meet.MeetDate = DateTime.Parse(records[i].Date);
                        _meet.Title = records[i].Location;
                        meets[i] = records[i].Date;
                        _meetIDs = meetRepo.AddOrUpdate(new Location { MeetDate = _meet.MeetDate, Title = _meet.Title});
                        _meetIDs.Id = meetID;
                        meetID++;
                        file.successfulRecordCount++;
                    }
                    if (upload.Flag(teams, records[i].Team) == false)
                    {
                        int coachId = 0;
                        List<Coach> coachlist = _ctx.Coaches.ToList();
                        _team.Name = records[i].Team;
                        teams[i] = records[i].Team;
                        foreach (var a in coachlist)
                        {
                            if (records[i].Coach == a.FullName)
                            {
                                coachId = a.Id;
                            }
                        }
                        
                        _teamIDs = teamRepo.AddOrUpdate(new Team { Name = _team.Name, CoachId = coachId});
                        _teamIDs.Id = teamID;
                        teamID++;
                        file.successfulRecordCount++;

                    }
                    if (upload.Flag(athletes, records[i].Athlete) == false)
                    {
                        int teamId = 0;
                        List<Team> teamList = _ctx.Teams.ToList();
                        _athlete.FullName = records[i].Athlete;
                        athletes[i] = records[i].Athlete;
                        foreach (var a in teamList)
                        {
                            if (records[i].Team == a.Name)
                            {
                                teamId = a.Id;
                            }
                        }
                        _athleteIDs =  athleteRepo.AddOrUpdate(new Athlete { FullName = _athlete.FullName, TeamId = teamId });
                        _athleteIDs.Id = athleteID;
                        athleteID++;
                        file.successfulRecordCount++;
                    }
                    if (Convert.ToDouble(records[i].Time) > 0)
                    {
                        int genders = 0;
                        int idForEvents = 0;
                        int idForAthletes = 0;
                        int idForLocations = 0;
                        List<Classification> genderList = _ctx.Classifications.ToList();
                        List<TrackEvent> eventList = _ctx.TrackEvents.ToList();
                        List<Athlete> athleteList = _ctx.Athletes.ToList();
                        List<Location> locationList = _ctx.Locations.ToList();
                        foreach (var a in genderList)
                        {
                            if (records[i].Gender == a.Name)
                            {
                                genders = a.Id;
                            }
                        }
                        foreach (var a in eventList)
                        {
                            if (records[i].Event == a.Title)
                            {
                                idForEvents = a.Id;
                            }
                        }
                        foreach (var a in athleteList)
                        {
                            if (records[i].Athlete == a.FullName)
                            {
                                idForAthletes = a.Id;
                            }
                        }
                        foreach (var a in locationList)
                        {
                            if (records[i].Location == a.Title)
                            {
                                idForLocations = a.Id;
                            }
                        }
                        _time.Time = Convert.ToDouble(records[i].Time);

                        _timeIDs = timeRepo.AddOrUpdate(new RaceResult() { Time = _time.Time, AthleteId = idForAthletes, EventId = idForEvents,
                            ClassificationId = genders, LocationId = idForLocations });
;
                        _timeIDs.Id = timeID;
                        timeID++;
                        file.successfulRecordCount++;
                    }
                    if (Convert.ToDouble(records[i].Time) < 0)
                    {
                        file.negTimes++;
                    }
                    if (records[i].Gender != "Boys" || records[i].Gender != "Girls")
                    {
                        flag = true;
                    }
                    else
                    {
                        file.invalidEvent++;
                    }
                        if (records[i].Coach != "Erik Cross" || records[i].Coach != "Bill Masei" || records[i].Coach != "Kerri Lemerande" || records[i].Coach != "Don Berger"
                      || records[i].Coach != "Eli Cirino")
                    {
                        flag = true;
                    }
                    else
                    {
                        file.invalidCoach++;
                    }
                    if (records[i].Team != "Silverton HS" || records[i].Team != "Dallas HS" || records[i].Team != "North Salem Hs" || records[i].Team != "Central HS"
                      || records[i].Team != "West Albany HS")
                    {
                        flag = true;
                    }
                    else
                    {
                        file.invalidTeam++;
                    }
                    if (records[i].Event == "3000" || records[i].Event == "1500" || records[i].Event == "800" || records[i].Event == "200" || records[i].Event == "300ih"
                    || records[i].Event == "400" || records[i].Event == "100" || records[i].Event == "100hh" || records[i].Event == "110hh")
                    {
                        flag = true;
                    }
                    else
                    {
                        file.invalidAthleticEvent++;
                    };
                }
            }
            File.Delete(@"" + uniqueFile);
        }
    }
}
