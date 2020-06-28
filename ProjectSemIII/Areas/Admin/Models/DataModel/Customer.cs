using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectSemIII.Areas.Admin.Models.DataModel
{
    [Table("Customers")]
    public class Customer
    {

        [Key]
        [Display(Name = "Mã khách hàng")]
        public int CustomerId { get; set; }

        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Hãy nhập tài khoản của bạn")]
        [Column(TypeName = "varchar")]
        [StringLength(30, ErrorMessage = "Họ và tên từ 6 - 30 ký tự ", MinimumLength = 6)]
        public string Username { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Hãy nhập mật khẩu của bạn")]
        [Column(TypeName = "varchar")]
        [StringLength(256, ErrorMessage = "Mật khẩu tối thiểu 6 ký tự", MinimumLength = 6)]
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
        [Required(ErrorMessage = "Hãy nhập ngày sinh của bạn")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        [Display(Name = "Số điện thoại")]
        [RegularExpression(@"^\d{10,12}$", ErrorMessage = "Số điện thoại không đúng định dạng")]
        [Required(ErrorMessage = "Hãy nhập số điện thoại của bạn")]
        public string Phone { get; set; }


        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Email của bạn không đúng xin thử lại!")]
        [Required(ErrorMessage = "Hãy nhập email của bạn")]
        public string Email { get; set; }

      

        [Display(Name = "Số Emoney")]
        [DefaultValue(0)]
        public float? EMoney { get; set; }

        [Display(Name = "Avartar")]
        public string Avartar { get; set; }

        public string UIDcode { get; set; }

        //thuộc tính navigation
        
        public virtual ICollection<MessageTransition> MessageTransitions { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
