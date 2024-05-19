using System.Collections.Generic;

namespace PasswordManeger
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public List<PasswordEntry> PasswordEntries { get; set; } = new List<PasswordEntry>();
    }
}