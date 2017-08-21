using MyECommerce.Entities.Concrete;
using System.Collections.Generic;

namespace MyECommerce.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();

        Product Add(Product product);

        Product GetProductById(int id);

        List<Product> GetProductListByCategoryId(int categoryId);

        Product GetProductByUrlName(string urlName);

        void Delete(Product product);

    }
}
