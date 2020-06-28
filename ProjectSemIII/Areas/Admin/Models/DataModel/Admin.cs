using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectSemIII.Areas.Admin.Models.DataModel
{
    [Table("Admins")]
    public class Admin
    {
        [Key]
        [Display(Name = "Mã nhân viên")]
        public int AdminId { get; set; }

        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Hãy nhập tài khoản")]
        [Column(TypeName = "varchar")]
        [StringLength(30, ErrorMessage = "Tài khoản từ 6 - 30 ký tự ", MinimumLength = 6)]
        public string Username { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        [Column(TypeName = "varchar")]
        [StringLength(256, ErrorMessage = "Mật khẩu từ tối thiểu 6 ký tự ", MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Nhập họ và tên")]
        [StringLength(60, ErrorMessage = "Họ và tên từ 6 - 60 ký tự ", MinimumLength = 6)]
        public string FullName { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(512, ErrorMessage = "Địa chỉ tối thiểu 10 ký tự", MinimumLength = 10)]
        public string Address { get; set; }

        [Display(Name = "Giới tính")]
        [DefaultValue(true)]
        public bool Sex { get; set; }


        [Display(Name = "Sinh ngày")]
        [Required(ErrorMessage = "Hãy nhập ngày sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        [Display(Name = "Số điện thoại")]
        [RegularExpression(@"^\d{10,12}$", ErrorMessage = "Số điện thoại phải từ 10-12")]
        [Required(ErrorMessage = "Hãy nhập số điện thoại của bạn")]
        public string Phone { get; set; }


        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email không đúng xin thử lại!")]
        [Column(TypeName ="varchar")]
        [Required(ErrorMessage = "Hãy nhập email")]
        public string Email { get; set; }

        [Display(Name ="Quyền")]
        [DefaultValue(3)]
        public int Role { get; set; }

        [Display(Name = "Avartar")]
        public string Avartar { get; set; }

        public string UIDcode { get; set; }

        [Display(Name ="Ngày tạo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateCreate { get; set; }

        public virtual ICollection<News> Newss { get; set; }
    }
}