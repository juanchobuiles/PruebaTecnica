using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Core.UseCases.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository, ILogger<CreateUserCommandHandler> logger)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);  

            _userRepository.Add(user);
            var result = await _userRepository.Complete();
            if (result <= 0)
            {
                _logger.LogError("No se pudo insertar la categoria");
                throw new Exception("Ocurrio un error al crear la Categoria");
            }

            return user.Id.ToString();
        }
    }
}
