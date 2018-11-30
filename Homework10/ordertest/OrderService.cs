using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Collections;
using System.Data.Entity;

namespace ordertest {
    /// <summary>
    /// OrderService:provide ordering service,
    /// like add order, remove order, query order and so on
    /// 实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
    /// </summary>
    public class OrderService {

        //static string patternPhoneNum = @"^1[0-9]{10}$";
        //static string patternIdNumber = @"^(?<year>[0-9]{4})(?<month>[0-9]{2})(?<date>[0-9]{2})(?<stream>[0-9]{3})$";

        //private Dictionary<string, Order> orderDict;
        //public OrderService() {
        //    orderDict = new Dictionary<string, Order>();
        //}

        //数据验证
        //static private bool Verify(string idNum, string phoneNum)
        //{
        //    if (!(Regex.IsMatch(idNum, patternIdNumber)))
        //    {
        //        return false;
        //    }
        //    if (!(Regex.IsMatch(phoneNum, patternPhoneNum)))
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        public void AddOrder(Order order) {
            using (var db = new OrderDB())
            {
                db.Order.Add(order);
                db.SaveChanges();
            }
        }

 
        public void RemoveOrder(string orderId) {
            using (var db = new OrderDB())
            {
                var order = db.Order.Include("details").SingleOrDefault(o => o.Id == orderId);
                db.OrderItem.RemoveRange(order.details);
                db.Order.Remove(order);
                db.SaveChanges();
            }
        }

        public void Update(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Order.Attach(order);
                db.Entry(order).State = EntityState.Modified;
                order.details.ForEach(
                    item => db.Entry(item).State = EntityState.Modified);
                db.SaveChanges();
            }
        }

        public List<Order> QueryAllOrders() {
            using (var db = new OrderDB())
            {
                return db.Order.Include("details").ToList<Order>();
            }
        }



        public Order GetById(string orderId) {
            using (var db = new OrderDB())
            {
                return db.Order.Include("details").
                  SingleOrDefault(o => o.Id == orderId);
            }
        }


        public List<Order> QueryByGoodsName(string goodsName) {
            using (var db = new OrderDB())
            {
                var query = db.Order.Include("details")
                  .Where(o => o.details.Where(
                    item => item.GoodsName.Equals(goodsName)).Count() > 0);
                return query.ToList<Order>();
            }

        }


        public List<Order> QueryByCustomerName(string customerName) {
            using (var db = new OrderDB())
            {
                return db.Order.Include("details")
                  .Where(o => o.Customer.Equals(customerName)).ToList<Order>();
            }
        }

        //public List<Order> QueryByPrice(double price)
        //{
        //    var query = orderDict.Values
        //        .Where(order => order.Amount> price);
        //    return query.ToList();
        //}


        //public void UpdateCustomer(string orderId, Customer newCustomer) {
        //    if (orderDict.ContainsKey(orderId)) {
        //        orderDict[orderId].Customer = newCustomer;
        //    } else {
        //        throw new Exception($"order-{orderId} is not existed!");
        //    }
        //}



        //public string Export()
        //{
        //    DateTime time = System.DateTime.Now;
        //    string fileName = "orders_" + time.Year + "_" + time.Month
        //        + "_" + time.Day + "_" + time.Hour + "_" + time.Minute
        //        + "_" + time.Second + ".xml";
        //    Export(fileName);
        //    return fileName;
        //}

        //public void Export(String fileName)
        //{
        //    XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
        //    using (FileStream fs = new FileStream(fileName, FileMode.Create))
        //    {
        //        xs.Serialize(fs, orderDict.Values.ToList());
        //    }
        //}


        //public List<Order> Import(string path)
        //{
        //    if (Path.GetExtension(path) != ".xml")
        //        throw new ArgumentException("It isn't a xml file!");
        //    XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
        //    List<Order> result = new List<Order>();

        //    using (FileStream fs = new FileStream(path, FileMode.Open))
        //    {
        //        List<Order> temp = (List<Order>)xs.Deserialize(fs);
        //        temp.ForEach(order =>
        //        {
        //            if (!orderDict.Keys.Contains(order.Id))
        //            {
        //                orderDict[order.Id] = order;
        //                result.Add(order);
        //            }
        //        });
        //    }
        //    return result;
        //}

        //static public void ConvertToHtml(string xmlFile)
        //{
        //    XmlDocument xml = new XmlDocument();
        //    xml.Load(xmlFile);
        //    XPathNavigator xpath = xml.CreateNavigator();
        //    xpath.MoveToRoot();
        //    XslCompiledTransform xsl = new XslCompiledTransform();
        //    xsl.Load(@"D:\CSharpHomework\Homework8\Program1\order.xlst");
        //    string filePath = xmlFile.Substring(0, xmlFile.LastIndexOf("\\"));
        //    FileStream fileStream = File.OpenWrite(filePath + "\\order.html");
        //    XmlTextWriter writer = new XmlTextWriter(fileStream, System.Text.Encoding.UTF8);
        //    xsl.Transform(xpath, null, writer);
        //    fileStream.Close();
        //    System.Diagnostics.Process.Start(filePath + "order.html");
        //}

        /*other edit function with write in the future.*/
    }
}
