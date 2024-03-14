using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderAPI.Migrations
{
    /// <inheritdoc />
    public partial class TableNameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderQuoteItem_OrderQuoutes_OrderQuoteId",
                table: "OrderQuoteItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderQuoutes",
                table: "OrderQuoutes");

            migrationBuilder.RenameTable(
                name: "OrderQuoutes",
                newName: "OrderQuotes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderQuotes",
                table: "OrderQuotes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderQuoteItem_OrderQuotes_OrderQuoteId",
                table: "OrderQuoteItem",
                column: "OrderQuoteId",
                principalTable: "OrderQuotes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderQuoteItem_OrderQuotes_OrderQuoteId",
                table: "OrderQuoteItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderQuotes",
                table: "OrderQuotes");

            migrationBuilder.RenameTable(
                name: "OrderQuotes",
                newName: "OrderQuoutes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderQuoutes",
                table: "OrderQuoutes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderQuoteItem_OrderQuoutes_OrderQuoteId",
                table: "OrderQuoteItem",
                column: "OrderQuoteId",
                principalTable: "OrderQuoutes",
                principalColumn: "Id");
        }
    }
}
