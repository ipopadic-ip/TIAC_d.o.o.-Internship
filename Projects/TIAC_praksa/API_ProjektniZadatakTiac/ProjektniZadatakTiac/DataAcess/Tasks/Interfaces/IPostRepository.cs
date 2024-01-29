using Microsoft.AspNetCore.Mvc;
using ProjektniZadatakTiac.Models;

namespace ProjektniZadatakTiac.DataAcess.Tasks.Interfaces
{
    public interface IPostRepository
    {
        Post GetPostById(int postId);
        IEnumerable<Post> GetPostsByUser(int userId);
        IEnumerable<Post> GetPostsByTag(string tagName);
        Post CreatePost(Post post);
        Post UpdatePost(Post post);
        //void UpdatePost(Post post);
        bool DeletePost(int postId);
        IEnumerable<Post> GetPostsSortedByLikes();
    }
}
