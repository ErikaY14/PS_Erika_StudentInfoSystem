using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Marks
    {
        public int id { get; set; }
        public int MarkValue { get; set; }

        [ForeignKey(nameof(student))]
        public int studentId { get; set; }
        public Student  student { get; set; }
    }
}
