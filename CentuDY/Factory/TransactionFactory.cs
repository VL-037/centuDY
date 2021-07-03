using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Factory
{
    public class TransactionFactory
    {
        public static HeaderTransaction CreateHeaderTrans(int userId, DateTime transDate)
        {
            HeaderTransaction ht = new HeaderTransaction
            {
                UserId = userId,
                TransactionDate = transDate
            };

            return ht;
        }

        public static DetailTransaction CreateDetailTrans(int medicineId, int quantity)
        {
            DetailTransaction dt = new DetailTransaction
            {
                MedicineId = medicineId,
                Quantity = quantity
            };

            return dt;
        }
    }
}