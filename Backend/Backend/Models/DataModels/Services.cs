using Backend.DataAccess;
using System.Collections;

namespace Backend.Models.DataModels
{
    public class Services
    {

        private readonly BackBDContext _context;

        public Services (BackBDContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUserForMail(string mail)
        {
            var users = from user in _context.Users
                        where user.Email == mail
                        select user;
            return users;
        }

        public IEnumerable<Estudiante> GetAllStudentsAdult()
        {
            var studentAdult = from student in _context.Estudiantes
                               where student.DOB.AddYears(18) >= DateTime.Now
                               select student.FirstName;
            return (IEnumerable<Estudiante>)studentAdult;

        }


        public IEnumerable<Estudiante> GetStudentsWithCourse()
        {
            var whitCourse = from student in _context.Estudiantes
                             where student.Cursos != null
                             select student;
            return whitCourse;
        }

        public IEnumerable<Curso> GetCoursesNotStudent(Nivel level)
        {
            var coursesNotStudent = from curso in _context.Cursos
                                    where curso.Estudiantes.Count() != 0 && curso.Nivel == level
                                    select curso;
            return coursesNotStudent;
        }

        public IEnumerable<Curso> GetCoursesCategory(ICollection categoria, Nivel level)
        {
            var coursesCategory = from categorys in _context.Cursos
                                  where categorys.Nivel == level && categorys.Categorias == categoria
                                  select categorys;
            return coursesCategory;
        }

        public IEnumerable<Curso> GetCoursesNotStudent()
        {
            var coursesNotStudent = from curso in _context.Cursos
                                    where curso.Estudiantes.Count() == 0
                                    select curso;
            return coursesNotStudent;
        }




    }
}
