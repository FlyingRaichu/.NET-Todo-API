using HttpClient.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HttpClient.Implementations;

public class UserHttpClient : IUserInterface
{
    private readonly HttpClient client;

    public UserHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public Task<User> Create(UserCreationDto dto)
    {
        throw new NotImplementedException();
    }
}