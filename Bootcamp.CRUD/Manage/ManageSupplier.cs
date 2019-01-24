using Bootcamp.CRUD.Context;
using Bootcamp.CRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD
{
    public class ManageSupplier
    {
        public void Supplier()
        {
            char pilihan;
            var result = 0;

            Supplier supplier = new Supplier();
            MyContext _context = new MyContext();
            Console.WriteLine("==================Supplier Data===================");
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Retrieve");
            Console.WriteLine("==================================================");
            Console.Write("Pilihan mu : ");
            pilihan = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("==================================================");
            switch (pilihan)
            {
                case '1':
                    //buat masukin name, joindate di supplier
                    Console.WriteLine("Insert Name of Supplier :");
                    supplier.name = Console.ReadLine();
                    supplier.JoinDate = DateTimeOffset.Now.LocalDateTime;
                    supplier.CreateDate = DateTimeOffset.Now.LocalDateTime;
                    _context.Suppliers.Add(supplier);
                    result = _context.SaveChanges();
                    if (result > 0)
                    {
                        Console.Write("Insert Succesfully");
                        Console.Read();
                    }
                    break;
                case '2':
                    Console.Write("Insert Id to Update Data : ");
                    int id = Convert.ToInt16(Console.ReadLine());
                    var get = _context.Suppliers.Find(id);
                    if (get == null)
                    {
                        Console.Write("Sorry, your data is not found");
                        Console.Read();
                    }
                    else
                    {
                        Console.Write("Insert Name of Supplier : ");
                        get.name = Console.ReadLine();
                        get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
                        result = _context.SaveChanges();
                        if (result > 0)
                        {
                            Console.Write(" Update Succesfully");
                            Console.Read();
                        }
                    }
                    break;
                case '3':
                    Console.Write("Insert Id to Update Data : ");

                    var getData = _context.Suppliers.Find(Convert.ToInt16(Console.ReadLine()));
                    if (getData == null)
                    {
                        Console.Write("Sorry, your data is not found");
                        Console.Read();
                    }
                    else
                    {

                        getData.IsDelete = true;
                        getData.DeleteDate = DateTimeOffset.Now.LocalDateTime;
                        result = _context.SaveChanges();
                        if (result > 0)
                        {
                            Console.Write(" Delete Succesfully");
                            Console.Read();
                        }
                    }
                    break;
                case '4':
                    var getDatatoDisplay = _context.Suppliers.Where(x => x.IsDelete == false).ToList();

                    if (getDatatoDisplay.Count == 0)
                    {
                        Console.Write("No Data in Your Database");
                        Console.Read();
                    }
                    else
                    {
                        foreach (var Tampilin in getDatatoDisplay)
                        {
                            Console.WriteLine("==================================================");
                            Console.WriteLine("Name         : " + Tampilin.name);
                            Console.WriteLine("Join Date    : " + Tampilin.JoinDate);
                            Console.WriteLine("==================================================");
                        }
                        Console.WriteLine("Total Supplier   : " + getDatatoDisplay.Count);
                        Console.Read();
                    }
                    break;
                default:
                    break;


            }

        }
    }
}

