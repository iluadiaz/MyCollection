using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expeditions.DAL.Abstract;
using Expeditions.DAL.Concrete;
using Microsoft.AspNetCore.Components.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace Expeditions.Models
{
    public class CreateViewModel
    {
        public List<Peak> peaks = new List<Peak>();

        public List<TrekkingAgency> agencies = new List<TrekkingAgency>();

        public List<Expedition> expeditions = new List<Expedition>();

        public List<string> termReasons = new List<string>();

        public Peak peakToDB = new Peak();

        public TrekkingAgency agencyToDb = new TrekkingAgency();

        public Expedition expeditionToDb = new Expedition();

        public List<SelectListItem> peakDropDown = new List<SelectListItem>();

        public List<SelectListItem> agencyDropDown = new List<SelectListItem>();

        public List<SelectListItem> o2DropDown = new List<SelectListItem>();

        public List<SelectListItem> terminationDropDown = new List<SelectListItem>();

        public int peakDropDownItemId { get; set; }

        public int o2Id { get; set; }

        public bool o2 { get; set; }

        public int agencyId { get; set; }

        public int terminationId { get; set; }

        [DisplayFormat(DataFormatString = "{0:d yyyy-MM-dd}")]
        public DateTime dateToUpdate { get; set; }

        public string dateFormatted { get => dateToUpdate.ToString("yyyy-MM-dd"); }


        public string SetSeason(string date)
        {
            string dateHolder = date.ToString();

            string[] seasonDeterminer = dateHolder.Split('-', StringSplitOptions.TrimEntries);

            int month = Int32.Parse(seasonDeterminer[1]);

            string season = null;

            if (month >= 5 && month <= 3)
            {
                season = "Spring";
            }
            else if (month >= 6 && month <= 8)
            {
                season = "Summer";
            }
            else if (month >= 9 && month <= 11)
            {
                season = "Autumn";
            }
            else if (month == 12 || month <= 2)
            {
                season = "Winter";
            }
            return season;
        }

        public CreateViewModel PrepModelData(CreateViewModel data,  List<Peak> peakList,  List<TrekkingAgency> agencyList )
        {

            List<Peak> peaksToUpload = peakList;
            
            List<TrekkingAgency> agenciesToUpload = agencyList;
            var peakFromUser = data.peakDropDownItemId;
            var agencyFromUser = data.agencyId;
            var terminationReasonFromUser = data.terminationId;
            

            if (o2Id == 1)
            {
                data.expeditionToDb.OxygenUsed = true;
            }
            else 
            {
                data.expeditionToDb.OxygenUsed = false;
            }
            foreach (var a in peaksToUpload)
            {
                if (a.Id == peakFromUser)
                {
                    data.expeditionToDb.Peak = a;
                    data.expeditionToDb.PeakId = a.Id;
                }
            }

            foreach (var a in agenciesToUpload)
            {
                if (a.Id == agencyFromUser)
                {
                    data.expeditionToDb.TrekkingAgency = a;
                    data.expeditionToDb.TrekkingAgency.Id = a.Id;
                }
            }

            for(int i = 0; i < data.termReasons.Count(); i++ )
            {
                if(terminationReasonFromUser == i)
                {
                    data.expeditionToDb.TerminationReason = data.termReasons[i];
                }
            }
            data.expeditionToDb.StartDate = ParseIt(data.dateToUpdate);
            data.expeditionToDb.Season = SetSeason(data.dateFormatted);

            data.expeditionToDb.Year = getYear(data.dateFormatted);
           
            return (data);
        }

        public DateTime ParseIt(DateTime date)
        {

            DateTime dateToReturn = new DateTime(date.Year, date.Month, date.Day);

            return dateToReturn;
        }

        public int getYear(string date)
        {
            string dateHolder = date.ToString();

            string[] seasonDeterminer = dateHolder.Split('-', StringSplitOptions.TrimEntries);

            int year = Int32.Parse(seasonDeterminer[0]);

            return year;
        }
    }
}