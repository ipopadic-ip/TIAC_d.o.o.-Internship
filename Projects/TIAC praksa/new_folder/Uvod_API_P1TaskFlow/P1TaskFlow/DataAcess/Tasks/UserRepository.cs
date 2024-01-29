using Microsoft.EntityFrameworkCore;
using P1TaskFlow.DataAcess;
using P1TaskFlow.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P1TaskFlow.DataAcess.Tasks
{
    public class UserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.authentications.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.authentications.FindAsync(id);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.authentications.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var existingUser = await _context.authentications.FindAsync(user.Id);

            if (existingUser == null)
            {
                return null;
            }

            // Update the properties of the existingUser entity
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            try
            {
                await _context.SaveChangesAsync();
                return existingUser;
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency exception if needed
                throw;
            }


            //_context.Entry(user).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //    return user;
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!_context.authentications.Any(u => u.Id == user.Id))
            //    {
            //        return null;
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var user = await _context.authentications.FindAsync(id);
            if (user != null)
            {
                _context.authentications.Remove(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }
    }
}
