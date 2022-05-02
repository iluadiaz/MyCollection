using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HW3.Models;
using Newtonsoft.Json.Linq;

namespace HW3.DAL.Abstract
{
    public abstract class GitHubModel
    {
        public abstract void FromJSON(JObject a);
        
    }
}