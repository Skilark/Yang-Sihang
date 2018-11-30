using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {


    public class OrderDetail {
        public OrderDetail()
        {

        }

        public OrderDetail(uint id, Goods goods, uint quantity) {
            this.Id = id;
            this.Goods = goods;
            this.Quantity = quantity;
        }

        public uint Id { get; set; }
        public Goods Goods { get; set; }
        public uint Quantity { get; set; }

        public override bool Equals(object obj)
        {
            var detail = obj as OrderDetail;
            return detail != null &&
                Goods.Equals(detail.Goods)&&
                Quantity == detail.Quantity;
        }

        public override int GetHashCode()
        {

            var hashCode = 1522631281;
            String gname=Goods==null?"":(Goods.Name==null?"": Goods.Name);
            hashCode = hashCode * -1521134295 + gname.GetHashCode();
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }


        public override string ToString() {
            string result = "";
            result += $"orderDetailId:{Id}:  ";
            result += Goods + $", quantity:{Quantity}"; 
            return result;
        }


    }
}
