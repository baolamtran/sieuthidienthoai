namespace SieuThiDienThoai.Models
{
    using System;
    using System.Collections.Generic;
    public class BillDeliveryInfoItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int BillDeliveryInfoId { get; set; }
    }
}
