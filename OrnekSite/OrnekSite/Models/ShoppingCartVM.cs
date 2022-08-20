using System.Collections.Generic;

namespace OrnekSite.Models
{
    public class ShoppingCartVM
    {
        //tüm kartları aldık
        public IEnumerable<ShoppingCart> ListCart { get; set; }

        //sipariş tablosunu getirir
        public OrderHeader OrderHeader { get; set; }
    }
}
