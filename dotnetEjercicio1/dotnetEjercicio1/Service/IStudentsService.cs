using dotnetEjercicio1.Models.DataModels;

namespace dotnetEjercicio1.Service
{
    public interface IStudentsService
    {

        IEnumerable<Student> GetStudentsWithCourse();
        IEnumerable<Student> GetStudentsWithNotCourse();
        IEnumerable<Student> GetAllStudents();
        IEnumerable<Student> GetAllStudentsAdult();
      


    }
}
