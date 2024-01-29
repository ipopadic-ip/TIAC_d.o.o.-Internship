using ProjektniZadatakTiac.Models;

namespace ProjektniZadatakTiac.DataAcess.Tasks.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        IEnumerable<User> SearchUsersByEmail(string email);
        IEnumerable<User> SearchUsersByName(string firstName, string lastName);
        User CreateUser(User user);
        User UpdateUser(User user);
        bool DeleteUser(int userId);
        bool FollowUser(int followerId, int followingId);
        //IEnumerable<User> GetFollowers(int userId);
        //IEnumerable<User> GetFollowing(int userId);

    }
}
