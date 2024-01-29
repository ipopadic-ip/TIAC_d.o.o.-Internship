using ProjektniZadatakTiac.Models;
using System.Collections.Generic;

namespace ProjektniZadatakTiac.DataAcess.Tasks.Interfaces
{
    public interface ICommentRepository
    {
        Comment GetCommentById(int commentId);
        IEnumerable<Comment> GetCommentsByUser(int userId);
        void CreateComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(int commentId);
    }
}
