namespace SieuThiDienThoai.Models
{
    using System;
    using System.Collections.Generic;
    public class OrderFormPayment
    {
        public int Id { get; set; }
        public string Method { get; set; }
        public string BankInfo { get; set; }
        public int OrderFormId { get; set; }
    }
}
