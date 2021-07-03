using CentuDY.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Controller
{
    public class TransactionController
    {
        public static Object GetTransactionHistory(int userId)
        {
            return TransactionHandler.GetTransactionHistory(userId);
        }

        public static void InsertTransaction(int userId, DateTime transDate, int medicineId, int quantity)
        {
            TransactionHandler.InsertTransaction(userId, transDate, medicineId, quantity);
        }
    }
}