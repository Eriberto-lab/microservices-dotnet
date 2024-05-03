using GeekShooping.Web.Models;

namespace GeekShooping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllProducts();

        Task<ProductModel> FindProductById(long id);

        Task<ProductModel> UpdateProductById(ProductModel product);

        Task<ProductModel> CreateProduct(ProductModel product);

        Task<bool> DeleteProductById(long id);


    }
}
