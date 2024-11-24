namespace YMYPHibrit3GroupEFCore.API.Models.Repositories.Entities.ManyToMany
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public List<Student>? Students { get; set; }
    }
}