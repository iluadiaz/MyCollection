using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace HW4Project.Models
{
    public class RGBModel
    {
        [Required]
        [Range(0, 255)]
        public int? Red {get; set; }
        [Required]
        [Range(0, 255)]
        public int? Green {get; set; }
        [Required]
        [Range(0, 255)]
        public int? Blue {get; set; }

        

        public override string ToString()
        {
            return $"#{Red:X2}{Green:X2}{Blue:X2}";
        } 

    }

}