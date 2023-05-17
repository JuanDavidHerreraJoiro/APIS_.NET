using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinq()
        {
            string[] cars = {
                "VM Golf",
                "VM California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Sear Leon"
            };

            //1 Select * from cars
            var carList = from car in cars select car;

            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            //2 Select where
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }

        }

        // Number examle
        static public void LinqNumbers()
        {

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Each number multiplied by 3
            //take all numbers, but 9
            //Order number by ascending value

            var processedNumberList = numbers
                .Select(num => num * 3)
                .Where(num => num != 9)
                .OrderBy(num => num);
        }

        static public void SearchExamples()
        {

            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "f",
                "c"
            };

            //1. fist of all elements
            var first = textList.First();

            // 2. fist elements that is "c"
            var cText = textList.First(text => text.Equals("c"));

            // 3. fist elements that contains "c"
            var jText = textList.First(text => text.Contains("j"));

            // 4. fist elements that contains "z" or default
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z"));

            // 5. last elements that contains "z" or default
            var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z"));

            // 6. Single values
            var uniqueText = textList.Single();

            // 7. SingleOrDefault values
            var uniqueSingleOrDefaultText = textList.SingleOrDefault();

            int[] eventNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEventNumbers = { 0, 2, 6 };

            // obtain {4,8}
            var myEvenNumbers = eventNumbers.Except(otherEventNumbers);

        }


        static public void MultipleSelects()
        {
            // Select many
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"
            };

            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee()
                        {
                            Id = 1,
                            Name = "Juan Herrera",
                            Email = "juandherreraj@gmail.com",
                            Salary = 3000,
                        },
                        new Employee()
                        {
                            Id = 2,
                            Name = "Maria Joiro",
                            Email = "mariajoiro@gmail.com",
                            Salary = 1000,
                        },
                        new Employee()
                        {
                            Id = 3,
                            Name = "Jose Herrera",
                            Email = "joseherreraj@gmail.com",
                            Salary = 20000,
                        }
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee()
                        {
                            Id = 4,
                            Name = "Juan villa",
                            Email = "juanvilla@gmail.com",
                            Salary = 4000,
                        },
                        new Employee()
                        {
                            Id = 5,
                            Name = "Luis Perdomo",
                            Email = "luisperdomo@gmail.com",
                            Salary = 100000,
                        },
                        new Employee()
                        {
                            Id = 6,
                            Name = "Jose pineda",
                            Email = "josepineda@gmail.com",
                            Salary = 10000,
                        }
                    }
                }
            };

            // obtain all employees of all enterprises
            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);

            //Know if ana list is empty

            bool hasEnterprises = enterprises.Any();

            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());

            //All enterprises at least has an employee with more than 1000 salary
            bool hasEmployeesWhithSalaryMoreThanEqual1000 =
                enterprises.Any(enterprise =>
                enterprise.Employees.Any(
                    employee => employee.Salary >= 1000
                    )
                );

        }

        static public void linqCollections()
        {
            var firtsList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            //INNER JOIN
            var commonresult = from element in firtsList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondList };

            var commonresult2 = firtsList.Join(
                secondList,
                element => element,
                secondElement => secondElement,
                (element, secondElement) => new { element, secondElement }
                );

            //OUTER JOIN - LEFT
            var leftOuterJoin = from element in firtsList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            var leftOuterJoin2 = from element in firtsList
                                 from secondElement in
                                 secondList.Where(s => s == element).DefaultIfEmpty()
                                 select new { Element = element, SecondElement = secondElement };

            //OUTER JOIN - RIGHT //corregir
            var rightOuterJoin = from secondElement in secondList
                                 join element in firtsList
                                on secondElement equals element
                                into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where secondElement != temporalElement
                                 select new { Element = secondElement };

            //UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);
        }

        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9,10
            };

            //SKIP

            var skipTwoFirstValue = myList.Skip(2);

            var skipLastTwoValue = myList.SkipLast(2);

            var skipWhileSmallerThan4 = myList.SkipWhile(num => num < 4);

            //TAKE

            var takeFirstTwoValue = myList.Take(2);

            var takeLastTwoValue = myList.TakeLast(2);

            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4);

        }

        //Paging with skip & take
        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerpage)
        {
            int startIndex = (pageNumber - 1) * resultsPerpage;
            return collection.Skip(startIndex).Take(resultsPerpage);
        }

        //Variables
        static public void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquared = Math.Pow(number, 2)
                               where nSquared > average
                               select number;

            Console.WriteLine("Avegare: {0}", numbers.Average());

            foreach (var number in aboveAverage)
            {
                Console.WriteLine("Number: {0} Square: {1} ", number, Math.Pow(number, 2));
            }
        }

        //ZIP
        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers,(number,word) =>number+"="+word);

        }

        //Repeat & Range
        static public void RepeatRangeLinq()
        {
            //Generate collection from 1 - 1000 
            var first1000 = Enumerable.Range(1,1000);

            //Repeat a value N times
            var fiveXs = Enumerable.Repeat("X", 5);
        }

        //ALL
        static public void studentsLinq()
        {
            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Juan",
                    Grade = 30,
                    Certified = true
                },
                new Student
                {
                    Id = 2,
                    Name = "David",
                    Grade = 90,
                    Certified = true
                },
                new Student
                {
                    Id = 3,
                    Name = "Maria",
                    Grade = 30 ,
                    Certified = false
                }
            };

            var certifiedStudents = from student in classRoom 
                                    where student.Certified 
                                    select student;

            var notCertifiedStudents = from student in classRoom
                                    where student.Certified == false
                                    select student;

            var appovedStudentsNames = from student in classRoom
                                  where student.Grade >= 50 && student.Certified == true
                                  select student.Name;
        }

        //ALL
        static public void AllLinq()
        {
            var numbers = new List<int>() { 1,2,3,4,5};
            bool allAreSmallerThan10 = numbers.All(x => x < 10); //true
            bool allAreBiggerOrEqualThan2 = numbers.All(x => x >= 2); //false

            var emtyList = new List<int>();
            bool allNumberAreGreaterThan0 = numbers.All(x => x >=0); //true

        }

        //Aggregate
        static public void aggregateQueries()
        {
            int[] numbers = { 1, 2, 4, 5, 6, 7, 8, 9, 10 };

            int sum = numbers.Aggregate((prevSum,current) => prevSum+current);

            string[] word = { "hello","my","name","is","juan" }; //hello my name is juan
            string greeting = word.Aggregate((prevGreeting, current) => prevGreeting+current);
        }
        //Disctict
        static public void distinctValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5,4,3,2,1 };

            IEnumerable<int> distinctValues = numbers.Distinct();
           
        }

        //GroupBy
        static public void groubByExamples()
        {
            List<int> numbers = new List<int>(){ 1, 2, 3, 4, 5, 6,7,8,9 };

            //obtain only even numbers and generate two groups

            var grouped = numbers.GroupBy(x => x%2 == 0);

            //We will have two group
            //1. the group that doesnt fit the condition (odd numbers)
            //2. the group the fits the condition (even numbers)

            foreach (var group in grouped)
            {
                foreach (var value in group)
                {
                    Console.WriteLine(value);
                    //1,3,5,7,9
                    //2,4,6,8,
                    //(first the odds and then the even)
                }
            }

            // another example

            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Juan",
                    Grade = 30,
                    Certified = true
                },
                new Student
                {
                    Id = 2,
                    Name = "David",
                    Grade = 90,
                    Certified = true
                },
                new Student
                {
                    Id = 3,
                    Name = "Maria",
                    Grade = 30 ,
                    Certified = false
                }
            };

            var certifiedQuery = classRoom.GroupBy(student => student.Certified);
            //we obtain two grouos
            //1. Not certified students
            //2. certified students
        }


        public static void relationsLinq() 
        {
            List<Post> posts = new List<Post>() 
            { 
                new Post ()
                {
                    Id = 1,
                    Title = "My first post",
                    Content = "My first content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 1,
                            Created = DateTime.Now,
                            Title = "My first comment",
                            Content = "My content"
                        },
                        new Comment()
                        {
                            Id = 2,
                            Created = DateTime.Now,
                            Title = "My second comment",
                            Content = "My second content"
                        }
                    }
                },
                new Post ()
                {
                    Id = 2,
                    Title = "My second post",
                    Content = "My second content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 3,
                            Created = DateTime.Now,
                            Title = "My tree comment",
                            Content = "My content"
                        },
                        new Comment()
                        {
                            Id = 4,
                            Created = DateTime.Now,
                            Title = "My four comment",
                            Content = "My four content"
                        }
                    }
                }
            };

            var commentsContent = posts.SelectMany(
                post => post.Comments, (post, comment)=> new { PostID = post.Id, CommentContent = comment.Content });

        }
    }
}
