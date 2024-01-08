using AutoMapper;
using MediaExpert.Products.Application.Contracts.Persistence;
using MediaExpert.Products.Domain.Entities;
using MediatR;

namespace MediaExpert.Application.Features.Products.Queries.GetProductsList
{
    public class GetProductsListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductListVm>>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public GetProductsListQueryHandler(IMapper mapper, IAsyncRepository<Product> ProductRepository)
        {
            _mapper = mapper;
            _productRepository = ProductRepository;
        }

        public async Task<List<ProductListVm>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var allProducts = (await _productRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<ProductListVm>>(allProducts);
        }
    }
}
