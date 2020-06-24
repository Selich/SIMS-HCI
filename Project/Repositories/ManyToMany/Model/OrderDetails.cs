using Project.Repositories.Abstract;
using System;
using System.Collections.Generic;

namespace Project.Model
{
    public class OrderDetails : IIdentifiable<long>
    {
        public long OrderId { get; set; }
        public long ItemId { get; set; }
        public long Quantity { get; set; }

        public OrderDetails() { }
        public OrderDetails(long orderId, long itemId, long quantity)
        {
            OrderId = orderId;
            ItemId = itemId;
            Quantity = quantity;
        }

        public long GetId() => OrderId;

        public void SetId(long id) => ItemId = id;
    }
}