using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSemIII.Areas.Admin.Models.DataModel
{
    [Table("Publishers")]
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }


        [Display(Name = "Tên NXB ")]
        [Required(ErrorMessage = "Hãy nhập tên nhà xuất bản")]
        [StringLength(150, ErrorMessage = " Tên NXB từ 3-150 ký tự", MinimumLength = 3)]
        public string PublisherName { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        public string PublisherPhone { get; set; }

       

        [StringLength(150)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        [StringLength(250)]
        [Display(Name = "Địa chỉ")]
        public string PublisherAddress { get; set; }

        [Column(TypeName = "ntext")]
        [AllowHtml]
        [Display(Name = "Mô tả")]
        public string Note { get; set; }
        //tạo thuộc tính navigation
        public virtual ICollection<Book> Books { get; set; }
    }
}