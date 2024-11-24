using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YMYPHibrit3GroupEFCore.API.Models.Repositories.Entities;
using YMYPHibrit3GroupEFCore.API.Models.Repositories.Entities.ManyToMany;

namespace YMYPHibrit3GroupEFCore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManyToManyExampleController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CreateOneTeacherToManyStudent()
        {
            var teacher = new Teacher
            {
                Name = "Teacher 1",
            };

            teacher.Students = new List<Student>();

            teacher.Students.Add(new Student() { Name = "Student 11", Age = 22 });
            teacher.Students.Add(new Student() { Name = "Student 12", Age = 22 });
            teacher.Students.Add(new Student() { Name = "Student 13", Age = 22 });


            context.Teachers.Add(teacher);

            await context.SaveChangesAsync();


            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> CreateOneStudentToManyTeacher()
        {
            var student = new Student() { Name = "Student 2", Age = 23 };

            student.Teachers = new List<Teacher>();

            student.Teachers.Add(new Teacher() { Name = "Teacher 21" });
            student.Teachers.Add(new Teacher() { Name = "Teacher 22" });
            student.Teachers.Add(new Teacher() { Name = "Teacher 23" });

            context.Students.Add(student);
            await context.SaveChangesAsync();


            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> AddExistStudentToManyTeacher()
        {
            var student = await context.Students.FindAsync(1);


            if (student is not null)
            {
                student.Teachers = new List<Teacher>();

                student.Teachers.Add(new Teacher() { Name = "Teacher 21" });
                student.Teachers.Add(new Teacher() { Name = "Teacher 22" });
                student.Teachers.Add(new Teacher() { Name = "Teacher 23" });

                context.Students.Update(student);
                await context.SaveChangesAsync();
            }


            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> EagerLoading()
        {
            //Eager Loading

            var studentWithTeacher =
                await context.Students.Where(x => x.Id == 1).Include(x => x.Teachers).ToListAsync();


            //Explicit Loading

            //var student = await context.Students.FindAsync(4);

            // context.Entry(student).Collection(x => x.Teachers).Load();


            // Lazy loading

            //var student2 = await context.Students.FindAsync(1);

            //student2.Teachers.ForEach(x =>
            //{

            //});


            return Ok();
        }
    }
}