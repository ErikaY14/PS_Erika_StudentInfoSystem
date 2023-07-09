using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    internal class FirstNameFilter: IStudentFilter
    {
        private string _name;

        public FirstNameFilter(string name)
        {
            _name = name;
        }

        public IEnumerable<Student> Filter(IEnumerable<Student> students)
        {
            return students.Where(s => s.FirstName == _name);
        }
    }
}
