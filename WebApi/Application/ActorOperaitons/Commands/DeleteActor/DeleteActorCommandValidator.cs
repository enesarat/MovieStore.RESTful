using FluentValidation;
using WebApi.Application.ActorOperaitons.Commands.CreateActor;

namespace WebApi.Application.ActorOperaitons.Commands.DeleteActor
{
    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(command => command.ActorId).GreaterThan(0);
        }
    }
}
