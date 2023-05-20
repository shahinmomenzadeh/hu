using System.ComponentModel.DataAnnotations;

namespace model.UserDto;

public class UserDto
{
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    public string lastname { get; set; }
    public int cardid { get; set; }
}