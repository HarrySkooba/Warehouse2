using Backend.DB;
using WebApi.DB;


namespace Backend.DB
{
    public class UserModel
    {
        public int Iduser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rolename { get; set; } = null!;
        public int Idrole { get; set; }

        public UserModel(User user) 
        {
            if (user != null)
            {
                Iduser = user.Id;
                Name = user.Name;
                Email = user.Email;
                Password = user.Password;
                Rolename = user.Role != null ? user.Role.Role1 : null;
                Idrole = user.Roleid;
            }
            else
            {
                Iduser = -1;
                Name = "Unknown";
                Email = "Unknown";
                Password = "Unknown";
                Rolename = "Unknown";
                Idrole = -1;
            }
        }
    }
}
