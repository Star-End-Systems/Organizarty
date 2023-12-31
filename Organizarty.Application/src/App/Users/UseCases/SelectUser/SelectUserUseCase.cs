using Organizarty.Application.App.Users.Entities;
using Organizarty.Application.App.Users.Data;

namespace Organizarty.Application.App.Users.UseCases;

public class SelectUserUseCase
{
    private readonly IUserRepository _userRepository;
    public SelectUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> GetUserId(string id)
        => await _userRepository.FindById(id);
    
}
