using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using HW3.DAL.Abstract;

namespace HW3.Models
{
    public class GitHubBranch : GitHubModel
    {
        public string Name { get; set; }

        public override void FromJSON(JObject a)
        {
            Name = (string)a["name"];
        }
    }
}
