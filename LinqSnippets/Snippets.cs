using System;
using System.Collections.Generic;
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

            foreach ( var car in carList )
            {
                Console.WriteLine( car );
            }

            //2 Select where
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach( var audi in audiList )
            {
                Console.WriteLine( audi );
            }
            
        }

        // Number examle
        static public void LinqNumbers() { 
        
            List<int> numbers = new List<int> {1,2,3,4,5,6,7,8,9};

            //Each number multiplied by 3
            //take all numbers, but 9
            //Order number by ascending value

            var processedNumberList = numbers
                .Select(num => num*3)
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

            int[] eventNumbers = { 0,2,4,6,8 };
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
            var firtsList = new List<string>() { "a", "b", "c"};
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
                (element, secondElement) => new { element, secondElement}
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
                                 secondList.Where(s=>s==element).DefaultIfEmpty()
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



    }
}
