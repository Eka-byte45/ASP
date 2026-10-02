using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy2.Models
{
    public class Direction
    {
        [Column("direction_id",TypeName = "TINYINT")]
        public int DirectionID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Column(TypeName = "NVARCHAR(50)")]
        public string direction_name { get; set; }

        //Novigation properties:
        //public ICollection<Group> Groups { get; set; }
    }
}
