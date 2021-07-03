using CentuDY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Repository
{
    public class CartRepository
    {
        private static CentuDY_dbEntities db = new CentuDY_dbEntities();

        public static bool AddtoCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();

            return true;
        }

        public static Cart GetExistingItem(int userId, int medicineId)
        {
            return (from x in db.Carts
                    where x.UserId == userId && x.MedicineId == medicineId
                    select x).FirstOrDefault();
        }

        public static Object GetAllCartItemsByUserId(int userId)
        {
            var allItems = (from user in db.Users
                            join cart in db.Carts on user.UserId equals cart.UserId
                            join medicine in db.Medicines on cart.MedicineId equals medicine.MedicineId
                            where user.UserId == userId
                            select new
                            {
                                medicineId = cart.MedicineId,
                                medicineName = medicine.Name,
                                price = medicine.Price,
                                quantity = cart.Quantity,
                                subTotal = medicine.Price * cart.Quantity
                            }).ToList();

            return allItems;
        }

        public static List<Cart> GetItemsByUserId(int userId)
        {
            return (from x in db.Carts
                    where x.UserId == userId
                    select x).ToList();
        }

        public static void UpdateCartItem(int userId, int medicineId, int quantity)
        {
            Cart cart = (from x in db.Carts
                         where x.UserId == userId && x.MedicineId == medicineId
                         select x).FirstOrDefault();

            if(cart != null)
            {
                cart.Quantity += quantity;

                db.SaveChanges();
            }
        }

        public static void RemoveCartItem(int userId, int medicineId)
        {
            Cart cart = (from x in db.Carts
                         where x.UserId == userId && x.MedicineId == medicineId
                         select x).FirstOrDefault();

            db.Carts.Remove(cart);
            db.SaveChanges();
        }

        public static void CheckoutAllItems(int userId)
        {
            List<Cart> cartItems = (from x in db.Carts
                                    where x.UserId == userId
                                    select x).ToList();

            if(cartItems != null)
            {
                foreach (Cart item in cartItems)
                {
                    db.Carts.Remove(item);
                    db.SaveChanges();
                }
            }
        }
    }
}