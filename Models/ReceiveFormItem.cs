namespace SieuThiDienThoai.Models
{
    using System;
    using System.Collections.Generic;
    public class ReceiveFormItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ReceiveFormId { get; set; }
        public int ProductId { get; set; }
    }
}
