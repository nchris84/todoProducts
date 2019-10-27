namespace todoProducts.DataAccess.Entity
{
    public interface IPocoRemovable : IPocoUpdate
    {
        bool? IsActive { get; set; }
    }
}