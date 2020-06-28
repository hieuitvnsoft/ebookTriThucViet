using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSemIII.Areas.Admin.Models.DataModel
{
    [Table("TransitionMethods")]
    public class TransitionMethod
    {
        [Key]
        [Display(Name = "Mã")]
        public int TransitionId { get; set; }

        [Display(Name = "Tên phương thức")]
        [Required(ErrorMessage ="Hãy nhập tên phương thức thanh toán")]
        [StringLength(60, ErrorMessage = "Mật khẩu từ 6 - 60 ký tự ", MinimumLength = 6)]
        public string TransitionName { get; set; }

        [Column(TypeName = "ntext")]
        [AllowHtml]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}