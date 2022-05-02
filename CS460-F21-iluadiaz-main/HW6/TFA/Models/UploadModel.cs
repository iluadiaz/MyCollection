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
    public class UploadModel 
    {
        public string Location { get; set; }

        public string Date { get; set; }

        public string Team { get; set; }

        public string Coach { get; set; }

        public string Event { get; set; }

        public string Gender { get; set; }

        public string Athlete { get; set; }

        public string Time { get; set; }

    }
}
