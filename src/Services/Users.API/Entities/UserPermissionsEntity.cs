using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Users.API.Entities;

[Table("TBL_USERS_PERMISSIONS")]
public class UserPermissionsEntity
{
    [Key]
    [Column("ID_USER_PERMISSION")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int Id { get; set; }
    
    [ForeignKey("UserEntity")]
    [Column("TX_USER_FK")]
    public required int UserId { get; set; }
    public required UserEntity User { get; set; }
    
    [ForeignKey("PermissionEntity")]
    [Column("TX_PERMISSION_FK")]
    public required int PermissionId { get; set; }
    public required PermissionEntity Permission { get; set; }
}