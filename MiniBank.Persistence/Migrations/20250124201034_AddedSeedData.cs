using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniBank.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "CreatedDate", "Description", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 25, 0, 10, 33, 704, DateTimeKind.Local).AddTicks(28), "Savings account", false, "Savings", null },
                    { 2, new DateTime(2025, 1, 25, 0, 10, 33, 704, DateTimeKind.Local).AddTicks(43), "Current account", false, "Current", null }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "CreatedDate", "IsDeleted", "Name", "Symbol", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "USD", new DateTime(2025, 1, 25, 0, 10, 33, 704, DateTimeKind.Local).AddTicks(227), false, "US Dollar", "$", null },
                    { 2, "EUR", new DateTime(2025, 1, 25, 0, 10, 33, 704, DateTimeKind.Local).AddTicks(229), false, "Euro", "€", null },
                    { 3, "GEL", new DateTime(2025, 1, 25, 0, 10, 33, 704, DateTimeKind.Local).AddTicks(231), false, "Georgian Lari", "₾", null },
                    { 4, "TL", new DateTime(2025, 1, 25, 0, 10, 33, 704, DateTimeKind.Local).AddTicks(233), false, "Turkish Lira", "₺", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 25, 0, 10, 33, 704, DateTimeKind.Local).AddTicks(264), false, "Admin", null },
                    { 2, new DateTime(2025, 1, 25, 0, 10, 33, 704, DateTimeKind.Local).AddTicks(266), false, "Employer", null },
                    { 3, new DateTime(2025, 1, 25, 0, 10, 33, 704, DateTimeKind.Local).AddTicks(267), false, "Customer", null }
                });

            migrationBuilder.InsertData(
                table: "TransactionStatuses",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 25, 0, 10, 33, 704, DateTimeKind.Local).AddTicks(305), false, "Pending", null },
                    { 2, new DateTime(2025, 1, 25, 0, 10, 33, 704, DateTimeKind.Local).AddTicks(307), false, "Completed", null },
                    { 3, new DateTime(2025, 1, 25, 0, 10, 33, 704, DateTimeKind.Local).AddTicks(308), false, "Failed", null },
                    { 4, new DateTime(2025, 1, 25, 0, 10, 33, 704, DateTimeKind.Local).AddTicks(309), false, "Cancelled", null }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 25, 0, 10, 33, 704, DateTimeKind.Local).AddTicks(346), false, "Deposit", null },
                    { 2, new DateTime(2025, 1, 25, 0, 10, 33, 704, DateTimeKind.Local).AddTicks(348), false, "Withdrawal", null },
                    { 3, new DateTime(2025, 1, 25, 0, 10, 33, 704, DateTimeKind.Local).AddTicks(350), false, "Transfer", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TransactionStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransactionStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TransactionStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TransactionStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
