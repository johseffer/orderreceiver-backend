using OrderReceiver.Domain.Interfaces.Service;
using OrderReceiver.Domain.Interfaces.Repository;
using OrderReceiver.Domain.Entities;
using System.Linq;
using OrderReceiver.Domain.DTO.Order;
using System.Collections.Generic;
using AutoMapper;

namespace OrderReceiver.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _ProductRepository;

        public ProductService(IProductRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            _ProductRepository.Dispose();
        }

        public List<ProductGetDTO> GetProductByNameWith(string name)
        {
            return _ProductRepository.GetAll()
                .Where(x => x.Name.ToUpper().Contains(name.ToUpper()))
                .Select(obj => _mapper.Map<Product, ProductGetDTO>(obj))
                .ToList();
        }
    }
}
