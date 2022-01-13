using Restore.Core.Data.Repository;
using Xunit;
using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSubstitute;
using System.Threading.Tasks;
using Restore.Core.Models;

namespace Restore.Tests;

public class UnitTest1
{
    private readonly IProductRepository _productRepository =
        Substitute.For<IProductRepository>();


    [Fact]
    public async Task  GetProductById()
    {
        var product = new Product{
            ProductId = 5,
            Name = "React Board Super Whizzy Fast",
            Description =
                "Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
            Price = 25000,
            PictureUrl = "/images/products/sb-react1.png",
            Brand = "React",
            Type = "Boards",
            QuantityInStock = 100
        };
        
    }

    internal class RestoreTestFactory : WebApplicationFactory<Program>
    {
        private readonly Action<IServiceCollection> _serviceOverride;
        public RestoreTestFactory(Action<IServiceCollection> serviceOverride)
        {
            _serviceOverride = serviceOverride;
        }
        protected override IHost CreateHost(IHostBuilder builder)
        {
            // Add mock/test services to the builder here
            builder.ConfigureServices(_serviceOverride);

            return base.CreateHost(builder);
        }
    }
}
