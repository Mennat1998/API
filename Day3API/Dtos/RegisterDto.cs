namespace Day3API.Dtos
{
    public class RegisterDto
    {
        public required string UserName { get; set; }=string.Empty;
        public required string Password { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
        public required string UserDepartment { get; set; } = string.Empty;


    }
}
