using EntityLayer.WebApp.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApp.ViewModels.Product
{
    public class ProductListVM
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public required CategoryListVM Category { get; set; }
        public  DateTime CreationDate { get; set; }
        public  required string CreatedByUserId { get; set; }
        public required string ImagePath { get; set; }
    }
}
