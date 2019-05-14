namespace SieuThiDienThoai.Models
{
    using System;
    using System.Collections.Generic;
    public class OrderFormItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrderFormId { get; set; }
        public int ProductId { get; set; }
    }
}
