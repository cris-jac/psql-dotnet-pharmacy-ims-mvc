using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaMVC.Migrations
{
    /// <inheritdoc />
    public partial class Updatedtransactionandsalesmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionItem_Transactions_TransactionId",
                table: "TransactionItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionItem",
                table: "TransactionItem");

            migrationBuilder.RenameTable(
                name: "TransactionItem",
                newName: "TransactionItems");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionItem_TransactionId",
                table: "TransactionItems",
                newName: "IX_TransactionItems_TransactionId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "TransactionItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionItems",
                table: "TransactionItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionItems_Transactions_TransactionId",
                table: "TransactionItems",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionItems_Transactions_TransactionId",
                table: "TransactionItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionItems",
                table: "TransactionItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "TransactionItems",
                newName: "TransactionItem");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionItems_TransactionId",
                table: "TransactionItem",
                newName: "IX_TransactionItem_TransactionId");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "TransactionItem",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionItem",
                table: "TransactionItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionItem_Transactions_TransactionId",
                table: "TransactionItem",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id");
        }
    }
}
