using Bootcamp.CRUD.Context;
using Bootcamp.CRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD.Manage
{
    public class ManageItem
    {
        public int? idSupplier;
        public void Item()
        {
            string lagi = "";
            do
            {
                char pilihan;
                var result = 0;
                Item item = new Item();
                MyContext _context = new MyContext();
                Console.WriteLine("================= Item Data ================");
                Console.WriteLine("1. Insert");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Retrieve");
                Console.WriteLine("============================================");
                Console.Write("Pilihan mu : ");
                pilihan = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("============================================");
                switch (pilihan)
                {
                    case '1':
                        //untuk input nilai name,joindate dan createdate ke database
                        Console.Write("Insert Name of Item : ");
                        item.Name = Console.ReadLine();
                        Console.Write("Insert Price of Item : ");
                        item.Price = Convert.ToInt32 (Console.ReadLine());
                        Console.Write("Insert Quantity of Item : ");
                        item.Quantity = Convert.ToInt16(Console.ReadLine());
                        item.DateIn = DateTimeOffset.Now.LocalDateTime;
                        item.CreateDate = DateTimeOffset.Now.LocalDateTime;
                        Console.Write("Insert Supplier Id : ");
                        idSupplier = Convert.ToInt16(Console.ReadLine());
                        if(idSupplier == null)
                        {
                            Console.Write("Please insert Supplier Id : ");
                            Console.Read();
                        }
                        else
                        {
                            var getSupplier = _context.Suppliers.Find(idSupplier);
                            if(getSupplier == null)
                            {
                                Console.Write("We don't have Id " + idSupplier);
                                Console.Read();
                            }else
                            {
                                item.Suppliers = getSupplier;

                                _context.Items.Add(item);
                                result = _context.SaveChanges();
                                if (result > 0)
                                {
                                    Console.WriteLine("Insert Successfully");
                                }
                                else
                                {
                                    Console.WriteLine("Insert Failed");
                                }
                                Console.Write("Kembali Manage Item? (y/n) : ");
                                lagi = Console.ReadLine();
                            }
                        }

                        //_context.Items.Add(item);
                        //result = _context.SaveChanges();
                        //if (result > 0)
                        //{
                        //    Console.WriteLine("Insert Successfully");
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Insert Failed");
                        //}
                        //Console.Write("Kembali Manage Item? (y/n) : ");
                        //lagi = Console.ReadLine();
                        break;
                    case '2':
                        Console.Write("Insert Id to Update Data : ");
                        int id = Convert.ToInt16(Console.ReadLine());
                        var get = _context.Items.Find(id);
                        if (get == null)
                        {
                            Console.WriteLine("Sorry,your data is not found");
                        }
                        else
                        {
                            Console.Write("Insert Name of Item : ");
                            get.Name = Console.ReadLine();
                            Console.Write("Insert Quantity of Item : ");
                            Console.Write("Insert Price of Item : ");
                            item.Price = Convert.ToInt16(Console.ReadLine());
                            get.Quantity = Convert.ToInt16(Console.ReadLine());
                            Console.Write("Insert Id Supplier of Item : ");
                            idSupplier = Convert.ToInt16(Console.ReadLine());
                            if (idSupplier == null)
                            {
                                Console.Write("Please insert Supplier Id : ");
                                Console.Read();
                            }
                            else
                            {
                                var getSupplier = _context.Suppliers.Find(idSupplier);
                                if (getSupplier == null)
                                {
                                    Console.Write("We don't have Id " + idSupplier);
                                    Console.Read();
                                }
                                else
                                {
                                    get.Suppliers = getSupplier;

                                    _context.Items.Add(item);
                                    result = _context.SaveChanges();
                                    if (result > 0)
                                    {
                                        Console.WriteLine("Insert Successfully");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Insert Failed");
                                    }
                                    Console.Write("Kembali Manage Item? (y/n) : ");
                                    lagi = Console.ReadLine();
                                }
                            }
                            // item.Suppliers = getsupplier;
                            //_context.Items.Add(item);
                            //result = _context.SaveChanges();
                            //    if (result > 0)
                            //{
                            //    Console.WriteLine("Update Successfully");
                            //}


                            //    Console.Write("Insert Name Supplier of Item : ");
                            //    get.Suppliers = Convert.ToInt16(Console.ReadLine());
                            //    get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
                            //    result = _context.SaveChanges();
                            //    if (result > 0)
                            //    {
                            //        Console.WriteLine("Update Successfully");
                            //    }
                            //    else
                            //    {
                            //        Console.WriteLine("Update Failed");
                            //    }
                            //}
                            //Console.Write("Kembali Manage Item? (y/n) : ");
                        }
                            break;
                    case '3':
                        Console.Write("Insert Id to Delete Data : ");
                        var getData = _context.Items.Find(Convert.ToInt16(Console.ReadLine()));
                        if (getData == null)
                        {
                            Console.WriteLine("Sorry,your data is not found");
                        }
                        else
                        {
                            getData.IsDelete = true;
                            getData.DeleteDate = DateTimeOffset.Now.LocalDateTime;
                            result = _context.SaveChanges();
                            if (result > 0)
                            {
                                Console.WriteLine("Delete Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Delete Failed");
                            }
                        }
                        Console.Write("Kembali Manage Item? (y/n) : ");
                        lagi = Console.ReadLine().ToString();
                        break;
                    case '4':
                        var getDatatoDisplay = _context.Items.Where(x => x.IsDelete == false).ToList();
                        if (getDatatoDisplay.Count == 0)
                        {
                            Console.WriteLine("No data in your Database");
                        }
                        else
                        {
                            foreach (var tampilin in getDatatoDisplay)
                            {
                                Console.WriteLine("============================================");
                                Console.WriteLine("Name      : " + tampilin.Name);
                                Console.WriteLine("Quantity  : " + tampilin.Quantity);
                                Console.WriteLine("Date In   : " + tampilin.DateIn);
                                Console.WriteLine("Supplier  : " + tampilin.Suppliers.name);
                                Console.WriteLine("============================================");
                            }
                            Console.WriteLine("Total Item : " + getDatatoDisplay.Count);
                        }
                        Console.Write("Kembali Manage Item? (y/n) : ");
                        lagi = Console.ReadLine().ToString();
                        break;
                    default:
                        Console.WriteLine("Not Found!");
                        Console.Write("Kembali Manage Item? (y/n) : ");
                        lagi = Console.ReadLine();
                        break;
                }
            } while (lagi == "y");
        }
    }
}
