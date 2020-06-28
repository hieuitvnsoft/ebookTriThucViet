using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSemIII.Areas.Admin.Models.DataModel
{
    [Table("Adss")]
    public class Ads
    {
        [Key]
        [Display(Name ="Mã quảng cáo")]
        public int Id { get; set; }

        [Display(Name ="Ảnh")]
        public string Image { get; set; }

        [Display(Name = "Link quảng cáo")]
        public string AdsLink { get; set; }

        [Display(Name = "Mô tả")]
        [Column(TypeName ="ntext")]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "Vị trí hiển thị")]
        public int Location { get; set; }

        [Display(Name = "Trạng thái")]
        [DefaultValue(0)]
        public int StatusOn { get; set; }
    }
}