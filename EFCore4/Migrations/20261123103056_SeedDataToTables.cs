using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore4.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CustomerType", "DateOfBirth", "Email", "FullName", "NationalId", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Nasr City, Cairo", "Individual", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar.khaled@gmail.com", "Omar Khaled", 295001234, "01112223344" },
                    { 2, "Smouha, Alexandria", "Individual", new DateTime(1998, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.ali@gmail.com", "Sara Ali", 298051678, "01223334455" },
                    { 3, "Maadi, Cairo", "Business", new DateTime(2015, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "info@techsolutions.com", "Tech Solutions Co.", 300112209, "01098887766" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Email", "FullName", "HireDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "ahmed.hassan@nationalbank.com", "Ahmed Hassan", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01001112233" },
                    { 2, "mona.mahmoud@nationalbank.com", "Mona Mahmoud", new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "01004445566" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Code", "Address", "ManagerId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "15 Tahrir Square, Cairo", 1, "Cairo Main Branch", "0225551111" },
                    { 2, "40 Corniche Rd, Alexandria", 2, "Alexandria Branch", "0348882222" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountNumber", "AccountType", "BranchId", "CurrentBalance", "OpeningDate" },
                values: new object[,]
                {
                    { 1001, "Savings", 1, 50000.00m, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1002, "Checking", 1, 120000.00m, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1003, "Savings", 2, 25000.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CustomerAccounts",
                columns: new[] { "AccountNumber", "CustomerId", "AccountStatus", "OwnerShipStartDate", "OwnerShipType" },
                values: new object[,]
                {
                    { 1001, 1, true, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary" },
                    { 1002, 1, true, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CoHolder" },
                    { 1003, 2, true, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary" },
                    { 1002, 3, true, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionNumber", "AccountNumber", "Amount", "Note", "TransactionDate", "TransactionType" },
                values: new object[,]
                {
                    { 1, 1001, 50000.00m, "Initial Deposit", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diposite" },
                    { 2, 1002, 150000.00m, "Company Capital", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diposite" },
                    { 3, 1002, 30000.00m, "Equipment Purchase", new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdraw" },
                    { 4, 1003, 25000.00m, "Account Opening", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diposite" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerAccounts",
                keyColumns: new[] { "AccountNumber", "CustomerId" },
                keyValues: new object[] { 1001, 1 });

            migrationBuilder.DeleteData(
                table: "CustomerAccounts",
                keyColumns: new[] { "AccountNumber", "CustomerId" },
                keyValues: new object[] { 1002, 1 });

            migrationBuilder.DeleteData(
                table: "CustomerAccounts",
                keyColumns: new[] { "AccountNumber", "CustomerId" },
                keyValues: new object[] { 1003, 2 });

            migrationBuilder.DeleteData(
                table: "CustomerAccounts",
                keyColumns: new[] { "AccountNumber", "CustomerId" },
                keyValues: new object[] { 1002, 3 });

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionNumber",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionNumber",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionNumber",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionNumber",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
