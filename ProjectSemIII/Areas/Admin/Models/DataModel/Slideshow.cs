using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectSemIII.Areas.Admin.Models.DataModel
{
    [Table("Slideshows")]
    public class Slideshow
    {
        [Key]
        [Display(Name ="Mã slide")]
        public int Id { get; set; }

        [Display(Name ="Ảnh slide 1")]
        public string Image1 { get; set; }

        [Display(Name = "Ảnh slide 2")]
        public string Image2 { get; set; }

        [Display(Name = "Ảnh slide 3")]
        public string Image3 { get; set; }

        [Display(Name = "Ảnh slide 4")]
        public string Image4 { get; set; }
    }
}