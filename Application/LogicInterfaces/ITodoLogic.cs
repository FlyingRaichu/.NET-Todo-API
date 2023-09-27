using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface ITodoLogic
{
    Task<Todo> CreateAsync(TodoCreationDto dto);
    Task<IEnumerable<Todo>> GetAsync(SearchTodoParametersDto searchParameters);
    Task UpdateAsync(TodoUpdateDto dto);
    Task DeleteAsync(int id);

    Task<TodoBasicDto> GetByIdAsync(int id);
}