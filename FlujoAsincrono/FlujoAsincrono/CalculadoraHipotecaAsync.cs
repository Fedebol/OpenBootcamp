using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAsincrono
{
    public class CalculadoraHipotecaAsync
    {
        public static async Task<int> GetYearsJob()
        {
            Console.WriteLine("\nObteniendo años de vida laboral.....");
            await Task.Delay(5000); // wait 5 seconds
            return new Random().Next(1, 35);
        }

        public static async Task<bool> GetContractJobUndefined()
        {
            Console.WriteLine("\nVerificando tipo de contrato.....");
            await Task.Delay(5000); // wait 5 seconds
            return (new Random().Next(1, 10)) % 2 == 0; // return true o false.
        }

        public static async Task<int> GetSalaryJob()
        {
            Console.WriteLine("\nObteniendo sueldo del empleado.....");
            await Task.Delay(5000); // wait 5 seconds
            return new Random().Next(500, 4000);
        }

        public static async Task<int> GetCostsMonthly()
        {
            Console.WriteLine("\nObteniendo gastos mensuales.....");
            await Task.Delay(5000); // wait 5 seconds
            return new Random().Next(400, 1000);
        }

        public static bool AnalizarInfoParaHipoteca(
            int yearsJob,
            bool contracUndefined,
            int salary,
            int costMonthly,
            int solicitated,
            int yearOfPay)
        {

            Console.WriteLine("Analizando informacion.....");

            if (yearsJob < 2)
            {
                return false;
            }

            var cuota = (solicitated / yearOfPay) / 12;
            if (cuota >= (salary / 2)) return false;

            var porcentajeSobreSueldo = (costMonthly * 100) / salary;

            if (porcentajeSobreSueldo >= 30) return false;

            if ((cuota + costMonthly) >= salary) return false;

            if (!contracUndefined)
            {
                if ((cuota + costMonthly) > (salary / 3)) return false;
            }
            return true;

        }


    }
}
