using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSemIII.Areas.Admin.Models.DataModel
{
    [Table("Newss")]
    public class News
    {
        [Key]
        [Display(Name ="Mã tin")]
        public int Id { get; set; }

        [Display(Name = "Tiêu đề")]
        public string Tittle { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(516,ErrorMessage ="Mô tả tối đa 516 ký tự")]
        public string Desciption { get; set; }

        [Display(Name = "Nội dung")]
        [Column(TypeName ="ntext")]
        [AllowHtml]
        public string Content { get; set; }

        [Display(Name = "Ảnh tin")]
        public string Image { get; set; }

        [Display(Name = "Từ khóa")]
        [StringLength(250,ErrorMessage ="Từ khóa tối đa 256 ký tự")]
        public string Keyword { get; set; }

        [Display(Name = "Ngày viết")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateWirite { get; set; }

        [ForeignKey("Admin")]
        [Display(Name = "Người viết")]
        public int AdminId { get; set; }

        public Admin Admin { get; set; }
    }
}