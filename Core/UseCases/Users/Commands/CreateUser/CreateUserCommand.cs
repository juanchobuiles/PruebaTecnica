using MediatR;

namespace Core.UseCases.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<string>
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Edad { get; set; } 
    }
}
