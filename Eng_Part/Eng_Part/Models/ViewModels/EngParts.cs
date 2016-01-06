using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Eng_Part.Models.ViewModels
{
    public class EngParts
    {
        [Key]
        public int PartID { get; set; }
        
        [Required(ErrorMessage = "* Please enter part name ")]
        [Display(Name = "Part Name")]
        public string PartName { get; set; }

        [Required(ErrorMessage = "* Please enter page description")]
        [Display(Name = "Part Description")]
        public string PartDesc { get; set; }

        [Required(ErrorMessage = "* Please select page metal")]
        [Display(Name = "Part Metal")]
        public bool PartMetal { get; set; }

        [Display(Name = "Part Dimension")]
        public int PartDimension { get; set; }



    }
}