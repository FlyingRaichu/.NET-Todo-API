using Application.DaoInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace FIleData.DAOs;

public class TodoFileDao : ITodoDao
{
    private readonly FileContext context;


    public TodoFileDao(FileContext context)
    {
        this.context = context;
    }


    public Task<Todo> CreateAsync(Todo todo)
    {
        int todoId = 1;

        if (context.Todos.Any())
        {
            todoId = context.Todos.Max(t => t.Id);
            todoId++;
        }

        todo.Id = todoId;

        context.Todos.Add(todo);
        context.SaveChanges();

        return Task.FromResult(todo);
    }

    public Task<IEnumerable<Todo>> GetAsync(SearchTodoParametersDto searchParameters)
    {
        IEnumerable<Todo> todos = context.Todos.AsEnumerable();
        if (!string.IsNullOrEmpty(searchParameters.Username))
        {
            todos = context.Todos.Where(t =>
                t.Owner.UserName.Equals(searchParameters.Username, StringComparison.OrdinalIgnoreCase));
        }

        if (searchParameters.UserId != null)
        {
            todos = todos.Where(t => t.Owner.Id == searchParameters.UserId);
        }

        if (searchParameters.CompletedStatus != null)
        {
            todos = todos.Where(t => t.IsCompleted == searchParameters.CompletedStatus);
        }

        if (!string.IsNullOrEmpty(searchParameters.TitleContains))
        {
            todos = todos.Where(t =>
                t.Title.Contains(searchParameters.TitleContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(todos);
    }

    public Task UpdateAsync(Todo todo)
    {
        Todo? existing = context.Todos.FirstOrDefault(t => t.Id == todo.Id);
        if (todo == null)
        {
            throw new Exception($"Todo with id {todo.Id} does not exist!");
        }

        context.Todos.Remove(existing);
        context.Todos.Add(todo);

        context.SaveChanges();

        return Task.CompletedTask;
    }

    public Task<Todo> GetByIdAsync(int id)
    {
        Todo? todo = context.Todos.FirstOrDefault(t => t.Id == id);
        return Task.FromResult<Todo>(todo);
    }

    public Task DeleteAsync(int id)
    {
        Todo? todo = context.Todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            throw new Exception($"Todo with ID {id} does not exist!");
        }
        context.Todos.Remove(todo);
        context.SaveChanges();
        
        return Task.CompletedTask;
    }
}