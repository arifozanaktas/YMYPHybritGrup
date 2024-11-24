namespace YMYPHibrit3GroupEFCore.API.Models.Repositories.Entities.ManyToMany
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int Age { get; set; }

        public List<Teacher> Teachers { get; set; } = default!;
    }
}