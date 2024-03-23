using AvansDevOps.Domain.Adapters;
using AvansDevOps.Domain.Factories.UserFactory;
using AvansDevOps.Domain.Users;
using AvansDevOps.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Tests
{
    public class F01_Tests
    {
        [Fact]
        public void F01_1_Should_CreateProject()
        {
            // Arrange
            UserFactory factory = new ProductOwnerUserFactory();
            User po = factory.CreateUser("po", "po@mail.com", "po-slack");
            string name = "Test Project";

            // Act
            var project = new Project(name, Mock.Of<IVersionControlAdapter>(), (ProductOwner)po);

            // Assert
            Assert.Equal(name, project.Name);
            Assert.IsType<ProductOwner>(project.ProductOwner);
        }
    }
}
