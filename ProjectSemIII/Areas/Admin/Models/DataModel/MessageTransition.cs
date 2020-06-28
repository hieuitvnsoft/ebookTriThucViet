using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectSemIII.Areas.Admin.Models.DataModel
{
    [Table("MessageTransitions")]
    public class MessageTransition
    {
        [Key]
        [Display(Name ="Mã giao dịch")]
        public int Id { get; set; }

        [Display(Name ="Mã ngân hàng")]
        public int BankId { get; set; }

        [ForeignKey("Customer")]
        [Display(Name ="Mã khách hàng")]
        public int CustomerId { get; set; }

        [Display(Name ="Nội dung giao dịch")]
        public string Description { get; set; }

        [DefaultValue(0)]
        [Display(Name = "Số tiền nhận")]
        public float Amount { get; set; }

        [DefaultValue(0)]
        [Display(Name ="Số dư hiện tại")]
        public float AccountHoder { get; set; }

       
        [Display(Name = "Thời gian gửi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? TimeTrans { get; set; }

        [DefaultValue(false)]
        public bool Status { get; set; }

        public Customer Customer { get; set; }
        
    }
}