namespace Biblioteka.Core
{
    public class AddUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ConfirmPassword { get; set; }
        public string RoleName { get; set; }
    }
}
