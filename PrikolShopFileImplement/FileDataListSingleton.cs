using PrikolShopBusinessLogic.Enums;
using PrikolShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace PrikolShopFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string GiftFileName = "Gift.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string GiftBoxFileName = "GiftBox.xml";
        private readonly string BoxFileName = "Box.xml";
        public List<Gift> Gifts { get; set; }
        public List<Order> Orders { get; set; }
        public List<GiftBox> GiftBoxes { get; set; }
        public List<Box> Boxes { get; set; }
        private FileDataListSingleton()
        {
            Gifts = LoadGifts();
            Orders = LoadOrders();
            GiftBoxes = LoadGiftBoxes();
            Boxes = LoadBoxes();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveGifts();
            SaveOrders();
            SaveGiftBoxes();
            SaveBoxes();
        }
        private List<Gift> LoadGifts()
        {
            var list = new List<Gift>();
            if (File.Exists(GiftFileName))
            {
                XDocument xDocument = XDocument.Load(GiftFileName);
                var xElements = xDocument.Root.Elements("Gift").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Gift
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        GiftName = elem.Element("GiftName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        GiftBoxId = Convert.ToInt32(elem.Element("GiftBoxId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
                   elem.Element("Status").Value),
                        DateCreate =
                   Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement =
                   string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                   Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<GiftBox> LoadGiftBoxes()
        {
            var list = new List<GiftBox>();
            if (File.Exists(GiftBoxFileName))
            {
                XDocument xDocument = XDocument.Load(GiftBoxFileName);
            var xElements = xDocument.Root.Elements("GiftBox").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new GiftBox
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        GiftBoxName = elem.Element("GiftBoxName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }
        private List<Box> LoadBoxes()
        {
            var list = new List<Box>();
            if (File.Exists(BoxFileName))
            {
                XDocument xDocument = XDocument.Load(BoxFileName);
                var xElements = xDocument.Root.Elements("Box").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Box
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        GiftBoxId = Convert.ToInt32(elem.Element("GiftBoxId").Value),
                        GiftId = Convert.ToInt32(elem.Element("GiftId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }
        private void SaveGifts()
        {
            if (Gifts != null)
            {
                var xElement = new XElement("Gifts");
                foreach (var gift in Gifts)
                {
                    xElement.Add(new XElement("Gift",
                    new XAttribute("Id", gift.Id),
                    new XElement("GiftName", gift.GiftName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(GiftFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
            var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("ProductId", order.GiftBoxId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveGiftBoxes()
        {
            if (GiftBoxes != null)
            {
                var xElement = new XElement("GiftBoxes");
                foreach (var giftBox in GiftBoxes)
                {
                    xElement.Add(new XElement("GiftBox",
                    new XAttribute("Id", giftBox.Id),
                    new XElement("ProductName", giftBox.GiftBoxName),
                    new XElement("Price", giftBox.Price)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(GiftBoxFileName);
            }
        }
        private void SaveBoxes()
        {
            if (Boxes != null)
            {
                var xElement = new XElement("Boxes");
                foreach (var box in Boxes)
                {
                    xElement.Add(new XElement("Box",
                    new XAttribute("Id", box.Id),
                    new XElement("GiftBoxId", box.GiftBoxId),
                    new XElement("GiftId", box.GiftId),
                    new XElement("Count", box.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(BoxFileName);
            }
        }
    }
}
