using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID
    //Open Closed Principle: Koda yeni özellik eklerken, mevcuttaki kodlara dokunmamak,, sadece dataAccess ı değiştirdik ve program çalışıyor
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            
            foreach (var product in productManager.GetbyUnitPrice(40,100))
            {
                Console.WriteLine(product.ProductName);
            }

        }
    }
}
