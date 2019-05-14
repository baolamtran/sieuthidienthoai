namespace SieuThiDienThoai.Models
{
    using System;
    using System.Collections.Generic;
    public class BillDelivery
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public float Distance { get; set; }
        public int TotalPrice { get; set; }
        public bool IsInsideHcm { get; set; }
        public int BillId { get; set; }
    }
}
