﻿using GeekShooping.Web.Models;
using GeekShooping.Web.Utils;


namespace GeekShooping.Web.Services.IServices
{
    public class ProductService : IProductService

    {
        private readonly HttpClient _client;

        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _client.GetAsync(BasePath);

            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");

            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            var response = await _client.PutAsJsonAsync(BasePath, model);
            Console.WriteLine($"{response} ---------- service update");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<ProductModel> CreateProduct(ProductModel product)
        {
            var response = await _client.PostAsJson(BasePath, product);

            if (response.IsSuccessStatusCode) return await response.ReadContentAs<ProductModel>();

            else throw new Exception("Algo deu erro ao chamar a API");
        }

        public async Task<bool> DeleteProductById(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");

            if (response.IsSuccessStatusCode) return await response.ReadContentAs<bool>();

            else throw new Exception($"Algo deu erro ao chamar a API {response.ReasonPhrase}");
        }

    }
}
