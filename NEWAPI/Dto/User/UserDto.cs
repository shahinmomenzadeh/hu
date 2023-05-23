using System.ComponentModel.DataAnnotations;
using Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NEWAPI.Dto.Todo;

namespace model.UserDto;

public class UserDto
{
    //    public EntityEntry<UserDto> Id { get; set; } --->    public int Id { get; set; }
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string lastname { get; set; }
    public int cardid { get; set; }
    
    public string ImageUrl { get; set; }
    public virtual ICollection<TodoDto> Todos { get; set; }
    
}