using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UserLogin;

namespace StudentInfoSystem
{
    public class StudentInfoContext : DbContext
    {
        public StudentInfoContext(): base(Properties.Settings.Default.DbConnectE)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Marks> Marks { get; set; }

    }
}
