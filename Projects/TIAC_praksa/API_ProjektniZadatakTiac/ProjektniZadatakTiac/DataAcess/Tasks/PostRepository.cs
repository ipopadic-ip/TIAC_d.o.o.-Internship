using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektniZadatakTiac.DataAcess.Tasks.Interfaces;
using ProjektniZadatakTiac.Models;

namespace ProjektniZadatakTiac.DataAcess.Tasks
{
    public class PostRepository : IPostRepository
    {
        private readonly DatabaseContext _context;

        public PostRepository(DatabaseContext context)
        {
            _context = context;
        }
        public Post GetPostById(int postId)
        {
            try
            {
                return _context.Posts.Include(p => p.Tags).FirstOrDefault(p => p.Id == postId && p.Archived);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("An error occurred while retrieving the post.", ex);
            }
        }

        public IEnumerable<Post> GetPostsByUser(int userId)
        {
            try
            {
                return _context.Posts.Where(p => p.UserId == userId).ToList();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("An error occurred while retrieving the posts.", ex);
            }
        }

        public IEnumerable<Post> GetPostsByTag(string tagName)
        {
            try
            {
                return _context.Posts.Where(p => p.Tags.Any(t => t.Name == tagName)).Include(p => p.Tags).ToList();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("An error occurred while retrieving the posts by tag.", ex);
            }
        }

        public Post CreatePost(Post post)
        {
            try
            {
                _context.Posts.Add(post);
                _context.SaveChanges();
                return post;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("An error occurred while creating the post.", ex);
            }
        }

        public Post UpdatePost(Post post)
        {
            try
            {
                _context.Update(post); // Use Update method to handle entity changes
                _context.SaveChanges();
                return post;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("An error occurred while updating the post.", ex);
            }
        }

        public bool DeletePost(int postId)
        {
            try
            {
                var post = _context.Posts.FirstOrDefault(p => p.Id == postId);
                if (post == null)
                    return false;

                _context.Posts.Remove(post);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("An error occurred while deleting the post.", ex);
            }
        }

        public IEnumerable<Post> GetPostsSortedByLikes()
        {
            try
            {
                return _context.Posts
                    .OrderByDescending(p => p.Likes)
                    .ToList();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("An error occurred while retrieving the posts sorted by likes.", ex);
            }
        }
    }
}
