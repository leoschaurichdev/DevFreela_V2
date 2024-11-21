using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.UserCommands.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _repository;
        public LoginUserHandler(IAuthService authService, IUserRepository repository)
        {
            _authService = authService;
            _repository = repository;
        }
        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _repository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user == null)
            {
                return null;
            }

            //se existir gero o token usando os dados do usuário
            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new LoginUserViewModel(user.Email, token);
        }

    }
}