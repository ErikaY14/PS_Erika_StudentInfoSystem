using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogin
{
    public static class UserData
    {
        private static List<User> _testUsers = new List<User>(3);

        public static List<User> testUsers
        {
            get {
                //ResetTestUserData();
                return _testUsers; 
            }
            set { _testUsers = value; }
        }

        public static void ResetTestUserData()
        {
            User testUser = new User();
            
            testUser.username = "ivcheto3";
            testUser.password = "pass";
            testUser.facultyNumber = 121220173;
            testUser.role = 1;
            testUser.created = DateTime.Now;
            testUser.activeUntil = DateTime.MaxValue;
            _testUsers.Add(testUser);

            testUser = new User();
            testUser.username = "adi9785";
            testUser.password = "password";
            testUser.facultyNumber = 121220118;
            testUser.role = 4;
            testUser.created = DateTime.Now;
            testUser.activeUntil = DateTime.MaxValue;
            _testUsers.Add(testUser);

            testUser = new User();
            testUser.username = "erikaaa";
            testUser.password = "password23";
            testUser.facultyNumber = 121220092;
            testUser.role = 4;
            testUser.created = DateTime.Now;
            testUser.activeUntil = DateTime.MaxValue;
            _testUsers.Add(testUser);

            testUser = new User();
            testUser.username = "genata";
            testUser.password = "pass123";
            testUser.facultyNumber = 121220170;
            testUser.role = 2;
            testUser.created = DateTime.Now;
            testUser.activeUntil = DateTime.MaxValue;
            _testUsers.Add(testUser);

            testUser = new User();
            testUser.username = "traikov";
            testUser.password = "pass1234";
            testUser.facultyNumber = 1212190120;
            testUser.role = 2;
            testUser.created = DateTime.Now;
            testUser.activeUntil = DateTime.MaxValue;
            _testUsers.Add(testUser);

            testUser = new User();
            testUser.username = "emoto13";
            testUser.password = "pass12345";
            testUser.facultyNumber = 121219009;
            testUser.role = 2;
            testUser.created = DateTime.Now;
            testUser.activeUntil = DateTime.MaxValue;
            _testUsers.Add(testUser);

            testUser = new User();
            testUser.username = "deqn023";
            testUser.password = "pass1234567";
            testUser.facultyNumber = 121219019;
            testUser.role = 2;
            testUser.created = DateTime.Now;
            testUser.activeUntil = DateTime.MaxValue;
            _testUsers.Add(testUser);
        }

        public static User IsUserPassCorrect(String username, String password)
        {
            return (from user in _testUsers
                    where user.username.Equals(username)
                    && user.password.Equals(password)
                    select user).First();
/*            foreach (User user in _testUsers)
            {
                if (user.username.Equals(username) && user.password.Equals(password))
                {
                    return user;
                }
            }
            return null;*/
        }

        public static bool SetUserActiveUntil(String username, DateTime newActiveUntil)
        {
            foreach (User user in _testUsers)
            {
                if (user.username == username)
                {
                    user.activeUntil = newActiveUntil;
                    Logger.LogActivity(Activities.USER_ACTIVE_UNTIL_CHANGED);
                    return true;
                }
            }

            return false;
        }

        public static bool AssignUserRole(String username, UserRoles newRole)
        {
            UserContext context = new UserContext();
            foreach (User user in _testUsers)
            {
                if (user.username == username)
                {
                    user.role = (int) newRole;
                    Logger.LogActivity(Activities.USER_ROLE_CHANGED);
                    return true;
                }
            }

            return false;
        }
    }
}
