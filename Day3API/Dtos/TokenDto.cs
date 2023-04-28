namespace Day3API.Dtos
{
    public class TokenDto
    {
        public string Token { get; set; } = string.Empty;

        public DateTime TokenExpire { get; set; }
    }
}
