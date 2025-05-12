using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACar.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class init0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "customer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DrivingLicanceDateOfIssue = table.Column<DateOnly>(type: "date", nullable: false),
                    DrivingLicanceClass = table.Column<int>(type: "integer", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    IdentityNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rent_office",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductsId = table.Column<Guid[]>(type: "uuid[]", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rent_office", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "appUser",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RentOfficeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    IdentityNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appUser_rent_office_RentOfficeId",
                        column: x => x.RentOfficeId,
                        principalSchema: "dbo",
                        principalTable: "rent_office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RentOfficeId = table.Column<Guid>(type: "uuid", nullable: false),
                    RentId = table.Column<Guid[]>(type: "uuid[]", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_rent_office_RentOfficeId",
                        column: x => x.RentOfficeId,
                        principalSchema: "dbo",
                        principalTable: "rent_office",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "rent",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RentOfficeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductIds = table.Column<Guid[]>(type: "uuid[]", nullable: false),
                    PaymentIds = table.Column<Guid[]>(type: "uuid[]", nullable: true),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    RentType = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rent_appUser_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "dbo",
                        principalTable: "appUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_rent_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "dbo",
                        principalTable: "customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_rent_rent_office_RentOfficeId",
                        column: x => x.RentOfficeId,
                        principalSchema: "dbo",
                        principalTable: "rent_office",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "payment",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payment_rent_RentId",
                        column: x => x.RentId,
                        principalSchema: "dbo",
                        principalTable: "rent",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "product_rent",
                schema: "dbo",
                columns: table => new
                {
                    ProductsId = table.Column<Guid>(type: "uuid", nullable: false),
                    RentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_rent", x => new { x.ProductsId, x.RentsId });
                    table.ForeignKey(
                        name: "FK_product_rent_product_ProductsId",
                        column: x => x.ProductsId,
                        principalSchema: "dbo",
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_rent_rent_RentsId",
                        column: x => x.RentsId,
                        principalSchema: "dbo",
                        principalTable: "rent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appUser_RentOfficeId",
                schema: "dbo",
                table: "appUser",
                column: "RentOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_payment_RentId",
                schema: "dbo",
                table: "payment",
                column: "RentId");

            migrationBuilder.CreateIndex(
                name: "IX_product_RentOfficeId",
                schema: "dbo",
                table: "product",
                column: "RentOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_product_rent_RentsId",
                schema: "dbo",
                table: "product_rent",
                column: "RentsId");

            migrationBuilder.CreateIndex(
                name: "IX_rent_AppUserId",
                schema: "dbo",
                table: "rent",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_rent_CustomerId",
                schema: "dbo",
                table: "rent",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_rent_RentOfficeId",
                schema: "dbo",
                table: "rent",
                column: "RentOfficeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "product_rent",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "product",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "rent",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "appUser",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "customer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "rent_office",
                schema: "dbo");
        }
    }
}
