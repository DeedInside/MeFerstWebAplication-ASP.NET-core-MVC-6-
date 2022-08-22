namespace MeFerstWebAplication.Models.UserModel
{
    public class User
    {
        public User(int id, string? login, string? password, string? email, string? age, string? imageUserUrl, int? roleId, Role role)
        {
            Id = id;
            Login = login;
            Password = password;
            Email = email;
            Age = age;
            ImageUserUrl = imageUserUrl;
            RoleId = roleId;
            Role = role;
        }
        public User()
        {
        }

        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Age { get; set; }
        public string? ImageUserUrl { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }

    }
}
