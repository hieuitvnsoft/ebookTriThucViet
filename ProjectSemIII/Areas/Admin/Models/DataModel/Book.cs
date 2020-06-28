using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSemIII.Areas.Admin.Models.DataModel
{

    [Table("Books")]
    public class Book
    {
        [Key]
        [Display(Name = "Mã sách")]
        [Required(ErrorMessage = "Hãy nhập mã sách")]
        [StringLength(5, ErrorMessage = " Tên NXB từ 3-5 ký tự", MinimumLength = 3)]
        public string BookId { get; set; }


        [Display(Name = "Tên sách")]
        [Required(ErrorMessage = "Hãy nhập tên nhà xuất bản")]
        [Index("Ix_Book", Order = 1, IsUnique = true)]
        [StringLength(250, ErrorMessage = " Tên sách 3-250 ký tự", MinimumLength = 3)]
        public string BookName { get; set; }

        [ForeignKey("Category")]
        [Display(Name = "Thể loại")]
        public int CategoryId { get; set; }

        [ForeignKey("Publisher")]
        [Display(Name = "NXB")]
        public int PublisherId { get; set; }

        [ForeignKey("Author")]
        [Display(Name = "Tác giả")]
        public int AuthorId { get; set; }

        [Display(Name = "Năm xuất bản")]
        public int? PublishingYear { get; set; }

        [Range(0, 100)]
        [Display(Name ="Sale")]
        public int Sale { get; set; }

        [Display(Name = "Giá")]
        [Required(ErrorMessage = "Hãy nhập giá sách")]
        public float? Price { get; set; }

        [Column(TypeName = "ntext")]
        [AllowHtml]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [StringLength(512)]
        [Display(Name = "Hình ảnh 1")]
        public string BookImage1 { get; set; }

        [StringLength(512)]
        [Display(Name = "Hình ảnh 2")]
        public string BookImage2 { get; set; }

        [StringLength(512)]
        [Display(Name = "Hình ảnh 3")]
        public string BookImage3 { get; set; }

        [Display(Name = "Còn hàng")]
        [Required(ErrorMessage = "Hãy nhập giá sách")]
        public int StatusAvarible { get; set; }

        [Display(Name = "Trạng thái")]
        [Required(ErrorMessage = "Hãy nhập giá sách")]
        public int StatusOn { get; set; }

        //thuộc tính navigation
        public Publisher Publisher { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }

}