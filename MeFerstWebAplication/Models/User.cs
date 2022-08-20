namespace MeFerstWebAplication.Models
{
    public class User
    {
        public User(int id, string? login, string? password, string? email, int? age, string? imageUser)
        {
            Id = id;
            Login = login;
            Password = password;
            Email = email;
            Age = age;
            ImageUser = imageUser;
        }
        public User()
        {
        }

        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public int? Age { get; set; }
        public string? ImageUser { get; set; }



    }
}
