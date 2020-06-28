using PagedList;
using ProjectSemIII.Areas.Admin.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSemIII.Areas.Admin.Models.BussinessModel
{
    public class UserDao
    {
        EBookEntity db = new EBookEntity();
        public IEnumerable<Book> ListAllPaging(int page, int pageSize)
        {
            var books = db.Books.ToList();
            return books.ToPagedList(page, pageSize);
        }
        public static string GenUID()
        {
            Guid g;
            g = Guid.NewGuid();
            return g.ToString();
        }

       
        public List<CategoryItem> LoadCategory()
        {
            List<CategoryItem> list = new List<CategoryItem>();
            CategoryItem all = new CategoryItem { ID = 0, Name = "========Tất cả=========" };
            list.Add(all);
            var cate = db.Categorys.ToList();
            if (cate != null)
            {
                foreach (var item in cate)
                {
                    CategoryItem i = new CategoryItem();
                    i.ID = item.CategoryId;
                    i.Name = item.CategoryName;
                    list.Add(i);
                }
            }
            return list;
        }
    }
}