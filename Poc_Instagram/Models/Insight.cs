using System.ComponentModel.DataAnnotations;

namespace Poc_Instagram.Models
{
    public class Insight
    {
        [Key]
        public long IdInsight { get; set; }
        public long Name { get; set; }
    }
}
