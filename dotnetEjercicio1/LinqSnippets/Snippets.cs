using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "AUdi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat Leon"
            };

            // 1. SELECT * of cars
            var carList = from car in cars select car;
            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2. SELECT WHERE car is Audi
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach (var car in audiList)
            {
                Console.WriteLine(car);
            }
        }

        //Number Examples
        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var processedNumberList = numbers
                .Select(x => x * 3)
                .Where(x => x != 9)
                .OrderBy(x => x);
        }

        static public void SearcExamples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };

            // 1. First of all elements
            var first = textList.First();

            // 2. First element that is "c"

            var cText = textList.First(text => text.Equals("c"));

            // 3. First element that contains "j"

            var jText = textList.First(text => text.Contains("j"));

            // 4. First element that contains "z" or default

            var firtsOrDefault = textList.FirstOrDefault(text => text.Contains("z"));

            // 5. First element that contains "z" or default

            var lastsOrDefault = textList.LastOrDefault(text => text.Contains("z"));

            // 6. Single Values
            var uniqueText = textList.Single();
            var uniqueOrDefault = textList.SingleOrDefault();


            int[] evenNumber = { 0, 2, 4, 6, 8 };

            int[] otherEvenNumber = { 0, 2, 6 };

            // obtein {4, 8}
            var numbersunique = evenNumber.Except(otherEvenNumber);
        }

        static public void MultipleSelects()
        {
            //SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"

            };
            var myOpinionSelection = myOpinions.SelectMany(x => x.Split(","));

            var enterprise = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employes = new[]
                    {
                        new Employe
                        {
                            Id = 1,
                            Name = "Martin",
                            Email = "martin@enter.com",
                            Salary = 3000
                        },
                        new Employe
                        {
                            Id = 2,
                            Name = "Federico",
                            Email = "federico@enter.com",
                            Salary = 3500
                        },
                        new Employe
                        {
                            Id = 3,
                            Name = "Juan",
                            Email = "juan@enter.com",
                            Salary = 2500
                        }

                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employes = new[]
                    {
                        new Employe
                        {
                            Id = 4,
                            Name = "Ana",
                            Email = "ana@enter.com",
                            Salary = 1500
                        },
                        new Employe
                        {
                            Id = 5,
                            Name = "Mirta",
                            Email = "mirta@enter.com",
                            Salary = 750
                        },
                        new Employe
                        {
                            Id = 6,
                            Name = "Pepe",
                            Email = "pepe@enter.com",
                            Salary = 5000
                        }

                    }
                },
            };

            // Obtain all Employes of all Enterprises
            var employeList = enterprise.SelectMany(enterprise => enterprise.Employes);

            // know if any list is empty

            bool hasEnterprises = enterprise.Any();

            bool hasEmployes = enterprise.Any(enterprise => enterprise.Employes.Any());

            //All enterprises at least employe with at 1000 of salary

            bool hasEmployemore =
                enterprise.Any(enterprise =>
                enterprise.Employes.Any(employe =>
                employe.Salary > 1000));


        }

        static public void linqCollections()
        {
            var firtsList = new List<string>() { "a", "b", "c" };
            var firtsList2 = new List<string>() { "a", "b", "d" };

            // INER JOIN
            var commonResult = from elemenet in firtsList
                               join seconElement in firtsList2
                               on elemenet equals seconElement
                               select new { elemenet, seconElement };

            var commonResult2 = firtsList.Join(
                firtsList2,
                element => element,
                secondElement => secondElement,
                (element, secondElement) => new { element, secondElement }
                );

            // OUTER JOIN - LEFT
            var leftOuterJoin = from element in firtsList
                                join secondElement in firtsList2
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            var leftOuterJoin2 = from element in firtsList
                                 from secondElement in firtsList2.Where(s => s == element).DefaultIfEmpty()
                                 select new { Element = element, SecondElement = secondElement };


            // UNION
        }

        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9,10,11,12
            };

            // Skip
            var skipTwoFirts = myList.Skip(2); // { 3,4,5,6,7,8,9,10,11,12 }
            var skipLastTwo = myList.SkipLast(2); //{ 1,2,3,4,5,6,7,8,9,10 }
            var skipWhile = myList.SkipWhile(num => num < 4); // { 5,6,7,8,9,10,11,12 }

            // TAKE

            var takeTwoFirts = myList.Take(2); // { 1, 2 }
            var takeLastTwo = myList.TakeLast(2); //{ 11, 12 }
            var takeWhile = myList.SkipWhile(num => num < 4); // { 1, 2, 3 }

        }

    }
}