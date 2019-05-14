namespace SieuThiDienThoai.Models
{
    using System;
    using System.Collections.Generic;
    public class Product
    {
        public int Id { get; set; }
        public int Code { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }
        public string MadeIn { get; set; }
        public string TimeGuarantee { get; set; }
        public string Type { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Length { get; set; }
        public string Os { get; set; }
        public string Description { get; set; }
        public int ProductCategoryId { get; set; }
        public int ManufacturerId { get; set; }
    }
}
