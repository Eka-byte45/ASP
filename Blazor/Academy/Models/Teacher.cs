using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class Teacher:Human
    {
        [Key]
        [Column(TypeName ="smallint")]
        public short teacher_id {  get; set; }
        public DateOnly work_since { get; set; } = default!;

        [Column(TypeName = "smallmoney")]
        public decimal rate {  get; set; }

    }
}
