using CentuDY.Factory;
using CentuDY.Model;
using CentuDY.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Handler
{
    public class TransactionHandler
    {
        public static Object GetTransactionHistory(int userId)
        {
            return TransactionRepository.GetTransactionHistory(userId);
        }

        public static void InsertTransaction(int userId, DateTime transDate, int medicineId, int quantity)
        {
            HeaderTransaction ht = TransactionFactory.CreateHeaderTrans(userId, transDate);
            DetailTransaction dt = TransactionFactory.CreateDetailTrans(medicineId, quantity);

            TransactionRepository.InsertTransaction(ht, dt);
        }
    }
}