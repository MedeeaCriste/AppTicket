namespace TicketsApp
{
    public class Admin : User
    {
        public Admin(int id, string username, string password, string email)
            : base(id, username, password, "Admin", email) 
        {
        }

        public Admin(string username, string password, string email)
            : base(0, username, password, "Admin", email)
        {
        }
    }
}
