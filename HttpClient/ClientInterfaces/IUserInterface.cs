using Shared.DTOs;
using Shared.Models;

namespace HttpClient.ClientInterfaces;

public interface IUserInterface
{
    Task<User> Create(UserCreationDto dto);
}