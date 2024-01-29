using ProjektniZadatakTiac.DataAcess.Tasks.Interfaces;
using ProjektniZadatakTiac.Models;

namespace ProjektniZadatakTiac.DataAcess.Tasks
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DatabaseContext _context;

        public CommentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Comment GetCommentById(int commentId)
        {
            try
            {
                return _context.Comments.FirstOrDefault(c => c.Id == commentId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while getting comment by ID.", ex);
            }
        }

        public IEnumerable<Comment> GetCommentsByUser(int userId)
        {
            try
            {
                return _context.Comments.Where(c => c.UserId == userId).ToList();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while getting comment by ID.", ex);
            }
        }

        public void CreateComment(Comment comment)
        {
            try
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new ApplicationException("An error occurred while creating a comment.", ex);
            }
        }

        public void UpdateComment(Comment comment)
        {
            try
            {
                _context.Comments.Update(comment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new ApplicationException("An error occurred while updating a comment.", ex);
            }
        }

        public void DeleteComment(int commentId)
        {
            try
            {
                var comment = _context.Comments.FirstOrDefault(c => c.Id == commentId);
                if (comment != null)
                {
                    _context.Comments.Remove(comment);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new ApplicationException("An error occurred while deleting a comment.", ex);
            }
        }

        //public void CreateComment(Comment comment)
        //{
        //    _context.Comments.Add(comment);
        //    _context.SaveChanges();
        //}

        //public void UpdateComment(Comment comment)
        //{
        //    _context.Comments.Update(comment);
        //    _context.SaveChanges();
        //}

        //public void DeleteComment(int commentId)
        //{
        //    var comment = _context.Comments.FirstOrDefault(c => c.Id == commentId);
        //    if (comment != null)
        //    {
        //        _context.Comments.Remove(comment);
        //        _context.SaveChanges();
        //    }
        //}
    }
}
