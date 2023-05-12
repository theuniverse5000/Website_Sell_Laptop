using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sell_Laptop_API.Migrations
{
    public partial class CreateToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "varchar(70)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CPU",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "varchar(70)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RAM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThongSo = table.Column<string>(type: "varchar(70)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SSD",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThongSo = table.Column<string>(type: "varchar(70)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "varchar(30)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    StarDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    GiaTri = table.Column<decimal>(type: "money", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IdProducer = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producer",
                        column: x => x.IdProducer,
                        principalTable: "Producer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "varchar(256)", nullable: false),
                    Password = table.Column<string>(type: "varchar(256)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IdRole = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.UniqueConstraint("AK_User_Username", x => x.Username);
                    table.ForeignKey(
                        name: "FK_User_Role_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "varchar(30)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProduct = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ImportPrice = table.Column<decimal>(type: "decimal", nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IdProduct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdColor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdRam = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCpu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSsd = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Color_IdColor",
                        column: x => x.IdColor,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetail_CPU_IdCpu",
                        column: x => x.IdCpu,
                        principalTable: "CPU",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetail_RAM_IdRam",
                        column: x => x.IdRam,
                        principalTable: "RAM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetail_SSD_IdSsd",
                        column: x => x.IdSsd,
                        principalTable: "SSD",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoDienThoaiKhachHang = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    HoTenKhachHang = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DiaChiKhachHang = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bill_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bill_Voucher_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Voucher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Cart_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProductDetails = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdBill = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bill",
                        column: x => x.IdBill,
                        principalTable: "Bill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetails",
                        column: x => x.IdProductDetails,
                        principalTable: "ProductDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProductDetails = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartDetail_Cart_UserId",
                        column: x => x.UserId,
                        principalTable: "Cart",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDetail_ProductDetail_IdProductDetails",
                        column: x => x.IdProductDetails,
                        principalTable: "ProductDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_UserId",
                table: "Bill",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_VoucherId",
                table: "Bill",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_IdBill",
                table: "BillDetail",
                column: "IdBill");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_IdProductDetails",
                table: "BillDetail",
                column: "IdProductDetails");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_IdProductDetails",
                table: "CartDetail",
                column: "IdProductDetails");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_UserId",
                table: "CartDetail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_IdProduct",
                table: "Image",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdProducer",
                table: "Product",
                column: "IdProducer");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_IdColor",
                table: "ProductDetail",
                column: "IdColor");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_IdCpu",
                table: "ProductDetail",
                column: "IdCpu");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_IdProduct",
                table: "ProductDetail",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_IdRam",
                table: "ProductDetail",
                column: "IdRam");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_IdSsd",
                table: "ProductDetail",
                column: "IdSsd");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdRole",
                table: "User",
                column: "IdRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillDetail");

            migrationBuilder.DropTable(
                name: "CartDetail");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "CPU");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "RAM");

            migrationBuilder.DropTable(
                name: "SSD");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Producer");
        }
    }
}
