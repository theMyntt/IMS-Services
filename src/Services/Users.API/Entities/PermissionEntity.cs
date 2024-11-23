using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Users.API.Entities;

[Table("TBL_PERMISSIONS")]
public class PermissionEntity
{
    [Key]
    [Column("ID_PERMISSION")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int Id { get; set; }
    
    [Column("TX_NAME")]
    public required string Name { get; set; }
    
    [Column("TX_CODE")]
    public required string Code { get; set; }
    
    [Column("TX_CREATE")]
    public required DateTime CreatedAt { get; set; }
    
    [Column("TX_LAST_UPDATE")]
    public DateTime? UpdatedAt { get; set; }
    
    public ICollection<UserPermissionsEntity> UsersPermissions { get; set; }
}