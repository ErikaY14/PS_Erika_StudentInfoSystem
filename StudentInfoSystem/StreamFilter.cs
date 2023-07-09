using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    internal class StreamFilter: IStudentFilter
    {
        private int _stream;

        public StreamFilter(int stream)
        {
            _stream = stream;
        }

        public IEnumerable<Student> Filter(IEnumerable<Student> students)
        {
            return students.Where(s => s.Stream == _stream);
        }
    }
}
