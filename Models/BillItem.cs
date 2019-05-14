namespace SieuThiDienThoai.Models
{
    using System;
    using System.Collections.Generic;
    public class BillItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
        public int BillId { get; set; }
        public int ProductId { get; set; }
    }
}
