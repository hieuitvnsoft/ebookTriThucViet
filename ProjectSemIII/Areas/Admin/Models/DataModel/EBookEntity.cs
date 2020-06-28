using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectSemIII.Areas.Admin.Models.DataModel
{
    public class EBookEntity:DbContext
    {
        public EBookEntity() : base("name=EBookConnectString")
        {

        }
        //khai báo thuộc tính map với các tables
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Ads> Adss { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ListBankEBook> ListBankEBook { get; set; }
        public DbSet<MessageTransition> MessageTransitions { get; set; }
        public DbSet<News> Newss { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<Slideshow> Slideshows { get; set; }
        public DbSet<TransitionMethod> TransitionMethods { get; set; }
    }
}