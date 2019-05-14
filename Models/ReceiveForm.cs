namespace SieuThiDienThoai.Models
{
    using System;
    using System.Collections.Generic;
    public class ReceiveForm
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public int OrderId { get; set; }
    }
}
