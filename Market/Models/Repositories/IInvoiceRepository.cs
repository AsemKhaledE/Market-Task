using Market.ViewModel;

namespace Market.Models.Repositories
{
    public interface IInvoiceRepository
    {
        List<ProductViewModel> List();

        int Add(ProductViewModel product);

        List<ProductListViewModel> GetProductListByInvoiceId(int invoiceId); 
    }
}
