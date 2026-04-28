using System;

namespace TicketsApp
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public string Status { get; set; }

        public Ticket(int id, string title, string description, User user)
        {
            Id = id;
            Title = title;
            Description = description;
            User = user;
            Status = "Open"; 
            CreationDate = DateTime.Now; 
        }
    }
}
