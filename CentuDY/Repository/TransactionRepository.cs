using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Repository
{
    public class TransactionRepository
    {
        private static CentuDY_dbEntities db = new CentuDY_dbEntities();

        public static List<HeaderTransaction> GetAllHeaderTransactionData()
        {
            return db.HeaderTransactions.ToList();
        }

        public static void InsertTransaction(HeaderTransaction ht, DetailTransaction dt)
        {
            db.HeaderTransactions.Add(ht);
            db.DetailTransactions.Add(dt);
            db.SaveChanges();
        }

        public static Object GetTransactionHistory(int userId)
        {
            var history = (from header in db.HeaderTransactions
                           join detail in db.DetailTransactions on header.TransactionId equals detail.TransactionId
                           join medicine in db.Medicines on detail.MedicineId equals medicine.MedicineId
                           where header.UserId == userId
                           select new
                           {
                               medicine.Name,
                               detail.Quantity,
                               header.TransactionDate,
                               subTotal = medicine.Price * detail.Quantity
                           }).ToList();

            return history;
        }
    }
}