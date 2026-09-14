using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class Direction
    {
        [Key]
        [Column(TypeName = "TINYINT")]
        public int direction_id { get; set; }

        [Required]
        public string direction_name { get; set; }

        //public ICollection<Group> Group { get; set; }
        public List<Group> Groups { get; set; } = new();
    }
}
