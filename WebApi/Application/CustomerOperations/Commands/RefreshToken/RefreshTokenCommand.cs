using WebApi.DbOperations;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.CustomerOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommand(IMovieStoreDbContext dbContext, IConfiguration mapper)
        {
            _context = dbContext;
            _configuration = mapper;
        }

        public Token Handle()
        {
            var customer = _context.Customers.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpirationDate > DateTime.Now);
            if (customer != null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccesToken(customer);

                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpirationDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();

                return token;

            }
            else
            {
                throw new InvalidOperationException("Valid refresh token could not found!");
            }
        }
    }
}
