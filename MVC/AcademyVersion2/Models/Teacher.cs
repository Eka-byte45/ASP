using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyVersion2.Models
{
    public class Teacher:Human
    {
        [Key]
        [Column("teacher_id",TypeName ="SMALLINT")]
        public int teacher_id { get; set; }

        public DateOnly work_since {  get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "SMALLMONEY")]
        public decimal rate {  get; set; }

        //Navigation properties:
        public ObservableCollection<TeachersDisciplinesRelation> DisciplinesRelations { get; set; } = default!;

        public string Experience
        {
            get
            {
                var now = DateTime.Now;
                int years = now.Year - work_since.Year;
                int months = now.Month - work_since.Month;
                if(now.Day < work_since.Day)
                {
                    months--;
                }
                if(months < 0)
                {
                    years--;
                    months += 12;
                }
                return $"{years} year(s) {months} month(s)";
                //DateTime today = DateTime.Today;
                //int experience = today.Year - work_since.Year;
                //if (work_since.Month > today.Month || (work_since.Month == today.Month && work_since.Day > today.Day))
                //{
                //    experience--;
                //}
                //;
                //return experience;
            }
        }
    }
}
