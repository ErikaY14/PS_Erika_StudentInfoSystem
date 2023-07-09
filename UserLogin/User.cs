using System;

namespace UserLogin
{
    public class User
    {
        public int UserId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int facultyNumber { get; set; }
        public int role { get; set; }
        public DateTime created { get; set; }
        public DateTime activeUntil { get; set; }

        public User(string uname, string pass, int facNum, int rolee, DateTime create, DateTime activeDue) 
        {
            username = uname;
            password = pass;
            facultyNumber = facNum;
            role = rolee;
            created = create;
            activeUntil = activeDue;
        }

        public User() { }


        public string toString()
        {
            return $"{this.username} с парола: {this.password}. " 
                + $"Факултетен номер: {this.facultyNumber}. " 
                + $"Роля: {this.role}. "
                + $"Създаден на {this.created.Day}.{this.created.Month}.{this.created.Year}. "
                + $"Активен до {this.activeUntil.Day}.{this.activeUntil.Month}.{this.activeUntil.Year}. ";
        }
    }
}
