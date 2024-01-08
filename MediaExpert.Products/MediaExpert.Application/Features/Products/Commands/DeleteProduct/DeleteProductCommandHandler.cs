using AutoMapper;
using MediaExpert.Products.Application.Contracts.Persistence;
using MediaExpert.Products.Application.Exceptions;
using MediaExpert.Products.Domain.Entities;
using MediatR;

namespace MediaExpert.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IAsyncRepository<Product> _ProductRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IMapper mapper, IAsyncRepository<Product> ProductRepository)
        {
            _mapper = mapper;
            _ProductRepository = ProductRepository;
        }

        

        async Task IRequestHandler<DeleteProductCommand>.Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var ProductToDelete = await _ProductRepository.GetByIdAsync(request.ProductId);

            if (ProductToDelete == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            await _ProductRepository.DeleteAsync(ProductToDelete);

        }
    }
}
