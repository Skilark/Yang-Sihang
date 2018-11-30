using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {


    [Serializable]
    public class Order {

        private List<OrderDetail> details=new List<OrderDetail>();

        public Order(){}

        public Order(string orderId, Customer customer) {
            Id = orderId;
            Customer = customer;
        }

        public string Id { get; set; }
        public Customer Customer { get; set; }
        public double Amount
        {
            get
            {
                return details.Sum(d => d.Goods.Price * d.Quantity);
            }
        } 
            
        
        public List<OrderDetail> Details {
            get =>this.details; }


        public void AddDetails(OrderDetail orderDetail) {
            if (this.Details.Contains(orderDetail))  {
                throw new Exception($"orderDetails-{orderDetail.Id} is already existed!");
            }
            details.Add(orderDetail);
        }


        public void RemoveDetails(uint orderDetailId) {
            details.RemoveAll(d =>d.Id==orderDetailId);
        }


        public override string ToString() {
            string result = "================================================================================\n";
            result += $"orderId:{Id}, customer:({Customer.Name}),Amount:{Amount}";
            details.ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }
    }
}
