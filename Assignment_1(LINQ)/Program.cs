using LINQ.DataSources;
namespace Assignment_1_LINQ_ 
{
    internal class Program
    {
        static void Main()
        {
            //Q1:
            var q1 = Source.ProductList.Where(p => p.Category == "Seafood");
            foreach (var p in q1)
            {
                Console.WriteLine($"Name: {p.ProductName}, Price: {p.UnitPrice}");
            }

            // Q2:
            var q2 = Source.ProductList.Select(p => p.ProductName);
            foreach (var name in q2)
            {
                Console.WriteLine(name);
            }

            // Q3:
            var q3 = Source.ProductList.OrderBy(p => p.UnitPrice);
            foreach (var p in q3)
            {
                Console.WriteLine($"Name: {p.ProductName}, Price: {p.UnitPrice}");
            }

            // Q4:
            var q4 = Source.ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
            foreach (var p in q4)
            {
                Console.WriteLine($"Name: {p.ProductName}, Price: {p.UnitPrice}");
            }

            // Q5:
            var q5 = Source.ProductList.Where(p => p.UnitsInStock > 0 && p.Category.Contains("Condiments"));
            foreach (var p in q5)
            {
                Console.WriteLine($"Name: {p.ProductName}, Category: {p.Category}, Stock: {p.UnitsInStock}");
            }

            // Q6:
            var q6 = Source.ProductList.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });
            foreach (var item in q6)
            {
                Console.WriteLine($"Name: {item.Name}, Price: {item.Price}, Status: {item.StockStatus}");
            }

            // Q7:
            var q7 = Source.ProductList.Select((p, index) => $"{index + 1}. {p.ProductName}");
            foreach (var item in q7)
            {
                Console.WriteLine(item);
            }

            // Q8:
            var q8 = Source.ProductList
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);
            foreach (var p in q8)
            {
                Console.WriteLine($"Category: {p.Category}, Price: {p.UnitPrice}, Name: {p.ProductName}");
            }

            // Q9:
            var q9 = Source.ProductList
                .Where(p => p.Category == "Beverages")
                .OrderByDescending(p => p.UnitsInStock);
            foreach (var p in q9)
            {
                Console.WriteLine($"Name: {p.ProductName}, Stock: {p.UnitsInStock}");
            }

            // Q10:
            var q10 = from customer in Source.CustomerList
                      from order in customer.Orders
                      where order.OrderDate.Year >= 1997
                      select new { customer.CustomerID, order.OrderDate };
            foreach (var item in q10)
            {
                Console.WriteLine($"CustomerID: {item.CustomerID}, OrderDate: {item.OrderDate.ToShortDateString()}");
            }

            // Q11:
            var q11 = Source.ProductList.Select((p, index) => new { Position = index + 1, p.ProductName });
            foreach (var item in q11)
            {
                Console.WriteLine($"Position: {item.Position}, Name: {item.ProductName}");
            }

            // Q12:
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var q12 = Arr.OrderBy(w => w.Length)
                         .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var word in q12)
            {
                Console.WriteLine(word);
            }

            // Q13:
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var q13 = digits.Where(d => d.Length > 1 && d[1] == 'i')
                            .Reverse();
            foreach (var digit in q13)
            {
                Console.WriteLine(digit);
            }

        }
    }
}
