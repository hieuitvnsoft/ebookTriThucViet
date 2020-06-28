using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectSemIII.Areas.Admin.Models.DataModel
{
    [Table("Orders")]
    public class Order
    {
       [Key]
       [Display(Name ="Mã đặt hàng")]
        public int OrderId { get; set; }

        [ForeignKey("Customer")]
        [Display(Name = "Mã khách hàng")]
        public int CustomerId { get; set; }

        [ForeignKey("TransitionMethod")]
        [Display(Name = "Mã khách hàng")]
        public int TransitionId { get; set; }

        [ForeignKey("ShippingMethod")]
        [Display(Name = "Mã khách hàng")]
        public int ShippingId { get; set; }

        [Display(Name ="Chú thích")]
        public string Note { get; set; }

        [Display(Name = "Ngày đặt hàng")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOrder { get; set; }

        [Display(Name = "Tổng tiền đơn hàng")]
        public float TotalPayment { get; set; }

        [Display(Name = "Trạng thái")]
        [DefaultValue(0)]
        public int Status { get; set; }

        public Customer Customer { get; set; }

        public ShippingMethod ShippingMethod { get; set; }

        public TransitionMethod TransitionMethod { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}