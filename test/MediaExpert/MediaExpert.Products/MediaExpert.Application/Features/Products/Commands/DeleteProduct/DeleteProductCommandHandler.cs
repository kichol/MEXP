using AutoMapper;
using MediaExpert.Products.Application.Contracts.Persistence;
using MediaExpert.Products.Application.Exceptions;
using MediaExpert.Products.Application.Features.Products.Commands.DeleteProduct;
using MediaExpert.Products.Domain.Entities;
using MediatR;

namespace MediaExpert.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeleteProductCommandResponse>
    {
        private readonly IAsyncRepository<Product> _ProductRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IMapper mapper, IAsyncRepository<Product> ProductRepository)
        {
            _mapper = mapper;
            _ProductRepository = ProductRepository;
        }

        

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var ProductToDelete = await _ProductRepository.GetByIdAsync(request.ProductId);
            var deleteProductCommandResponse = new DeleteProductCommandResponse();

            if (ProductToDelete == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            deleteProductCommandResponse.ProductId = request.ProductId;

            await _ProductRepository.DeleteAsync(ProductToDelete);
            return deleteProductCommandResponse;

        }

        
    }
}
