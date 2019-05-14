namespace SieuThiDienThoai.Models
{
    using System;
    using System.Collections.Generic;
    public class GuaranteeFormCustomer
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
}
