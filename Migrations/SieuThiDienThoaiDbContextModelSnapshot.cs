﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SieuThiDienThoai.Data;

namespace SieuThiDienThoai.Migrations
{
    [DbContext(typeof(SieuThiDienThoaiDbContext))]
    partial class SieuThiDienThoaiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SieuThiDienThoai.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountPromotion");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("EmployeeId");

                    b.Property<float>("PercentDiscount");

                    b.Property<int>("PromotionId");

                    b.Property<string>("Status");

                    b.Property<int>("TotalPrice");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.BillDelivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("BillId");

                    b.Property<float>("Distance");

                    b.Property<bool>("IsInsideHcm");

                    b.Property<int>("TotalPrice");

                    b.HasKey("Id");

                    b.ToTable("BillDeliveries");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.BillDeliveryInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BillDeliveryId");

                    b.HasKey("Id");

                    b.ToTable("BillDeliveryInfoes");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.BillDeliveryInfoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BillDeliveryInfoId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.ToTable("BillDeliveryInfoItems");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.BillItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int>("BillId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.ToTable("BillItems");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.BillPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int>("BillId");

                    b.HasKey("Id");

                    b.ToTable("BillPayments");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("CompanyDirector");

                    b.Property<string>("CompanyPhone");

                    b.Property<bool>("IsVip");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("Type");

                    b.Property<int>("score");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.GuaranteeForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.HasKey("Id");

                    b.ToTable("GuaranteeForms");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.GuaranteeFormCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<string>("Description");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("ProductId");

                    b.Property<string>("Status");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("GuaranteeFormCustomers");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.GuaranteeFormItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GuaranteeFormCustomerId");

                    b.Property<int>("GuaranteeFormId");

                    b.HasKey("Id");

                    b.ToTable("GuaranteeFormItems");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.OrderForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<string>("Note");

                    b.Property<string>("Status");

                    b.Property<int>("SupplierId");

                    b.HasKey("Id");

                    b.ToTable("OrderForms");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.OrderFormItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderFormId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.ToTable("OrderFormItems");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.OrderFormPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankInfo");

                    b.Property<string>("Method");

                    b.Property<int>("OrderFormId");

                    b.HasKey("Id");

                    b.ToTable("OrderFormPayments");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code");

                    b.Property<string>("Description");

                    b.Property<float>("Height");

                    b.Property<float>("Length");

                    b.Property<string>("MadeIn");

                    b.Property<int>("ManufacturerId");

                    b.Property<string>("Name");

                    b.Property<string>("Os");

                    b.Property<int>("Price");

                    b.Property<int>("ProductCategoryId");

                    b.Property<string>("TimeGuarantee");

                    b.Property<string>("Type");

                    b.Property<float>("Width");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndTime");

                    b.Property<int>("MinTotalPrice");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("Type");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.ReceiveForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("OrderId");

                    b.HasKey("Id");

                    b.ToTable("ReceiveForms");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.ReceiveFormItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<int>("ReceiveFormId");

                    b.HasKey("Id");

                    b.ToTable("ReceiveFormItems");
                });

            modelBuilder.Entity("SieuThiDienThoai.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Fax");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });
#pragma warning restore 612, 618
        }
    }
}
