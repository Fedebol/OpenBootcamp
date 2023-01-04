using dotnetEjercicio1.Models.DataModels;

namespace dotnetEjercicio1.Service
{

    public interface ICategoriesServices
    {
        IEnumerable<Category> GetCourseInCategory();
    }
}
