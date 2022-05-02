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
    }
}
