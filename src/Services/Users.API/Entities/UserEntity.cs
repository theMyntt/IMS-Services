using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Users.API.Entities;

[Table("TBL_USERS")]
public class UserEntity
{
    [Key]
    [Column("ID_USER")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int Id { get; set; }
    
    [Column("TX_NAME")]
    public required string Name { get; set; }
    
    [Column("TX_EMAIL")]
    public required string Email { get; set; }
    
    [Column("TX_PASSWORD")]
    public required string Password { get;set; }
    
    [Column("TX_CREATE")]
    public required DateTime CreatedAt { get; set; }
    
    [Column("TX_LAST_UPDATE")]
    public DateTime? UpdatedAt { get; set; }
    
    public ICollection<UserPermissionsEntity>? UserPermissions { get; set; }
}