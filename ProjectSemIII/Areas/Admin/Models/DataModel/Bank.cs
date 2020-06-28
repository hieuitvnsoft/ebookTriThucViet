using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectSemIII.Areas.Admin.Models.DataModel
{
    [Table("Banks")]
    public class Bank
    {
        [Key]
        [Display(Name ="Mã ngân hàng")]
        public int BankId { get; set; }

        [Required(ErrorMessage ="Hãy nhập tên ngân hàng")]
        [StringLength(250,ErrorMessage ="Nhập tên ngân hàng 6 - 250 ký tự",MinimumLength =6)]
        [Display(Name = "Tên ngân hàng")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Hãy nhập Link Service")]
        [StringLength(250, ErrorMessage = "Nhập Link Service 6 - 250 ký tự", MinimumLength = 6)]
        [Display(Name = "Link Service")]
        public string StringBankSevice { get; set; }

        [Required(ErrorMessage = "Hãy nhập địa chỉ ngân hàng")]
        [StringLength(250, ErrorMessage = "Nhập địa chỉ ngân hàng 6 - 250 ký tự", MinimumLength = 6)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Số điện thoại")]
        public string BankPhone { get; set; }

        [Display(Name = "Email")]
        public string BankEmail { get; set; }
        public virtual ICollection<ListBankEBook> ListBankEBooks { get; set; }
    }
}