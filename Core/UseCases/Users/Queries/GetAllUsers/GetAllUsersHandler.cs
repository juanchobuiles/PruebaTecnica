using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Core.UseCases.Users.Queries.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;
        public readonly ILogger<GetAllUsersQuery> _logger;
        public readonly IMapper _mapper;

        public GetAllUsersHandler(IUserRepository userRepository, ILogger<GetAllUsersQuery> logger, IMapper mapper)
        {
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                return users.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocurrió un error consultando las unidades de medidas {ex}");
                throw new Exception($"Ocurrió un error {ex.Message}");
            }

        }
    }
}
