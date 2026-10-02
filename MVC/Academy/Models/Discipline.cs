using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class Discipline
    {
        [Column("discipline_id",TypeName = "SMALLINT")]
        public int DisciplineID { get; set; }

        [Required]
        public string discipline_name { get; set; }
        [Required]
        [Column(TypeName = "TINYINT")]
        public int number_of_lessons { get; set; }

        public ICollection<TeachersDisciplinesRelation> TeachersRelations { get; set; } = default!;
    }
}
