using dotnetEjercicio1.DataAccess;
using dotnetEjercicio1.Models.DataModels;
using System.Collections;

namespace dotnetEjercicio1.Service
{


    public class CoursesService : ICoursesService
    {

        private readonly UniversityDBContext _context;
        public CoursesService(UniversityDBContext context)
        {
            _context = context;

        }

        public IEnumerable<Course> GetCourseLevel(Nivel level)
        {
            var coursesForLevel = from nivel in _context.Cursos
                                  where nivel.Nivel == level && nivel.Students.Count() > 0
                                  select nivel;
            return coursesForLevel;

        }

        public IEnumerable<Course> GetCoursesCategory(ICollection category, Nivel level)
        {
            var coursesCategory = from categorys in _context.Cursos
                                  where categorys.Nivel == level && categorys.Categorias == category
                                  select categorys;
            return coursesCategory;
        }

        public IEnumerable<Course> GetCoursesNotStudent()
        {
            var coursesNotStudent = from curso in _context.Cursos
                                  where curso.Students.Count() == 0
                                  select curso;
            return coursesNotStudent;
        }
    }
}
