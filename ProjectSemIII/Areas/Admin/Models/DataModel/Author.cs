using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSemIII.Areas.Admin.Models.DataModel
{
    [Table ("Authors")]
    public class Author
    {
        [Key]
        [Display(Name = "Mã tác giả")]
        public int AuthorId { get; set; }

        [Display(Name = "Tên tác giả")]
        [StringLength(250, ErrorMessage = " Tên tác giả 3-250 ký tự", MinimumLength = 3)]
        public string AuthorName { get; set; }

        [Display(Name = "Số điện thoại")]
        [StringLength(50)]
        public string AuthorPhone { get; set; }

        [StringLength(150)]
        [Column(TypeName = "varchar")]
        public string AuthorEmail { get; set; }

        [Display(Name = "Địa chỉ")]
        public string AuthorAddress { get; set; }
        
        [Column(TypeName = "ntext")]
        [AllowHtml]
        [Display(Name = "Thông tin mô tả tác giả")]
        public string AuthorInfor { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}