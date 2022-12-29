using dotnetEjercicio1.Models.DataModels;
using System.Linq;
namespace dotnetEjercicio1.Service
{
    public class Services
    {

        static public void userForMail(string mail, User usuarios)
        {
            var mostrar = from string mails in usuarios.Email
                          where mails.Contains(mail)
                          select mails;
            Console.WriteLine(mostrar);
        }

        static public void mayorEdad(User usuarios)
        {
          



        }

    }
}
