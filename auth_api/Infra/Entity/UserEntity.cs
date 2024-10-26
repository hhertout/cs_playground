using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace auth_api.Infra.Entity;

public class UserEntity(string email, string password)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; set; }  
    
    [Column("uid")]
    [StringLength(100)]
    public string Uid { get; set; } = Guid.NewGuid().ToString();

    [Column("email")]
    [StringLength(255)]
    [Required]
    public string Email { get; set; } = email;

    [Column("password")]
    [StringLength(255)]
    [Required]
    public string Password { get; set; } = password;
}