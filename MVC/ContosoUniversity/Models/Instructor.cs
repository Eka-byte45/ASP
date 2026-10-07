using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Instructor
    {
        public int ID {  get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        [Display(Name ="Дата трудоустройства")]
        public DateTime HireDate {  get; set; }

        //Calclulated properties:
        [DisplayName("Инструктор")]
        public string FullName
        {
            get=>$"{LastName} {FirstName}";
        }
        //TODO: Navigation properties:
    }
}
