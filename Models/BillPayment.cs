namespace SieuThiDienThoai.Models
{
    using System;
    using System.Collections.Generic;
    public class BillPayment
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int BillId { get; set; }
    }
}
