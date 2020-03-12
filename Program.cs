using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AppCSharp
{
    // -----------------------------------------------------------------------------
    // KISS / BUZI
    // Keep It Simple Stupid
    // -----------------------------------------------------------------------------
    // klasa ktora dla dwoch przechowywanych liczb wyznacza ich min oraz max
    class MyClass
    {
        private int n1;
        private int n2;

        public MyClass() {}
        
        public MyClass(int n1, int n2)
        {
            this.n1 = n1;
            this.n2 = n2;
        }

        public int met1()
        {
            return Math.Min(n1, n2);
        }

        public int met2()
        {
            return Math.Max(n1, n2);
        }
    } 
    
    // -----------------------------------------------------------------------------
    // DRY
    // Don't Repeat Yourself
    // -----------------------------------------------------------------------------

    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Name} {Price}";
        }
    }
    
    class ProductsService
    {
        public ICollection<Product> Products { get; }

        public ProductsService()
        {
            Products = new List<Product>();
        }

        public void Remove(string name)
        {
            var productToRemove = Products.ToList().Single(p => string.Equals(p.Name, name));
            Products.Remove(productToRemove);
        }

        public Product GetByName(string name)
        {
            return Products.ToList().Single(p => string.Equals(p.Name, name));
        }

        public void ChangePrice(string name, decimal newPrice)
        {
            var productToChange = Products.ToList().Single(p => string.Equals(p.Name, name));
            productToChange.Price = newPrice;
        }
    }


    // -----------------------------------------------------------------------------
    // TDA
    // Tell Don't Ask
    // -----------------------------------------------------------------------------

    class Order
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        
        public decimal CalculateTax(int taxQuantity)
        {
            const decimal TAX = 0.23m;
            return HasTaxQuantity(taxQuantity) ? Quantity * Price * TAX : 0m;
        }
        
        private bool HasTaxQuantity(int taxQuantity)
        {
            return Quantity > taxQuantity;
        }
    }

    class OrdersService
    {
        /*
        public decimal CalculateTax(Order order, int taxQuantity)
        {
            if (order == null)
            {
                throw new ArgumentException("order instance is null");
            }

            if (taxQuantity <= 0)
            {
                throw new ArgumentException("tax quantity is not correct");
            }
            
            const decimal TAX = 0.23m;
            if (order.Quantity > taxQuantity)
            {
                return order.Quantity * order.Price * TAX;
            }

            return 0m;
        }
        */
        
        public decimal CalculateTax(Order order, int taxQuantity)
        {
            if (order == null)
            {
                throw new ArgumentException("order instance is null");
            }

            if (taxQuantity <= 0)
            {
                throw new ArgumentException("tax quantity is not correct");
            }

            return order.CalculateTax(taxQuantity);
        }
    }
    
    // -----------------------------------------------------------------------------
    // SOC
    // Separation Of Concerns
    // -----------------------------------------------------------------------------

    class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
    }
    
    /*
    class SongService
    {
        public List<Song> FindAll()
        {
            return new List<Song>();
        }

        public int Add(Song song)
        {
            return int.MinValue;
        }

        public bool Validate(Song song)
        {
            return true;
        }

        public void LogSongActions(Song song)
        {
            Console.WriteLine("LOG ...");
        }
    }
    */

    class SongService
    {
        public List<Song> FindAll()
        {
            return new List<Song>();
        }

        public int Add(Song song)
        {
            return int.MinValue;
        }
    }

    class SongValidationService
    {
        public bool Validate(Song song)
        {
            return true;
        }
    }

    class SongLogService
    {
        public void LogSongActions(Song song)
        {
            Console.WriteLine("LOG ...");
        }
    }
    
    // -----------------------------------------------------------------------------
    // YAGNI
    // You Ain't Gonna Need It
    // -----------------------------------------------------------------------------
    
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}