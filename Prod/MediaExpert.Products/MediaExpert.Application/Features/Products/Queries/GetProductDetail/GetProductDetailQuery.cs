using MediatR;

namespace MediaExpert.Application.Features.Products.Queries.GetProductDetail
{
    public class GetProductDetailQuery : IRequest<ProductDetailVm>
    {
        public Guid Id { get; set; }
    }
}
