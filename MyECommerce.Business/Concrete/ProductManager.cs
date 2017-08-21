using MyECommerce.Business.Abstract;
using MyECommerce.DataLayer.Abstract;
using MyECommerce.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace MyECommerce.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Add(Product category)
        {
            return _productRepository.Add(category);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetList().ToList();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.Get(m => m.Id == id);
        }

        public Product GetProductByUrlName(string urlName)
        {
            return _productRepository.Get(m => m.UrlName == urlName);
        }

        public List<Product> GetProductListByCategoryId(int categoryId)
        {
            return _productRepository.GetList(m => m.CategoryId ==categoryId).ToList();
        }

        public void Delete(Product product)
        {
            _productRepository.Delete(product);
        }

    }
}
