﻿namespace Egzaminas.Object
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public string Role { get; set; } 
        public UserData UserData { get; set; } 

        public User()
        {
            
        }

    }
}
