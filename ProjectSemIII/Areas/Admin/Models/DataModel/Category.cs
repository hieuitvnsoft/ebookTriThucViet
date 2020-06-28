using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSemIII.Areas.Admin.Models.DataModel
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [Display(Name ="Mã thể loại")]
        public int CategoryId { get; set; }

        [Display(Name = "Tên thể loại")]
        [Required(ErrorMessage = "Hãy nhập tên nhà xuất bản")]
        [StringLength(150, ErrorMessage = " Thể loại từ 3-150 ký tự", MinimumLength = 3)]
        public string CategoryName { get; set; }

        [Display(Name = "Mã thể loại cha")]
        public int CatgoryIdParent { get; set; }

        [Column(TypeName = "ntext")]
        [AllowHtml]
        [Display(Name = "Mô tả")]
        public string Note { get; set; }

        //tạo thuộc tính navigation
        public virtual ICollection<Book> Books { get; set; }
    }
}