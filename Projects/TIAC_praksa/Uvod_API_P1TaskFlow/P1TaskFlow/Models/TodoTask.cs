using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace P1TaskFlow.Models
{
    //<summary>
    //This is a task mode
    //</summary>
    public class TodoTask : User
    {
        //<summary>
        //Id of text
        //</summary>
        //[JsonIgnore]//ukoliko ne zelimo da se u povratku vidi podata
        //[PrimaryKey]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set;}
        public DateTime Deadline { get; set; }
        public DateTime Reminder { get; set; }
        public StatusesEnum Status { get; set; }
        public bool IsImportant { get; set; }   
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
