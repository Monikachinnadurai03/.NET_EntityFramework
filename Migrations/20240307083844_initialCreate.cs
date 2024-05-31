using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS_DBFirst.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client_State",
                columns: table => new
                {
                    State_ID = table.Column<int>(type: "int", nullable: false),
                    State_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Client_S__AF9338D7CAE0F43D", x => x.State_ID);
                });

            migrationBuilder.CreateTable(
                name: "ClientCity",
                columns: table => new
                {
                    City_ID = table.Column<int>(type: "int", nullable: false),
                    City_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Client_C__DE9DE020CA906276", x => x.City_ID);
                });

            migrationBuilder.CreateTable(
                name: "Investment_Type",
                columns: table => new
                {
                    Investment_Type_ID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Investme__D52DA326AF8A2DE6", x => x.Investment_Type_ID);
                });

            migrationBuilder.CreateTable(
                name: "Transaction_Type",
                columns: table => new
                {
                    Transaction_Type_ID = table.Column<int>(type: "int", nullable: false),
                    Transaction_Type = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transact__6E05F51FD881D22D", x => x.Transaction_Type_ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Client_ID = table.Column<int>(type: "int", nullable: false),
                    First_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Last_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Phone_Number = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Birth_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Registration_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Occupation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Street_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    City_ID = table.Column<int>(type: "int", nullable: false),
                    State_ID = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PAN_Card_No = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Client__75A5D7181E544345", x => x.Client_ID);
                    table.ForeignKey(
                        name: "FK__Client__City_ID__656C112C",
                        column: x => x.City_ID,
                        principalTable: "ClientCity",
                        principalColumn: "City_ID");
                    table.ForeignKey(
                        name: "FK__Client__State_ID__66603565",
                        column: x => x.State_ID,
                        principalTable: "Client_State",
                        principalColumn: "State_ID");
                });

            migrationBuilder.CreateTable(
                name: "Investment",
                columns: table => new
                {
                    Investment_ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Purchase_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Purchase_Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Investment_Type_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Investme__0C059B9CAEB9C5C3", x => x.Investment_ID);
                    table.ForeignKey(
                        name: "FK__Investmen__Inves__70DDC3D8",
                        column: x => x.Investment_Type_ID,
                        principalTable: "Investment_Type",
                        principalColumn: "Investment_Type_ID");
                });

            migrationBuilder.CreateTable(
                name: "Transaction_Detail",
                columns: table => new
                {
                    Transaction_ID = table.Column<int>(type: "int", nullable: false),
                    Transaction_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Transaction_Type_ID = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transact__9A8D562523252D79", x => x.Transaction_ID);
                    table.ForeignKey(
                        name: "FK__Transacti__Trans__1332DBDC",
                        column: x => x.Transaction_Type_ID,
                        principalTable: "Transaction_Type",
                        principalColumn: "Transaction_Type_ID");
                });

            migrationBuilder.CreateTable(
                name: "Client_Investment",
                columns: table => new
                {
                    Client_Investment_ID = table.Column<int>(type: "int", nullable: false),
                    Client_ID = table.Column<int>(type: "int", nullable: true),
                    Investment_ID = table.Column<int>(type: "int", nullable: true),
                    Investment_Amount = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Investment_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Transaction_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Client_I__125BA18A1DBA30AB", x => x.Client_Investment_ID);
                    table.ForeignKey(
                        name: "FK__Client_In__Clien__0D7A0286",
                        column: x => x.Client_ID,
                        principalTable: "Client",
                        principalColumn: "Client_ID");
                    table.ForeignKey(
                        name: "FK__Client_In__Inves__0E6E26BF",
                        column: x => x.Investment_ID,
                        principalTable: "Investment",
                        principalColumn: "Investment_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_City_ID",
                table: "Client",
                column: "City_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_State_ID",
                table: "Client",
                column: "State_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Investment_Client_ID",
                table: "Client_Investment",
                column: "Client_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Investment_Investment_ID",
                table: "Client_Investment",
                column: "Investment_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Investment_Investment_Type_ID",
                table: "Investment",
                column: "Investment_Type_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_Detail_Transaction_Type_ID",
                table: "Transaction_Detail",
                column: "Transaction_Type_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client_Investment");

            migrationBuilder.DropTable(
                name: "Transaction_Detail");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Investment");

            migrationBuilder.DropTable(
                name: "Transaction_Type");

            migrationBuilder.DropTable(
                name: "ClientCity");

            migrationBuilder.DropTable(
                name: "Client_State");

            migrationBuilder.DropTable(
                name: "Investment_Type");
        }
    }
}
