using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Models
{
    [Table("TeacherSubject")]
    public class TeacherSubject
    {
        [Key, Column(Order = 0)]
        [Required]
        [ForeignKey("Teacher")]
        public int teacher_id { get; set; }
        public Teacher Teacher { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        [ForeignKey("Subject")]
        public int subject_id { get; set; }
        public Subject Subject { get; set; }
    }
}
