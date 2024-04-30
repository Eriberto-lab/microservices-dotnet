using GeekShopping.ProductAPI.Data.ValueObjects;

namespace GeekShopping.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> FindAll();

        Task<ProductVO> FindById(long id);

        Task<ProductVO> Create(ProductVO newProduct);

        Task<ProductVO> Update(ProductVO newProduct);

        Task<bool> Delete(long id);   
    }
}
