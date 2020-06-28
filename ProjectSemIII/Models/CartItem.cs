using ProjectSemIII.Areas.Admin.Models.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectSemIII.Models
{
    
    public class CartItem
    {
        [Key]
        [Display(Name = "Mã sách")]
        public string BookId { get; set; }
        [Display(Name = "Tên sách")]
        public string Title { get; set; }
        [Display(Name = "Ảnh")]
        public string Picture { get; set; }
        [Display(Name = "Giá")]
        public float? Price { get; set; }
       
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
        [Display(Name = "Thành tiền")]
        public double? TotalMoney { get; set; }
    }
}