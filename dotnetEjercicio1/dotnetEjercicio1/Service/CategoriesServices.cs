using dotnetEjercicio1.DataAccess;
using dotnetEjercicio1.Models.DataModels;

namespace dotnetEjercicio1.Service
{
    public class CategoriesServices : ICategoriesServices
    {
        private readonly UniversityDBContext _context;
        public CategoriesServices(UniversityDBContext context)
        {
            _context = context;

        }
        public IEnumerable<Category> GetCourseInCategory()
        {
            var cursos = from course in _context.Categories
                        where course.Cursos != null
                        select course;
            return cursos;
        }
    }
}
