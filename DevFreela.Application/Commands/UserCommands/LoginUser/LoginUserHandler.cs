using DevFreela.Application.Commands.UserCommands.LoginUser;
using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.UsersCommands.LoginUser
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
            //utilizar o mesmo algoritmo para criar o hash dessa senha
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            //buscar no meu banco um User que tenha meu email e minha senha em formato hash
            var user = await _repository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            //verifica as informações se existem, se não exister, erro no login
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