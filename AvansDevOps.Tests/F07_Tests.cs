using AvansDevOps.Domain;
using AvansDevOps.Domain.Adapters;
using AvansDevOps.Domain.Composites.PipelineComposite;
using AvansDevOps.Domain.Factories.UserFactory;
using AvansDevOps.Domain.Users;
using AvansDevOps.Domain.Visitors.PipelineVisitor;
using Moq;
using Action = AvansDevOps.Domain.Composites.PipelineComposite.Action;

namespace AvansDevOps.Tests
{
    public class F07_Tests
    {
        [Fact]
        public void F07_1_1_Should_ThrowWhenCreatingPipelineWithoutPipelineComponents()
        {
            // Arrange
            UserFactory factory = new ProductOwnerUserFactory();
            User po = factory.CreateUser("po", "po@mail.com", "po-slack");
            var project = new Project("Test Project", Mock.Of<IVersionControlAdapter>(), (ProductOwner)po);
            Dictionary<Category, List<Action>> pipelineComponents = null; // No components provided

            // Act & Assert
            Assert.Throws<ArgumentException>(() => project.CreatePipeline("Test Pipeline", pipelineComponents, new ExecuteVisitor()));
        }

        [Fact]
        public void F07_1_2_Should_CreatePipelineWithNoCategories()
        {
            // Arrange
            UserFactory factory = new ProductOwnerUserFactory();
            User po = factory.CreateUser("po", "po@mail.com", "po-slack");
            var project = new Project("Test Project", Mock.Of<IVersionControlAdapter>(), (ProductOwner)po);
            var pipelineComponents = new Dictionary<Category, List<Action>>(); // Empty dictionary

            // Act
            project.CreatePipeline("Test Pipeline", pipelineComponents, new ExecuteVisitor());
            List<PipelineComponent> categories = project.Pipeline.GetPipelineComponents();

            // Assert
            Assert.Empty(categories);
        }

        [Fact]
        public void F07_1_3_Should_CreatePipelineWithCategoriesAndWithoutActions()
        {
            // Arrange
            UserFactory factory = new ProductOwnerUserFactory();
            User po = factory.CreateUser("po", "po@mail.com", "po-slack");
            var project = new Project("Test Project", Mock.Of<IVersionControlAdapter>(), (ProductOwner)po);
            var pipelineComponents = new Dictionary<Category, List<Action>>
            {
                { new Category("Category 1"), new List<Action>() }, // Category without actions
                { new Category("Category 2"), new List<Action>() }  // Another category without actions
            };

            // Act
            project.CreatePipeline("Test Pipeline", pipelineComponents, new ExecuteVisitor());
            PipelineComposite category = (PipelineComposite)project.Pipeline.GetPipelineComponents()[0];

            // Assert
            Assert.Empty(category.GetPipelineComponents());
        }

        [Fact]
        public void F07_1_4_Should_CreatePipelineWithCategoriesAndWithActions()
        {
            // Arrange
            UserFactory factory = new ProductOwnerUserFactory();
            User po = factory.CreateUser("po", "po@mail.com", "po-slack");
            var project = new Project("Test Project", Mock.Of<IVersionControlAdapter>(), (ProductOwner)po);
            var action1 = new Action("Action 1");
            var category1 = new Category("Category 1");
            var pipelineComponents = new Dictionary<Category, List<Action>>
            {
                { category1, new List<Action> { action1 } }
            };

            // Act
            project.CreatePipeline("Test Pipeline", pipelineComponents, new ExecuteVisitor());
            PipelineComposite category = (PipelineComposite)project.Pipeline.GetPipelineComponents()[0];

            // Assert
            Assert.Single(category.GetPipelineComponents());
        }
    }
}