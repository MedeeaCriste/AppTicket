namespace TicketsApp
{
    public class User
    {
        private int userId;
        private string v1;
        private string v2;
        private string createdByEmail;

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string Email { get; set; } 

        public User(int id, string username, string password, string type, string email)
        {
            Id = id;
            Username = username;
            Password = password;
            Type = type;
            Email = email;
        }

        public User(int userId, string v1, string v2)
        {
            this.userId = userId;
            this.v1 = v1;
            this.v2 = v2;
        }

        public User(int userId, string v1, string v2, string createdByEmail) : this(userId, v1, v2)
        {
            this.createdByEmail = createdByEmail;
        }
    }
}
