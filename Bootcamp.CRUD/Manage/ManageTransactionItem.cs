using Bootcamp.CRUD.Context;
using Bootcamp.CRUD.Model;
using Bootcamp.CRUD.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD.Manage
{
    public class ManageTransactionItem : BaseModel
    {
        public int? idSupplier;
        public int? count;
        public void ManageTransactoinItem()
        {
            Item item = new Item();
            Transaction transaction = new Transaction();
            MyContext _context = new MyContext();
            TransactionItem transactionItem = new TransactionItem();

            transaction.TransactionDate = DateTimeOffset.Now.LocalDateTime;
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            var getTransaction = _context.Transactions.Max(x => x.Id);
            var getTransactionDetail = _context.Transactions.Find(getTransaction);

            Console.WriteLine("Transaction Id : " + getTransaction);
            Console.WriteLine("Transaction Date : " + getTransactionDetail.TransactionDate);

            Console.Write("How Many Item : ");
            count = Convert.ToInt16(Console.ReadLine());
            if (count == null)
            {
                Console.WriteLine("Please insert count of item that you want ");
                Console.Read();
            }
            else
            {
                for (int i = 1; i <= count; i++)
                {
                    Console.Write("Insert id Item : ");
                     int? id = Convert.ToInt16(Console.ReadLine());
                    if (id == null)
                    {
                        Console.WriteLine("Please Insert id that you want to buy");
                        Console.Read();
                    }
                    else
                    {
                        var getItem = _context.Items.Find(id);
                        if (getItem == null)
                        {
                            Console.WriteLine("We don't have item with id : " + id);
                            Console.Read();
                        }
                        else
                        {
                            Console.Write("Insert amount of item : ");
                            int? quantity = Convert.ToInt32(Console.ReadLine());
                            if (getItem.Quantity < quantity)
                            {
                                Console.Write("Stock is not enough, we have " + getItem.Quantity);
                                Console.Read();
                            }
                            else
                            {
                                transactionItem.Transactions = getTransactionDetail;
                                transactionItem.Items = getItem;
                                transactionItem.Quantity = quantity;
                                _context.TransactionItems.Add(transactionItem);
                                _context.SaveChanges();
                            }

                        }
                    }
                }
                var getPrice = _context.TransactionItems.Where(x => x.Transactions.Id == getTransactionDetail.Id).ToList();
                int? total = 0;
                foreach (var proceed in getPrice)
                {
                    total += (proceed.Quantity * proceed.Items.Price);
                }
                Console.WriteLine("Total Price : " + total);
                Console.Write("Balance : ");
                int? balance = Convert.ToInt32(Console.ReadLine());
                Console.Write("Exchange :" + (balance - total));
            }
        }
    }
}






            