using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class Group
    {
        [Key]
        public int group_id {  get; set; }

        [Required]
        public string group_name {  get; set; }

        [Required]
        [Column(TypeName ="TINYINT")]

        [ForeignKey(nameof(Direction))]
        public int direction { get; set; }
        public Direction? Direction { get; set; }

        public int weekdays {  get; set; }
        public TimeOnly start_time { get; set; }
        public DateOnly start_date { get; set; }

        
    }
}
