using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class Student:Human
    {
        [Key]
        [Column("stud_id", TypeName = "INT")]
        public int StudID { get; set; }

        [Required]
        [Column("group_id",TypeName="INT")]
        public int GroupID { get; set; }

        //Navigation properties:

        [ForeignKey("GroupID")]
        public Group Group { get; set; }
    }
}
