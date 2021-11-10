using Microsoft.EntityFrameworkCore.Migrations;

namespace WhereWasI.Migrations
{
    public partial class UpdateContextFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Category_CategoryID",
                table: "BookCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Item_ItemID",
                table: "BookCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCategory",
                table: "BookCategory");

            migrationBuilder.RenameTable(
                name: "BookCategory",
                newName: "ItemCategory");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategory_CategoryID",
                table: "ItemCategory",
                newName: "IX_ItemCategory_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemCategory",
                table: "ItemCategory",
                columns: new[] { "ItemID", "CategoryID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCategory_Category_CategoryID",
                table: "ItemCategory",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCategory_Item_ItemID",
                table: "ItemCategory",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCategory_Category_CategoryID",
                table: "ItemCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemCategory_Item_ItemID",
                table: "ItemCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemCategory",
                table: "ItemCategory");

            migrationBuilder.RenameTable(
                name: "ItemCategory",
                newName: "BookCategory");

            migrationBuilder.RenameIndex(
                name: "IX_ItemCategory_CategoryID",
                table: "BookCategory",
                newName: "IX_BookCategory_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCategory",
                table: "BookCategory",
                columns: new[] { "ItemID", "CategoryID" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Category_CategoryID",
                table: "BookCategory",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Item_ItemID",
                table: "BookCategory",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
