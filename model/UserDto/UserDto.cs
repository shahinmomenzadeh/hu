using System.ComponentModel.DataAnnotations;

namespace model.UserDto;

public class UserDto
{
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    
}