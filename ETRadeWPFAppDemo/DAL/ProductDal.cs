using ETRadeWPFAppDemo.Context;
using ETRadeWPFAppDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ETRadeWPFAppDemo.DAL
{
    public class ProductDal
    {
        public List<Product> ListByName(string key)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var filteredProducts = context.Products.Where(p => p.ProductName.Contains(key)).ToList();
                return filteredProducts;
            }
        }

        public List<Product> GetByCategory(int categoryId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.Where(p => p.CategoryID == categoryId).ToList();
            }
        }


        public List<Category> GetCategories()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Categories.ToList();

            }
        }


        public List<Product> GetAllProducts()
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }









        
    }
}
