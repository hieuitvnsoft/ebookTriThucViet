using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectSemIII.Areas.Admin.Models.DataModel
{
    [Table ("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [Display(Name ="Mã")]
        public int OrderDetailId { get; set; }

        [ForeignKey("Order")]
        [Display(Name ="Mã đặt hàng")]
        public int OrderId { get; set; }

        [ForeignKey("Book")]
        [Display(Name = "Mã sách")]
        public string BookId { get; set; }

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        [Display(Name = "Giá")]
        public float Price { get; set; }

        [Display(Name = "Thành tiền")]
        public float SubTotal { get; set; }

        public Book Book { get; set; }
        public Order Order { get; set; }
       
    }
}