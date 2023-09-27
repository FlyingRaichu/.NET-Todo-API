using Shared.Models;

namespace FIleData;

public class DataContainer
{
    public ICollection<User> Users { get; set; }
    public ICollection<Todo> Todos { get; set; }
}