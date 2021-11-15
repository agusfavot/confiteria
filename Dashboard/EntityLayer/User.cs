using System;

namespace EntityLayer
{
    public class User
    {
        private string name;
        private byte[] password;
        private byte[] seed;

        public User(string name, byte[] password, byte[] seed) {
            this.name = name;
            this.password = password;
            this.seed = seed;
        }

        public User() { }

        public string Name { get => name; set => name = value; } 

        public byte[] Password { get => password; set => password = value; }

        public byte[] Seed { get => seed; set => seed = value; }
    }
}
