using PrikolShopListImplement.Models;
using System;
using System.Collections.Generic;

namespace PrikolShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Gift> Gifts { get; set; }
        public List<Order> Orders { get; set; }
        public List<GiftBox> GiftBoxes { get; set; }
        public List<Box> Boxes { get; set; }
        private DataListSingleton()
        {
            Gifts = new List<Gift>();
            Orders = new List<Order>();
            GiftBoxes = new List<GiftBox>();
            Boxes = new List<Box>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
