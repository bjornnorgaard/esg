using System;

namespace WebApi.Models
{
    public class User
    {
        public User(int id)
        {
            Id = id;
            Name = "John Doe";
            Age = new Random().Next(18, 80);
            Birthdate = DateTime.Now.Subtract(new TimeSpan(Age, 0, 0));
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
