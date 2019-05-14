namespace SieuThiDienThoai.Models
{
    using System;
    using System.Collections.Generic;
    public class GuaranteeFormItem
    {
        public int Id { get; set; }
        public int GuaranteeFormId { get; set; }
        public int GuaranteeFormCustomerId { get; set; }
    }
}
