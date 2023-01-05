using dotnetEjercicio1.Models.DataModels;
using System.Collections;

namespace dotnetEjercicio1.Service
{
    public interface ICoursesService
    {

        IEnumerable<Course> GetCourseLevel(Nivel level);
        IEnumerable<Course> GetCoursesCategory(ICollection category, Nivel level);
        IEnumerable<Course> GetCoursesNotStudent();
        IEnumerable<Course> GetCourseNotObjet();
    }
}
