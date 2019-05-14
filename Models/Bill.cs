namespace SieuThiDienThoai.Models
{
    using System;
    using System.Collections.Generic;
    public class Bill
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public float PercentDiscount { get; set; }
        public int TotalPrice { get; set; }
        public string Type { get; set; }
        public int AmountPromotion { get; set; }
        public System.DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public int PromotionId { get; set; }
    }
}
