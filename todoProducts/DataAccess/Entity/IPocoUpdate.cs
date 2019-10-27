using System;

namespace todoProducts.DataAccess.Entity
{
    public interface IPocoUpdate
    {
        DateTime? UpdateDate { get; set; }
    }
}