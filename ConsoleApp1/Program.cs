namespace ConsoleApp1
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // Reference Types=>Class,Delegate,Array,Event,Collection,string
            // Value   Types =>int,float,double,decimal,byte,short,long,bool,char,enum,struct
            var user = new User()
            {
                Name = "Ahmet",
                Age = 23
            };
            Console.WriteLine($"Name={user.Name},Age={user.Age}");

            ChangeUserName(user);
            Console.WriteLine($"Name={user.Name},Age={user.Age}");

            ChangeAge(user.Age);
            Console.WriteLine($"Name={user.Name},Age={user.Age}");
        }


        static void ChangeUserName(User user)
        {
            user.Name = "Mehmet";
            user.Age = 50;
        }

        static void ChangeAge(int age)
        {
            age = 40;
        }
    }
}