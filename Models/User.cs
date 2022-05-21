using System.ComponentModel.DataAnnotations;

namespace Lesson1.Models;
public class User
{
    public string Name { get; set;}
    public string LastName { get; set; }
    [Key]
    public Guid ID { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    
}
