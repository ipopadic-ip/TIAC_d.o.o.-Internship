using P1TaskFlow.Models;
using System.Threading.Tasks;

namespace P1TaskFlow.DataAcess.Tasks
{
    public class UsersMockRepository
    {
        private static List<User> users = new();
        private static bool empty = false;

        //public TodoTaskMockRepository() { FillData(); }

        public UsersMockRepository()
        {
            if (users.Count == 0)
            {
                FillData();
            }
        }

        private void FillData()
        {
            if (empty == false)
            {
                users.AddRange(new List<User>
                {
                new User
                {
                    Id = 1,
                    FirstName = "My first task",
                    LastName = "Some description",
                    Password = "1",
                    Email = "1"
                },
                new User
                {
                    Id = 2,
                    FirstName = "My first task 2",
                    LastName = "Some description 2",
                    Password = "2",
                    Email = "2"
                }
                });
            }
        }

        public List<User> GetUsers()
        {
            return users;
        }
        //nekad moze da vrati null, zato upitnik
        public User? GetUserById(int id)
        {
            return users.FirstOrDefault(item => item.Id == id);
        }

        public User CreateUser(User user)
        {
            user.Id = new Random().Next();
            users.Add(user);
            return GetUserById(user.Id);
        }

        public User UpdateUser(User user)
        {
            User t = users.FirstOrDefault(t => t.Id == user.Id);//posto je t samo referenca,kad ga izmenimo izmenice se i u tasks
            t.Id = user.Id;
            t.FirstName = user.FirstName;
            t.LastName = user.LastName;
            t.Email = user.Email;
            t.Password = user.Password;
            return t;
        }
        public User DeleteUserById(int id)
        {
            User user = GetUserById(id);
            if (user != null)
            {
                users.Remove(user);
                if (users.Count == 0)
                {
                    users.Clear();
                    empty = true;
                }
            }
            return user;
        }

        public User GetUser(string Password, string Email)
        {
            foreach (var user in users)
            {
                if (user.Password == Password && user.Email == Email)
                {
                    return user;
                }
            }
            return null;
        }

    }
}
