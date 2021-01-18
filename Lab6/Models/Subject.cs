using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.Models
{
    [Table("Subject")]
    public class Subject : Base
    {
        [Required]
        [MaxLength(20)]
        public string name { get; set; }

        public int coefficient { get; set; }

        public int duration { get; set; }
    }
}
