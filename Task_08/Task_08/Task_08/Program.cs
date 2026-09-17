
using System;

namespace Task_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("            C# OOP EXERCISES DEMO");
            Console.WriteLine("==================================================\n");

            // --- Problem 1 Demo ---
            Console.WriteLine("--- 1. Interface Implementation (IVehicle) ---");
            Problem1_Demo();

            // --- Problem 2 Demo ---
            Console.WriteLine("\n--- 2. Abstract Class vs Interface (Shape) ---");
            Problem2_Demo();

            // --- Problem 3 Demo ---
            Console.WriteLine("\n--- 3. IComparable Interface (Product Sorting) ---");
            Problem3_Demo();

            // --- Problem 4 Demo ---
            Console.WriteLine("\n--- 4. Copy Constructor & Deep Copy (Student) ---");
            Problem4_Demo();

            // --- Problem 5 Demo ---
            Console.WriteLine("\n--- 5. Explicit Interface Implementation (Robot) ---");
            Problem5_Demo();

            // --- Problem 6 Demo ---
            Console.WriteLine("\n--- 6. Encapsulation in Structs (Account) ---");
            Problem6_Demo();

            // --- Problem 7 Explanation ---
            Console.WriteLine("\n--- 7. Abstraction vs Encapsulation ---");
            Problem7_Explanation();

            // --- Problem 8 Demo ---
            Console.WriteLine("\n--- 8. Default Interface Implementation (ILogger) ---");
            Problem8_Demo();

            // --- Problem 9 Demo ---
            Console.WriteLine("\n--- 9. Constructor Overloading (Book) ---");
            Problem9_Demo();

            Console.WriteLine("\n==================================================");
            Console.WriteLine("               END OF DEMONSTRATION");
            Console.WriteLine("==================================================");
        }

        #region Problem 1: Interface Implementation (IVehicle)
        /*
         * QUESTION: Why is it better to code against an interface rather than a concrete class?
         * ANSWER: Coding against an interface promotes loose coupling, enhances code maintainability,
         * and makes testing easier (by allowing mock objects). It enables polymorphic behavior where
         * concrete implementations can be swapped without changing client code.
         */
        static void Problem1_Demo()
        {
            IVehicle car = new Car();
            IVehicle bike = new Bike();

            car.StartEngine();
            car.StopEngine();

            bike.StartEngine();
            bike.StopEngine();
        }
        #endregion

        #region Problem 2: Abstract Class (Shape)
        /*
         * QUESTION: When should you prefer an abstract class over an interface?
         * ANSWER: Prefer an abstract class when:
         * 1. You want to share common implementation code (like Display() method) across related classes.
         * 2. You need non-public members (protected, internal) or fields/state in the base class.
         * 3. The classes share a strong "is-a" logical hierarchy.
         */
        static void Problem2_Demo()
        {
            Shape rectangle = new Rectangle(5.0, 4.0);
            Shape circle = new Circle(3.0);

            Console.Write("Rectangle -> ");
            rectangle.Display();

            Console.Write("Circle -> ");
            circle.Display();
        }
        #endregion

        #region Problem 3: IComparable Interface (Product Sorting)
        /*
         * QUESTION: How does implementing IComparable improve flexibility in sorting?
         * ANSWER: Implementing IComparable defines a default natural sort order for custom objects.
         * It allows standard framework sorting methods (like Array.Sort or List<T>.Sort) to automatically
         * organize collections without requiring custom comparison logic every time.
         */
        static void Problem3_Demo()
        {
            Product[] products = new Product[]
            {
                new Product(101, "Laptop", 1200.00),
                new Product(102, "Mouse", 25.50),
                new Product(103, "Keyboard", 75.00)
            };

            Console.WriteLine("Before Sorting:");
            foreach (var p in products) Console.WriteLine($"  {p}");

            Array.Sort(products);

            Console.WriteLine("After Sorting by Price (Ascending):");
            foreach (var p in products) Console.WriteLine($"  {p}");
        }
        #endregion

        #region Problem 4: Copy Constructor & Deep Copy (Student)
        /*
         * QUESTION: What is the primary purpose of a copy constructor in C#?
         * ANSWER: The primary purpose of a copy constructor is to instantiate a new object with state copied 
         * from an existing object. It ensures reference-type fields are cloned (Deep Copy) so modifications 
         * to the new instance do not affect the original instance.
         */
        static void Problem4_Demo()
        {
            Student original = new Student(1, "Ahmed", new int[] { 90, 85, 92 });

            // Shallow copy using reference assignment
            Student shallowCopy = original;

            // Deep copy using Copy Constructor
            Student deepCopy = new Student(original);

            // Modify original grade array
            original.Grades[0] = 100;

            Console.WriteLine($"Original Grade[0]: {original.Grades[0]}");
            Console.WriteLine($"Shallow Copy Grade[0] (Affected): {shallowCopy.Grades[0]}");
            Console.WriteLine($"Deep Copy Grade[0] (Independent): {deepCopy.Grades[0]}");
        }
        #endregion

        #region Problem 5: Explicit Interface Implementation (Robot)
        /*
         * QUESTION: How does explicit interface implementation help in resolving naming conflicts?
         * ANSWER: If a class implements multiple interfaces containing methods with identical signatures,
         * or if a class already has a member with the same name, explicit implementation qualifies the method
         * with the interface name (e.g., IWalkable.Walk). This avoids ambiguity and ensures distinct implementations.
         */
        static void Problem5_Demo()
        {
            Robot robot = new Robot();
            robot.Walk(); // Calls Robot's own Walk method

            IWalkable walkableRobot = robot;
            walkableRobot.Walk(); // Calls IWalkable's explicit implementation
        }
        #endregion

        #region Problem 6: Encapsulation in Structs (Account)
        /*
         * QUESTION: What is the key difference between encapsulation in structs and classes?
         * ANSWER: Structs are value types stored on the stack, so passing/assigning them creates a full copy.
         * Encapsulation in structs protects internal state per instance, but mutating a copy of a struct 
         * does not mutate the original struct instance, unlike reference types (classes) stored on the heap.
         */
        static void Problem6_Demo()
        {
            Account account = new Account(1001, "Sara Ali", 5000.00);
            Console.WriteLine($"Account ID: {account.AccountId}, Holder: {account.AccountHolder}, Balance: ${account.Balance}");

            // Testing validation logic in encapsulating property
            account.Balance = -200; // Invalid, balance will remain 5000
            Console.WriteLine($"Balance after invalid update attempt: ${account.Balance}");

            account.Balance = 5500.00;
            Console.WriteLine($"Balance after valid update: ${account.Balance}");
        }
        #endregion

        #region Problem 7: Abstraction vs Encapsulation
        /*
         * QUESTION: What is abstraction as a guideline, and what's its relation with encapsulation?
         * ANSWER: 
         * - Abstraction is the concept of exposing only relevant features while hiding complex background logic (Focuses on WHAT an object does).
         * - Encapsulation is the mechanism of bundling data and methods together and restricting direct access to object state (Focuses on HOW data is protected).
         * - Relation: Encapsulation is the technique used to achieve Abstraction. Encapsulation hides details inside a class boundary, exposing a simplified abstract interface to the outside world.
         */
        static void Problem7_Explanation()
        {
            Console.WriteLine("Abstraction hides complexity and shows only relevant features (Focuses on WHAT).");
            Console.WriteLine("Encapsulation restricts direct access to data using private variables & properties (Focuses on HOW).");
            Console.WriteLine("Relation: Encapsulation is the mechanism used to implement Abstraction.");
        }
        #endregion

        #region Problem 8: Default Interface Implementation (ILogger)
        /*
         * QUESTION: How do default interface implementations affect backward compatibility in C#?
         * ANSWER: Default interface implementations allow developers to add new methods to existing interfaces
         * without breaking existing implementation classes. Legacy classes automatically inherit the default logic 
         * without throwing compilation errors.
         */
        static void Problem8_Demo()
        {
            ILogger defaultLogger = new DefaultLogger();
            defaultLogger.Log("Message using default implementation.");

            ILogger customLogger = new ConsoleLogger();
            customLogger.Log("Message using overridden implementation.");
        }
        #endregion

        #region Problem 9: Constructor Overloading (Book)
        /*
         * QUESTION: How does constructor overloading improve class usability?
         * ANSWER: Constructor overloading provides flexibility when instantiating objects. It allows callers
         * to create objects with varying levels of detail based on available data, reducing the need for setter method chains.
         */
        static void Problem9_Demo()
        {
            Book b1 = new Book();
            Book b2 = new Book("Design Patterns");
            Book b3 = new Book("Clean Code", "Robert C. Martin");

            Console.WriteLine($"Book 1: {b1.Title} by {b1.Author}");
            Console.WriteLine($"Book 2: {b2.Title} by {b2.Author}");
            Console.WriteLine($"Book 3: {b3.Title} by {b3.Author}");
        }
        #endregion
    }

    #region --- PROBLEM 1 CLASSES & INTERFACES ---
    public interface IVehicle
    {
        void StartEngine();
        void StopEngine();
    }

    public class Car : IVehicle
    {
        public void StartEngine() => Console.WriteLine("Car engine started.");
        public void StopEngine() => Console.WriteLine("Car engine stopped.");
    }

    public class Bike : IVehicle
    {
        public void StartEngine() => Console.WriteLine("Bike engine started.");
        public void StopEngine() => Console.WriteLine("Bike engine stopped.");
    }
    #endregion

    #region --- PROBLEM 2 CLASSES & INTERFACES ---
    public abstract class Shape
    {
        // Abstract method (must be implemented by derived classes)
        public abstract double GetArea();

        // Non-abstract method (shared implementation)
        public void Display()
        {
            Console.WriteLine($"Shape Area: {GetArea():F2}");
        }
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double GetArea() => Width * Height;
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius) => Radius = radius;

        public override double GetArea() => Math.PI * Radius * Radius;
    }
    #endregion

    #region --- PROBLEM 3 CLASSES & INTERFACES ---
    public class Product : IComparable<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        // IComparable implementation to sort by Price
        public int CompareTo(Product other)
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }

        public override string ToString() => $"[ID: {Id}] {Name} - ${Price:F2}";
    }
    #endregion

    #region --- PROBLEM 4 CLASSES & INTERFACES ---
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int[] Grades { get; set; }

        public Student(int id, string name, int[] grades)
        {
            Id = id;
            Name = name;
            Grades = grades;
        }

        // Copy Constructor (Deep Copy)
        public Student(Student other)
        {
            Id = other.Id;
            Name = other.Name;
            // Deep copy of the array so references are not shared
            if (other.Grades != null)
            {
                Grades = new int[other.Grades.Length];
                Array.Copy(other.Grades, Grades, other.Grades.Length);
            }
        }
    }
    #endregion

    #region --- PROBLEM 5 CLASSES & INTERFACES ---
    public interface IWalkable
    {
        void Walk();
    }

    public class Robot : IWalkable
    {
        // Class's own Walk method
        public void Walk()
        {
            Console.WriteLine("Robot is moving on wheels (Class method).");
        }

        // Explicit interface implementation
        void IWalkable.Walk()
        {
            Console.WriteLine("Robot is performing standard bipedal walk (Explicit IWalkable method).");
        }
    }
    #endregion

    #region --- PROBLEM 6 CLASSES & INTERFACES ---
    public struct Account
    {
        private int accountId;
        private string accountHolder;
        private double balance;

        public int AccountId => accountId;
        public string AccountHolder => accountHolder;

        public double Balance
        {
            get => balance;
            set
            {
                if (value >= 0)
                    balance = value;
                else
                    Console.WriteLine("Warning: Balance cannot be negative!");
            }
        }

        public Account(int accountId, string accountHolder, double initialBalance)
        {
            this.accountId = accountId;
            this.accountHolder = accountHolder;
            this.balance = initialBalance >= 0 ? initialBalance : 0;
        }
    }
    #endregion

    #region --- PROBLEM 8 CLASSES & INTERFACES ---
    public interface ILogger
    {
        // Default interface implementation
        void Log(string message)
        {
            Console.WriteLine($"[DEFAULT LOG]: {message}");
        }
    }

    // Class using default interface implementation
    public class DefaultLogger : ILogger
    {
    }

    // Class overriding default implementation
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[CONSOLE OVERRIDE LOG]: {message}");
        }
    }
    #endregion

    #region --- PROBLEM 9 CLASSES & INTERFACES ---
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        // Default Constructor
        public Book() : this("Untitled", "Unknown Author")
        {
        }

        // Overload 1: Takes Title only
        public Book(string title) : this(title, "Unknown Author")
        {
        }

        // Overload 2: Takes Title and Author
        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }
    #endregion
}