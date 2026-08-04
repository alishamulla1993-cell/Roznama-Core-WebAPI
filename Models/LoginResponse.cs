namespace Roznama.Models.Auth
{
    public class LoginResponse
    {
        public int UserOID { get; set; }
        public string LoginID { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Role { get; set; } = "";
        public string Token { get; set; } = "";
    }
}