using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    internal interface IStudentFilter
    {
        IEnumerable<Student> Filter(IEnumerable<Student> students);
    }
}
