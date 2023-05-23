using System.ComponentModel.DataAnnotations;

namespace Entity;

public class User
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string lastname { get; set; }
    public int cardid { get; set; }
    public string ImageUrl { get; set; }
    public virtual ICollection<Todo> Todos { get; set; }
    
}