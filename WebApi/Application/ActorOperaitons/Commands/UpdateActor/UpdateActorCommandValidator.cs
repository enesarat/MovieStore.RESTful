using FluentValidation;

namespace WebApi.Application.ActorOperaitons.Commands.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(command => command.ActorId).GreaterThan(0);
        }
    }
}
