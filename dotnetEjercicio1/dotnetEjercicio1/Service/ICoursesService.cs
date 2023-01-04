using dotnetEjercicio1.Models.DataModels;

namespace dotnetEjercicio1.Service
{
    public interface ICoursesService
    {

        IEnumerable<Course> GetCourseLevel(Nivel level);
        IEnumerable<Course> GetCoursesCategory();
        IEnumerable<Course> GetCoursesNotStudent();
    }
}
