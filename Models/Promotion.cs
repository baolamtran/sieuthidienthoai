namespace SieuThiDienThoai.Models
{
    using System;
    using System.Collections.Generic;
    public class Promotion
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public int Value { get; set; }
        public int MinTotalPrice { get; set; }
    }
}
