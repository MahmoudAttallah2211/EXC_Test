using CoreLayer.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApp.Entities.product
{
    public class Category : BaseEntity
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        
    }
}
