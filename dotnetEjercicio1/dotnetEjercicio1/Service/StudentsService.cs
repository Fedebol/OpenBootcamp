using dotnetEjercicio1.DataAccess;
using dotnetEjercicio1.Models.DataModels;


namespace dotnetEjercicio1.Service
{
    public class StudentsService : IStudentsService
    {
        private readonly UniversityDBContext _context;
        public StudentsService(UniversityDBContext context)
        {
            _context = context;

        }

        public IEnumerable<Student> GetAllStudents()
        {

            var students = _context.Students.SelectMany(student => student.FirstName);
            return (IEnumerable<Student>)students;
        }

        public IEnumerable<Student> GetAllStudentsAdult()
        {
            var studentAdult = from student in _context.Students
                               where student.DOB.AddYears(18) >= DateTime.Now
                              select student.FirstName;
            return (IEnumerable<Student>)studentAdult;

        }



        
       
        public IEnumerable<Student> GetStudentsWithCourse()
        {
            var whitCourse = from student in _context.Students
                             where student.Cursos != null
                             select student;
            return whitCourse;
        }

        public IEnumerable<Student> GetStudentsWithNotCourse()
        {
            var whitNotCourse = from student in _context.Students
                             where student.Cursos == null
                             select student;
            return whitNotCourse;
        }
    }
}
