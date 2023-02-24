﻿using FluentValidation;
using WebApi.Application.MovieOperations.Commands.DeleteMovie;

namespace WebApi.Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(command => command.OrderId).GreaterThan(0);
        }
    }
}
