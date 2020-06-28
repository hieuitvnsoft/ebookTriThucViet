using ProjectSemIII.Areas.Admin.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSemIII.Models
{
    public class ProductDao
    {
        EBookEntity db = new EBookEntity();
        public  Book ViewProductDetail(string id)
        {
            Book book = db.Books.FirstOrDefault(x => x.BookId == id);
            
                return book;
           
        }
    }
}