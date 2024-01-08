using AutoMapper;
using MediaExpert.Application.Features.Products.Queries.GetProductsList;
using MediaExpert.Products.Application.Contracts.Persistence;
using MediaExpert.Products.Application.Features.Products.Commands.CreateProduct;
using MediaExpert.Products.Application.Profiles;
using MediaExpert.Products.Domain.Entities;
using MediaExpert.Products.UnitTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaExpert.Products.UnitTests.Products.Commands
{
    public class CreateProductTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Product>> _mockProductRespository;
        public CreateProductTests()
        {
            _mockProductRespository = RepositoryMocks.GetProductRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();

        }
        [Fact]
        public async Task Handle_ValidProduct_AddedToCategoriesRepo()
        {
            //var handler = new CreateProductCommandHandler(_mapper, _mockProductRespository.Object);

            //await handler.Handle(new CreateProductCommand() { Name = "Test" }, CancellationToken.None);

            //var allProducts = await _mockProductRepository.Object.ListAllAsync();
            //allProducts.Count.ShouldBe(5);
        }
    }
}
