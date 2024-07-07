namespace BaseLibrary.Entities
{
    public class RefreshTokenInfo
    {
        public int Id { get; set; }

        //REFERENCE TOKEN
        public string? Token { get; set; }
        public int UserId { get; set; }
    }
}
