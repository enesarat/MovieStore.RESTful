using FluentValidation;

namespace WebApi.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(o => o.Model.MovieId).NotEmpty();
            RuleFor(o => o.Model.CustomerId).NotEmpty();
        }
    }
}
