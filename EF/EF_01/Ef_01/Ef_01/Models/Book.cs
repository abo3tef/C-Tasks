using System;

namespace Ef_01.Models
{
    // Q1: Why did the property "Id" become a Primary Key without any explicit configuration?
    // Ans: Because of EF Core naming conventions; any property named "Id" or "[ClassName]Id" is automatically treated as the Primary Key.
    // 
    // Q2: Why is "Country" nullable in the database while "Price" is not?
    // Ans: "Price" is a value type (decimal) which is non-nullable by default in C#, whereas string/DateTime? are reference types or explicitly nullable, so EF Core maps non-nullable as NOT NULL and others as NULL.

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}