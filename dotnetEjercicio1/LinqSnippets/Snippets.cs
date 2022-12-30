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

        // paging

        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage)
        {
            int startIndex = (pageNumber - 1) * resultsPerPage;
            return collection.Skip(startIndex).Take(resultsPerPage);
        }

        // Variables en LINQ

        static public void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, };
            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquare = Math.Pow(number, 2)
                               where nSquare > average
                               select number;
            Console.WriteLine("average: {0}", numbers.Average());

            foreach (int number in numbers)
            {
                Console.WriteLine("number: {0} Square: {1}", number, Math.Pow(number, 2));
            }
        }

        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + "=" + word);

            // { "1=one", "2=two", "3=three", ...}

        }

        // Repeat & Range

        static public void repeatRangeLinq()
        {
            // generate collection
            var first1000 = Enumerable.Range(0, 1000);

            var fiveXs = Enumerable.Repeat("X", 5); //{"X", "X", "X", ...}
        }

        static public void studentsLinq()
        {
            var classRoom = new[]
            {


                new Student
                {
                    Id = 1,
                    Name = "Martin",
                    Grade = 90,
                    Certificate = true,
                },
                new Student
                {
                    Id = 2,
                    Name = "Martina",
                    Grade = 80,
                    Certificate = true,
                },
                new Student
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 45,
                    Certificate = false,
                },
                new Student
                {
                    Id = 4,
                    Name = "Juan",
                    Grade = 95,
                    Certificate = true,
                },
                new Student
                {
                    Id = 5,
                    Name = "Pablo",
                    Grade = 35,
                    Certificate = false,
                },
            };

            var certifiedStudents = from student in classRoom
                                    where student.Certificate == true
                                    select student;

            var notCertifiedStudents = from student in classRoom
                                       where student.Certificate == false
                                       select student;

            var appovedStudents = from student in classRoom
                                  where student.Grade >= 50 && student.Certificate == true
                                  select student.Name;

        }

        // ALL

        static public void AllLinq()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            bool allAreSmaller = numbers.All(x => x < 10); // true
            bool allAreBigger = numbers.All(x => x >= 2); // false

            var emptyList = new List<int>();
            bool allNumbersThan0 = numbers.All(x => x >= 0); // true

        }

        //Aggregate

        static public void aggregateQueries()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Sum All
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);
            // prevSum 0 , current 1 => 1
            // prevSum 1 , current 2 => 3
            // prevSum 3 , current 3 => 6
            // prevSum 6 , current 4 => 10

            string[] words = { "hello,", "my", "name", "is", "Federico" };
            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current);
        }

        // Disctinct 

        static public void disctinctValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 };
            IEnumerable<int> values = numbers.Distinct();
        }

        // GroupBy

        static public void groupbyExample()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, };

            // Obtain only even numbers and generate two groups
            var grouped = numbers.GroupBy(x => x % 2 == 0);
            foreach (var group in grouped)
            {
                foreach (var value in group)
                {
                    Console.WriteLine(value); // 1,3,5,7,9...2,4,6,8
                }
            }

            var classRoom = new[]
            {


                new Student
                {
                    Id = 1,
                    Name = "Martin",
                    Grade = 90,
                    Certificate = true,
                },
                new Student
                {
                    Id = 2,
                    Name = "Martina",
                    Grade = 80,
                    Certificate = true,
                },
                new Student
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 45,
                    Certificate = false,
                },
                new Student
                {
                    Id = 4,
                    Name = "Juan",
                    Grade = 95,
                    Certificate = true,
                },
                new Student
                {
                    Id = 5,
                    Name = "Pablo",
                    Grade = 35,
                    Certificate = false,
                },
            };

            var approveQuery = classRoom.GroupBy(student => student.Certificate);

            foreach (var approve in approveQuery)
            {
                Console.WriteLine("-----------{0}----------", approve.Key);
                foreach (var student in approve)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }

        static public void relationsLinq()
        {

            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id=1,
                    Title= "My firts post",
                    Content = "My firts content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 1,
                            Created = DateTime.Now,
                            Title = "My firts comment",
                            Content = "My content",
                        },
                        new Comment()
                        {
                            Id = 2,
                            Created = DateTime.Now,
                            Title = "My second comment",
                            Content = "My second content",
                        },
                        new Comment()
                        {
                            Id = 3,
                            Created = DateTime.Now,
                            Title = "My other comment",
                            Content = "My other content",
                        }
                    }

                },
                new Post()
                {
                    Id=2,
                    Title= "My second post",
                    Content = "My second content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 4,
                            Created = DateTime.Now,
                            Title = "My new comment",
                            Content = "My new content",
                        },
                        new Comment()
                        {
                            Id = 5,
                            Created = DateTime.Now,
                            Title = "My new2 comment",
                            Content = "My new2 second content",
                        },
                        new Comment()
                        {
                            Id = 6,
                            Created = DateTime.Now,
                            Title = "My new other comment",
                            Content = "My new other content",
                        }
                    }

                },

            };

            var commentsContent = posts.SelectMany(
                post => post.Comments,
                (post, Comment) => new 
                { PostIdc = post.Id, CommentsContent = Comment.Content });



        }
    }
}