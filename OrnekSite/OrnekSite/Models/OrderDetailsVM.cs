using System.Collections.Generic;

namespace OrnekSite.Models
{
    //hem order hem de order details tablolarına ulaşmak için tanımlandı
    public class OrderDetailsVM
    {
        
        //Order tablosu
        public OrderHeader OrderHeader { get; set; }
        
        //OrderDetails tablosu
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
