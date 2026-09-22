using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Project_Voting.VoteMe
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = default!;
        public string Login { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
