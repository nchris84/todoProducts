using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoProducts.DataAccess.Entity
{
    public interface IPocoUpdate
    {
        DateTime? UpdateDate { get; set; }
    }
}