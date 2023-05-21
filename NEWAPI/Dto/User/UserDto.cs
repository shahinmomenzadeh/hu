using System.ComponentModel.DataAnnotations;
using Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace model.UserDto;

public class UserDto
{
    public EntityEntry<User> Id { get; set; }
    
    public string Name { get; set; }
    public string lastname { get; set; }
    public int cardid { get; set; }
    
    public string ImageUrl { get; set; }
    
    
}