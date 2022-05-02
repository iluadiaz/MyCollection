using System;
using System.ComponentModel.DataAnnotations;

namespace Hw5Project.Models
{
   public class Hw5HomeModel
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public String ImagePath()
        {
        
                return "~/Views/Images/Zermatt1.PNG";

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }    

}