using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class Teacher:Human
    {
       
        [Column("teacher_id", TypeName = "SMALLINT")]
        public int TeacherID { get; set; }

        public DateOnly work_since { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "SMALLMONEY")]
        public decimal rate { get; set; }

        //Navigation properties:
        public ObservableCollection<TeachersDisciplinesRelation> DisciplinesRelations { get; set; } = default!;
    }
}
