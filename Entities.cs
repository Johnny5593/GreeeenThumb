using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb
{
    public class Plant
    {
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public ICollection<Instruction> FollowingInstructions { get; set; }
    }

    public class Instruction
    {
        public int InstructionId { get; set; }
        public string InstructionText { get; set; }
        public int PlantId { get; set; }
        public Plant Plant { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool IsUsernameTaken(string username)
        {
            return Users.Any(u => u.Username == username);
        }

        private List<User> Users = new List<User>();

        public void AddUser(User user)
        {
            Console.WriteLine("User in GreenThumb", user);
            Users.Add(user);
        }
    }
}

