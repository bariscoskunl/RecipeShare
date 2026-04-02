using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeShare.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Recipes",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 22, 11, 46, 58, DateTimeKind.Local).AddTicks(2609));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 23, 11, 46, 58, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 2, 0, 11, 46, 58, DateTimeKind.Local).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 2, 0, 11, 46, 58, DateTimeKind.Local).AddTicks(2618));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "CreatedDate", "ImageUrl" },
                values: new object[] { "...", new DateTime(2026, 3, 28, 0, 11, 46, 58, DateTimeKind.Local).AddTicks(2558), "/images/default-recipe.jpg" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "CreatedDate", "ImageUrl" },
                values: new object[] { "...", new DateTime(2026, 3, 29, 0, 11, 46, 58, DateTimeKind.Local).AddTicks(2594), "/images/default-recipe.jpg" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Content", "CreatedDate", "ImageUrl" },
                values: new object[] { "...", new DateTime(2026, 3, 30, 0, 11, 46, 58, DateTimeKind.Local).AddTicks(2595), "/images/default-recipe.jpg" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Content", "CreatedDate", "ImageUrl" },
                values: new object[] { "...", new DateTime(2026, 3, 31, 0, 11, 46, 58, DateTimeKind.Local).AddTicks(2597), "/images/default-recipe.jpg" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Content", "CreatedDate", "ImageUrl" },
                values: new object[] { "...", new DateTime(2026, 4, 1, 0, 11, 46, 58, DateTimeKind.Local).AddTicks(2598), "/images/default-recipe.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Recipes");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 30, 13, 16, 38, 827, DateTimeKind.Local).AddTicks(9308));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 30, 14, 16, 38, 827, DateTimeKind.Local).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 30, 15, 16, 38, 827, DateTimeKind.Local).AddTicks(9315));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 30, 15, 16, 38, 827, DateTimeKind.Local).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "Tereyağını eritin, yumurtaları kırın ve 2 dakika pişirin.", new DateTime(2026, 3, 25, 15, 16, 38, 827, DateTimeKind.Local).AddTicks(9261) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "Mercimek, soğan ve havucu haşlayıp blenderdan geçirin.", new DateTime(2026, 3, 26, 15, 16, 38, 827, DateTimeKind.Local).AddTicks(9294) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "İnce hamur üzerine bol mozzarella ve taze fesleğen ekleyin.", new DateTime(2026, 3, 27, 15, 16, 38, 827, DateTimeKind.Local).AddTicks(9295) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "Dana döş etinden hazırladığınız köfteleri döküm tavada mühürleyin.", new DateTime(2026, 3, 28, 15, 16, 38, 827, DateTimeKind.Local).AddTicks(9296) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "Garnitürlerle birlikte kısık ateşte pişirerek servis yapın.", new DateTime(2026, 3, 29, 15, 16, 38, 827, DateTimeKind.Local).AddTicks(9297) });
        }
    }
}
