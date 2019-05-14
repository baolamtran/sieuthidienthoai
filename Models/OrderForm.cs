namespace SieuThiDienThoai.Models
{
    using System;
    using System.Collections.Generic;
    public class OrderForm
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public int EmployeeId { get; set; }
        public int SupplierId { get; set; }
    }
}
