using Shared.DTOs;
using Shared.Models;

namespace HttpClientStuff.ClientInterfaces;

public interface ITodoService
{
    Task Create(TodoCreationDto dto);
    
    Task<ICollection<Todo>> GetAsync(
        string? userName, 
        int? userId, 
        bool? completedStatus, 
        string? titleContains
    );

    Task UpdateAsync(TodoUpdateDto dto);
    Task<TodoBasicDto> GetByIdAsync(int id);
}