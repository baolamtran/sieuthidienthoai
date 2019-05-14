using Microsoft.EntityFrameworkCore;
using SieuThiDienThoai.Models;
namespace SieuThiDienThoai.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class SieuThiDienThoaiDbContext : DbContext
    {
        public SieuThiDienThoaiDbContext(DbContextOptions<SieuThiDienThoaiDbContext> options) : base(options)
        {
        }
        public DbSet<SieuThiDienThoai.Models.Bill> Bills { get; set; }

        public DbSet<SieuThiDienThoai.Models.BillDelivery> BillDeliveries { get; set; }

        public DbSet<SieuThiDienThoai.Models.BillDeliveryInfo> BillDeliveryInfoes { get; set; }

        public DbSet<SieuThiDienThoai.Models.BillDeliveryInfoItem> BillDeliveryInfoItems { get; set; }

        public DbSet<SieuThiDienThoai.Models.BillItem> BillItems { get; set; }

        public DbSet<SieuThiDienThoai.Models.BillPayment> BillPayments { get; set; }

        public DbSet<SieuThiDienThoai.Models.Customer> Customers { get; set; }

        public DbSet<SieuThiDienThoai.Models.Employee> Employees { get; set; }

        public DbSet<SieuThiDienThoai.Models.GuaranteeForm> GuaranteeForms { get; set; }

        public DbSet<SieuThiDienThoai.Models.GuaranteeFormItem> GuaranteeFormItems { get; set; }

        public DbSet<SieuThiDienThoai.Models.GuaranteeFormCustomer> GuaranteeFormCustomers { get; set; }

        public DbSet<SieuThiDienThoai.Models.Manufacturer> Manufacturers { get; set; }

        public DbSet<SieuThiDienThoai.Models.OrderForm> OrderForms { get; set; }
        public DbSet<SieuThiDienThoai.Models.OrderFormItem> OrderFormItems { get; set; }
        public DbSet<SieuThiDienThoai.Models.OrderFormPayment> OrderFormPayments { get; set; }
        public DbSet<SieuThiDienThoai.Models.Product> Products { get; set; }
        public DbSet<SieuThiDienThoai.Models.ProductCategory> ProductCategories { get; set; }
        public DbSet<SieuThiDienThoai.Models.Promotion> Promotions { get; set; }
        public DbSet<SieuThiDienThoai.Models.ReceiveForm> ReceiveForms { get; set; }
        public DbSet<SieuThiDienThoai.Models.ReceiveFormItem> ReceiveFormItems { get; set; }
        public DbSet<SieuThiDienThoai.Models.Supplier> Suppliers { get; set; }
    }
}