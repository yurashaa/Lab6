using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Models
{
    [Table("Teacher")]
    public class Teacher : Base
    {
        [Required]
        public string first_name { get; set; }

        [Required]
        public string last_name { get; set; }

        public int age { get; set; }

        public string gender { get; set; }

        [Required]
        [ForeignKey("School")]
        public int school_id { get; set; }
        public virtual School School { get; set; }
    }
}
