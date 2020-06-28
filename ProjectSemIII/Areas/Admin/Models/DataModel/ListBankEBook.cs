using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectSemIII.Areas.Admin.Models.DataModel
{
    [Table("ListBankEBook")]
    public class ListBankEBook
    {
        [Key]
        [Display(Name ="Mã")]
        public int Id { get; set; }

        [ForeignKey("Bank")]
        [Display(Name ="Mã ngân hàng")]
        public int BankId { get; set; }

        [Display(Name ="Số tài khoản")]
        [Required(ErrorMessage ="Số tài khoản ngân hàng không được để trống!")]
        [StringLength(20,ErrorMessage ="Tài khoản ngân hàng phải từ 8-20 ký tự",MinimumLength =8)]
        [Column(TypeName ="varchar")]
        public string AcBank { get; set; }

        public Bank Bank { get; set; }
    }
}