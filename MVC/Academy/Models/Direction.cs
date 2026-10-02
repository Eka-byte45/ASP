using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Academy.Models
{
    public class Direction
    {
        [Column("direction_id",TypeName ="TINYINT")]
        public int DirectionID {  get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Column(TypeName = "NVARCHAR(50)")]
        public string direction_name { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
