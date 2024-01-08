using AutoMapper;
using MediaExpert.Products.Application.Contracts.Persistence;
using MediaExpert.Products.Application.Exceptions;
using MediaExpert.Products.Domain.Entities;
using MediatR;

namespace MediaExpert.Application.Features.Products.Queries.GetProductDetail
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailVm>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public GetProductDetailQueryHandler(IMapper mapper, IAsyncRepository<Product> ProductRepository)
        {
            _mapper = mapper;
            _productRepository = ProductRepository;
        }

        public async Task<ProductDetailVm> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            var ProductDetailDto = _mapper.Map<ProductDetailVm>(product);


            return ProductDetailDto;
        }
    }
}
