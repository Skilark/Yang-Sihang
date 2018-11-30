using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ordertest {


    public class OrderDetail {
        [Key]

        public string Id { get; set; }
        public string GoodsName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public OrderDetail()
        {
            Id = Guid.NewGuid().ToString();
        }
 
        public OrderDetail(string id, string goodsname, int quantity,double price) {
            this.Id = id;
            this.GoodsName = goodsname;
            this.Quantity = quantity;
            this.Price = price;
        }

       
        //public override bool Equals(object obj)
        //{
        //    var detail = obj as OrderDetail;
        //    return detail != null &&
        //        Goods.Equals(detail.Goods)&&
        //        Quantity == detail.Quantity;
        //}

        //public override int GetHashCode()
        //{

        //    var hashCode = 1522631281;
        //    String gname=Goods==null?"":(Goods.Name==null?"": Goods.Name);
        //    hashCode = hashCode * -1521134295 + gname.GetHashCode();
        //    hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
        //    return hashCode;
        //}

        //public override string ToString() {
        //    string result = "";
        //    result += $"orderDetailId:{Id}:  ";
        //    result += Goods + $", quantity:{Quantity}"; 
        //    return result;
        //}


    }
}
