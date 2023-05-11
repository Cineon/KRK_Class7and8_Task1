using KRK_Class7_Task1.Models.Views;

namespace KRK_Class7_Task1.Abstracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductListViewModel>> GetAll();
    }
}
