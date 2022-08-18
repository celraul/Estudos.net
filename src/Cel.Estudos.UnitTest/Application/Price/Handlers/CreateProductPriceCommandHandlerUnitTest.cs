using Cel.Estudos.Application.Price.Commands;
using Cel.Estudos.Application.Price.Handlers;
using Cel.Estudos.CoreDomain.Notification;
using Cel.Estudos.CoreDomain.Specification;
using Cel.Estudos.Domain.Price.Entity;
using Cel.Estudos.Domain.Price.Repositories;
using Cel.Estudos.Infra.Data.Data;
using FluentValidation;
using MediatR;
using Moq;
using Xunit;

namespace Cel.Estudos.UnitTest.Application.Price.Handlers
{
    public class CreateProductPriceCommandHandlerUnitTest
    {
        private CreateProductPriceCommandHandler _handler;
        private Mock<INotificationContext> _notifcation;

        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IValidator<CreateProductPriceCommand>> _validator;
        private Mock<ISpecificator<ProductPrice>> _productPriceSpecificator;
        private Mock<IProductPriceRepository> _priceRepository;
        private Mock<IMediator> _mediator;

        public CreateProductPriceCommandHandlerUnitTest()
        {
            Setup();
        }

        public void Setup()
        {
            _notifcation = new Mock<INotificationContext>();
            _validator = new Mock<IValidator<CreateProductPriceCommand>>();
            _productPriceSpecificator = new Mock<ISpecificator<ProductPrice>>();
            _priceRepository = new Mock<IProductPriceRepository>();
            _mediator = new Mock<IMediator>();

            _handler = new CreateProductPriceCommandHandler(_notifcation.Object, _unitOfWork.Object, _validator.Object,
                                                            _productPriceSpecificator.Object, _priceRepository.Object,
                                                            _mediator.Object);
        }

        [Fact]
        public async Task Handle_CreateProductPriceCommand_true()
        {
            //Arrange
            var command = new CreateProductPriceCommand();

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert 
            Assert.True(result);
        }
    }
}