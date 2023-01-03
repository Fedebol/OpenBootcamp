using dotnetEjercicio1.Models.DataModels;

namespace dotnetEjercicio1.Service
{
    public class StudentsService : IStudentsService
    {
        public IEnumerable<Student> GetAllStudents()
        {
            
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudentsAdult()
        {
            //var adultStudent = Student.GroupBy(student => student);

            //foreach (var mayor in adultStudent)
            //{
            //    Console.WriteLine("-----------{0}----------", mayor.Key);
            //    foreach (var student in mayor)
            //    {
            //        return(student.Name);
            //    }
            throw new NotImplementedException();
        }




        // TODO: resolver

        public IEnumerable<Student> GetStudentsWithCourse()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsWithNotCourse()
        {
            throw new NotImplementedException();
        }
    }
}
