using FluentValidation;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;

namespace WebApi.Application.OrderOperations.Queries.GetOrderDetail
{
    public class GetOrderDetailQueryValidator : AbstractValidator<GetOrderDetailQuery>
    {
        public GetOrderDetailQueryValidator()
        {
            RuleFor(query => query.OrderId).GreaterThan(0);
        }
    }
}
