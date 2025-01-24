using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.BaseEntities
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime CreationDate { get; set; }
        string CreatedByUserId { get; set; }
        string ImagePath { get; set; }
    }
}
