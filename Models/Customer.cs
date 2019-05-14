namespace SieuThiDienThoai.Models
{
    using System;
    using System.Collections.Generic;
    public class Customer
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool IsVip { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string CompanyDirector { get; set; }
        public string CompanyPhone { get; set; }
        public int score { get; set; }
    }
}
