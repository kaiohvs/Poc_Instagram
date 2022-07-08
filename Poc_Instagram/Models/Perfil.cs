using System.ComponentModel.DataAnnotations;

namespace Poc_Instagram.Models
{
    public class Perfil
    {
        [Key]
        public long IdPerfil { get; set; }
        public string Name { get; set; }
    }
}
