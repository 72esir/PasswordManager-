namespace PasswordManeger
{
    public class PasswordEntry
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Foreign key для связи с пользователем
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Comment { get; set; }
        public string Tags { get; set; }

        // Навигационное свойство для доступа к связанному пользователю
        public User User { get; set; }
    }
}
