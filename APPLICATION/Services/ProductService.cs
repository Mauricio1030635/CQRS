using APPLICATION.DTOs;
using APPLICATION.Interfaces;
using AutoMapper;
using DOMAIN.Entities;
using DOMAIN.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLICATION.Services
{
    public class ProductService : IProductService
    {
        private readonly Func<IUnitOfWork> _uowFactory;
        private readonly IMapper _mapper;

        public ProductService(Func<IUnitOfWork> uowFactory, IMapper mapper)
        {
            _uowFactory = uowFactory;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            using var uow = _uowFactory();
            var products = await uow.Products.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            using var uow = _uowFactory();
            var product = await uow.Products.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task CreateAsync(ProductDto dto)
        {
            using var uow = _uowFactory();
            var product = _mapper.Map<Product>(dto);
            await uow.Products.AddAsync(product);
            await uow.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductDto dto)
        {
            using var uow = _uowFactory();
            var product = _mapper.Map<Product>(dto);
            uow.Products.Update(product);
            await uow.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var uow = _uowFactory();
            var product = await uow.Products.GetByIdAsync(id);
            if (product == null) return;
            uow.Products.Remove(product);
            await uow.SaveChangesAsync();
        }
    }
}
