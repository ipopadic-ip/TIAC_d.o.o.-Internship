using Microsoft.EntityFrameworkCore;
using ProjektniZadatakTiac.DataAcess.Tasks.Interfaces;
using ProjektniZadatakTiac.Models;

namespace ProjektniZadatakTiac.DataAcess.Tasks
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public User GetUserById(int userId)
        {
            try
            {
                return _context.Users.Include(p => p.Followers).FirstOrDefault(u => u.Id == userId && u.IsActive);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("An error occurred while retrieving the user.", ex);
            }
        }

        public IEnumerable<User> SearchUsersByEmail(string email)
        {
            try
            {
                return _context.Users.Where(u => u.Email == email).ToList();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("An error occurred while searching users by email.", ex);
            }
        }

        public IEnumerable<User> SearchUsersByName(string firstName, string lastName)
        {
            try
            {
                return _context.Users.Where(u => u.FirstName == firstName && u.LastName == lastName).ToList();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("An error occurred while searching users by name.", ex);
            }
        }

        public User CreateUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("An error occurred while creating the user.", ex);
            }
        }

        public User UpdateUser(User user)
        {
            try
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("An error occurred while updating the user.", ex);
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                    return false;

                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("An error occurred while deleting the user.", ex);
            }
        }

        public bool FollowUser(int followerId, int followingId)
        {
            try
            {
                var follower = GetUserById(followerId);
                var following = GetUserById(followingId);

                if (follower == null || following == null || !follower.IsActive || !following.IsActive)
                    return false;

                follower.Following.Add(following);
                UpdateUser(follower);
                return true;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("An error occurred while following the user.", ex);
            }
        }

        //public IEnumerable<User> GetFollowers(int userId)
        //{
        //    try
        //    {
        //        return _context.UserUsers
        //            .Where(uu => uu.FollowersId == userId)
        //            .Select(uu => _context.Users.FirstOrDefault(u => u.Id == uu.FollowersId))
        //            .ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception (e.g., log or throw)
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //        throw;
        //    }
        //}

        //public IEnumerable<User> GetFollowing(int userId)
        //{
        //    try
        //    {
        //        return _context.UserUsers
        //            .Where(uu => uu.FollowingId == userId)
        //            .Select(uu => _context.Users.FirstOrDefault(u => u.Id == uu.FollowingId))
        //            .ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception (e.g., log or throw)
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //        throw;
        //    }
        //}


    }
}
