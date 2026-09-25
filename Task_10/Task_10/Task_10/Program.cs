using System;
using System.Collections.Generic;

namespace Task_10
{
    // ==========================================
    // 1. SHARED CLASSES AND DELEGATES
    // ==========================================

    public class Employee : IComparable<Employee>, ICloneable
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        public int CompareTo(Employee? other)
        {
            if (other == null) return 1;
            return Salary.CompareTo(other.Salary);
        }

        public object Clone()
        {
            return new Employee(Name, Salary);
        }

        public override string ToString() => $"{Name} - {Salary:C}";
    }

    public class Manager : Employee, IComparable<Manager>
    {
        public Manager(string name, decimal salary) : base(name, salary) { }

        public int CompareTo(Manager? other)
        {
            if (other == null) return 1;
            return Salary.CompareTo(other.Salary);
        }
    }

    public static class SortingAlgorithm<T> where T : ICloneable
    {
        public static void Sort(T[] arr, Comparison<T> comparer)
        {
            Array.Sort(arr, comparer);
        }

        // Generic Swap Method
        public static void Swap<TElement>(ref TElement a, ref TElement b)
        {
            TElement temp = a;
            a = b;
            b = temp;
        }
    }

    public static class SortingTwo<T>
    {
        public static void Sort(T[] arr, Comparison<T> comparer)
        {
            Array.Sort(arr, comparer);
        }
    }

    // Custom Generic Delegate Definition
    public delegate R GenericTransformer<T, R>(T input);
    public delegate string StringTransformer(string input);
    public delegate int MathOperation(int a, int b);

    // ==========================================
    // 2. MAIN PROGRAM IMPLEMENTATION
    // ==========================================

    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Task 10: Part 01 Solution ===\n");

            // ------------------------------------------
            // Problem 01: Generic Sorting for Employee Salary
            // Q1: Benefits of generic sorting?
            // - Type safety at compile-time.
            // - Prevents performance overhead (no boxing/unboxing).
            // - Reusability across multiple data types.
            // ------------------------------------------
            Employee[] employees = {
                new Employee("Ali", 5000),
                new Employee("Mona", 8000),
                new Employee("Ahmed", 4000)
            };
            SortingTwo<Employee>.Sort(employees, (e1, e2) => e1.Salary.CompareTo(e2.Salary));

            // ------------------------------------------
            // Problem 02: Dynamic Sort Integers Descending via Lambda
            // Q2: How do lambdas improve readability and flexibility?
            // - Provides concise inline syntax without declaring external methods.
            // - Allows dynamic sorting rules defined right at the call site.
            // ------------------------------------------
            int[] numbers = { 5, 2, 8, 1, 9 };
            SortingTwo<int>.Sort(numbers, (a, b) => b.CompareTo(a));

            // ------------------------------------------
            // Problem 03: String Length Comparer Function
            // Q3: Importance of dynamic comparer functions?
            // - Enables changing sorting behavior at runtime (length, alphabetical, etc.)
            //   without modifying class structures.
            // ------------------------------------------
            string[] names = { "Omar", "Abdelrahman", "Ali", "Mostafa" };
            SortingTwo<string>.Sort(names, (s1, s2) => s1.Length.CompareTo(s2.Length));

            // ------------------------------------------
            // Problem 04: Manager Class & IComparable<T>
            // Q4: How does IComparable<T> enable custom sorting?
            // - Establishes a natural/default sorting order for types so .NET methods
            //   like Array.Sort know how to compare instances automatically.
            // ------------------------------------------
            Manager[] managers = {
                new Manager("Sara", 12000),
                new Manager("Hassan", 9000)
            };
            SortingTwo<Manager>.Sort(managers, (m1, m2) => m1.CompareTo(m2));

            // ------------------------------------------
            // Problem 05: Delegate Func<T, T, bool> for Name Length Comparison
            // Q5: Advantages of built-in delegates like Func?
            // - Eliminates boilerplate delegate declarations and standardizes delegate usage.
            // ------------------------------------------
            Func<Employee, Employee, bool> isFirstLonger = (e1, e2) => e1.Name.Length > e2.Name.Length;
            Array.Sort(employees, (e1, e2) => isFirstLonger(e1, e2) ? 1 : -1);

            // ------------------------------------------
            // Problem 06: Anonymous Function vs Lambda Expression
            // Q6: Difference in readability and efficiency?
            // - Readability: Lambda expressions are significantly cleaner and less verbose.
            // - Efficiency: Identical at runtime (both compile to equivalent IL code).
            // ------------------------------------------
            int[] nums = { 4, 1, 3, 2 };
            Array.Sort(nums, delegate (int x, int y) { return x.CompareTo(y); }); // Anonymous
            Array.Sort(nums, (x, y) => x.CompareTo(y));                          // Lambda

            // ------------------------------------------
            // Problem 07: Generic Swap Method
            // Q7: Why use generic methods for utilities like Swap?
            // - Works on any type without duplication or boxing/unboxing overhead.
            // ------------------------------------------
            int a = 10, b = 20;
            SortingAlgorithm<Employee>.Swap(ref a, ref b);

            // ------------------------------------------
            // Problem 08: Multi-criteria Sorting (Salary then Name)
            // Q8: Challenges and benefits of multi-criteria sorting?
            // - Benefits: Provides accurate, highly organized tie-breaking.
            // - Challenges: Slightly higher complexity and conditional logic evaluation.
            // ------------------------------------------
            SortingTwo<Employee>.Sort(employees, (e1, e2) => {
                int salaryCompare = e1.Salary.CompareTo(e2.Salary);
                return salaryCompare != 0 ? salaryCompare : e1.Name.CompareTo(e2.Name);
            });

            // ------------------------------------------
            // Problem 09: GetDefault Method using default(T)
            // Q9: Why is default(T) crucial in generic programming?
            // - Initializes unknown generic types safely: zero-values for value types, null for reference types.
            // ------------------------------------------
            int defaultInt = GetDefault<int>();
            Employee defaultEmp = GetDefault<Employee>();

            // ------------------------------------------
            // Problem 10: Generic Constraint where T : ICloneable
            // Q10: How do generic constraints ensure type safety?
            // - Restricts generic arguments to types that implement required interfaces, preventing runtime errors.
            // ------------------------------------------
            Employee[] originalEmps = { new Employee("Ziad", 6000) };
            Employee[] clonedEmps = (Employee[])originalEmps.Clone();
            SortingAlgorithm<Employee>.Sort(clonedEmps, (e1, e2) => e1.Salary.CompareTo(e2.Salary));

            // ------------------------------------------
            // Problem 11: Delegate for String Transformations
            // Q11: Benefits of delegates for functional string transformations?
            // - Decouples iteration logic from transformation logic for maximum reusability.
            // ------------------------------------------
            List<string> words = new List<string> { "hello", "world" };
            List<string> uppercaseWords = TransformStrings(words, s => s.ToUpper());

            // ------------------------------------------
            // Problem 12: Delegate for Math Operations
            // Q12: How delegates promote code reusability in math?
            // - Pass functions as arguments to execute flexible operations without switch statements.
            // ------------------------------------------
            int sum = ComputeMath(10, 5, (x, y) => x + y);
            int product = ComputeMath(10, 5, (x, y) => x * y);

            // ------------------------------------------
            // Problem 13: Generic Delegate Data Transformation
            // Q13: Advantages of generic delegates in transforming structures?
            // - Maps any collection of type T into a collection of type R safely and dynamically.
            // ------------------------------------------
            List<int> intList = new List<int> { 1, 2, 3 };
            List<string> stringified = MapList(intList, num => $"Value: {num}");

            // ------------------------------------------
            // Problem 14: Func<T, TResult> to Square Integers
            // Q14: How Func simplifies creation/usage of delegates?
            // - Provides pre-declared generic delegate types, saving manual delegate creation.
            // ------------------------------------------
            Func<int, int> squareFunc = x => x * x;
            List<int> squaredNumbers = ApplyFunc(intList, squareFunc);

            // ------------------------------------------
            // Problem 15: Action<T> for Void Printing
            // Q15: Why Action is preferred for operations without return values?
            // - Explicitly signals side-effects returning void (e.g., printing or writing to DB).
            // ------------------------------------------
            Action<string> printAction = str => Console.WriteLine(str);
            ExecuteAction(words, printAction);

            // ------------------------------------------
            // Problem 16: Predicate<T> to Filter Even Numbers
            // Q16: Role of predicates in functional programming?
            // - Encapsulates conditional criteria returning bool to clarify filtering intent.
            // ------------------------------------------
            Predicate<int> isEven = x => x % 2 == 0;
            List<int> evens = FilterList(intList, isEven);

            // ------------------------------------------
            // Problem 17: Filter List of Strings using Anonymous Function
            // Q17: How anonymous functions improve modularity?
            // - Defines specific criteria inline without polluting the class with single-use methods.
            // ------------------------------------------
            List<string> startsWithH = FilterStrings(words, delegate (string s) { return s.StartsWith("h"); });

            // ------------------------------------------
            // Problem 18: Math Operation via Anonymous Function
            // Q18: When to prefer anonymous functions over named methods?
            // - When the operation is short, temporary, and localized to one specific section.
            // ------------------------------------------
            Func<int, int, int> anonMultiply = delegate (int x, int y) { return x * y; };
            int anonResult = anonMultiply(4, 5);

            // ------------------------------------------
            // Problem 19: Filter List of Strings using Lambda Expression
            // Q19: What makes lambda expressions essential in modern C#?
            // - Serves as the foundation for LINQ, enabling concise, functional data queries.
            // ------------------------------------------
            List<string> lambdaFiltered = FilterStrings(words, s => s.Length > 3 || s.Contains('e'));

            // ------------------------------------------
            // Problem 20: Math Operations using Lambda Expressions
            // Q20: How lambdas enhance mathematical expressiveness?
            // - Expresses calculations using pure mathematical notation syntax.
            // ------------------------------------------
            Func<double, double, double> power = (baseVal, exp) => Math.Pow(baseVal, exp);
            double powResult = power(2, 3);

            Console.WriteLine("All Part 01 problems executed successfully!");
        }

        // ==========================================
        // 3. HELPER METHODS FOR PROBLEMS
        // ==========================================

        public static T GetDefault<T>() => default(T)!;

        public static List<string> TransformStrings(List<string> list, StringTransformer transformer)
        {
            List<string> result = new List<string>();
            foreach (var item in list) result.Add(transformer(item));
            return result;
        }

        public static int ComputeMath(int a, int b, MathOperation op) => op(a, b);

        public static List<R> MapList<T, R>(List<T> list, GenericTransformer<T, R> transformer)
        {
            List<R> result = new List<R>();
            foreach (var item in list) result.Add(transformer(item));
            return result;
        }

        public static List<int> ApplyFunc(List<int> numbers, Func<int, int> op)
        {
            List<int> result = new List<int>();
            foreach (var n in numbers) result.Add(op(n));
            return result;
        }

        public static void ExecuteAction(List<string> list, Action<string> action)
        {
            foreach (var item in list) action(item);
        }

        public static List<int> FilterList(List<int> list, Predicate<int> predicate)
        {
            return list.FindAll(predicate);
        }

        public static List<string> FilterStrings(List<string> list, Predicate<string> condition)
        {
            return list.FindAll(condition);
        }
    }
}