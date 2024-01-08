using AutoMapper;
using MediaExpert.Products.Application.Contracts.Persistence;
using MediaExpert.Products.Application.Exceptions;
using MediaExpert.Products.Domain.Entities;
using MediatR;

namespace MediaExpert.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IMapper mapper, IAsyncRepository<Product> ProductRepository)
        {
            _mapper = mapper;
            _productRepository = ProductRepository;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var ProductToUpdate = await _productRepository.GetByIdAsync(request.ProductId);
            if (ProductToUpdate == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            var validator = new UpdateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, ProductToUpdate, typeof(UpdateProductCommand), typeof(Product));

            await _productRepository.UpdateAsync(ProductToUpdate);

        }
    }
}