using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeShare.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Text" },
                values: new object[] { new DateTime(2026, 3, 30, 13, 16, 38, 827, DateTimeKind.Local).AddTicks(9308), "Harika bir tarif, denedim çok güzel oldu!" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "RecipeId", "Text", "UserId" },
                values: new object[] { new DateTime(2026, 3, 30, 14, 16, 38, 827, DateTimeKind.Local).AddTicks(9314), 1, "Tuzu biraz az geldi ama kıvamı müthiş.", 3 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedDate", "RecipeId", "Text", "UserId" },
                values: new object[] { 3, new DateTime(2026, 3, 30, 15, 16, 38, 827, DateTimeKind.Local).AddTicks(9315), 2, "Çok lezzetli görünüyor, elinize sağlık.", 1 });

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

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Content", "CreatedDate", "Title", "UserId" },
                values: new object[,]
                {
                    { 3, "İnce hamur üzerine bol mozzarella ve taze fesleğen ekleyin.", new DateTime(2026, 3, 27, 15, 16, 38, 827, DateTimeKind.Local).AddTicks(9295), "İtalyan Usulü Pizza", 3 },
                    { 4, "Dana döş etinden hazırladığınız köfteleri döküm tavada mühürleyin.", new DateTime(2026, 3, 28, 15, 16, 38, 827, DateTimeKind.Local).AddTicks(9296), "Ev Yapımı Burger", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "RoleId", "Username" },
                values: new object[] { 4, "robot@mail.com", "1234", 2, "mutfak_robotu" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedDate", "RecipeId", "Text", "UserId" },
                values: new object[] { 4, new DateTime(2026, 3, 30, 15, 16, 38, 827, DateTimeKind.Local).AddTicks(9316), 2, "Blenderdan geçirmeden önce süzmek daha iyi sonuç veriyor.", 4 });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Content", "CreatedDate", "Title", "UserId" },
                values: new object[] { 5, "Garnitürlerle birlikte kısık ateşte pişirerek servis yapın.", new DateTime(2026, 3, 29, 15, 16, 38, 827, DateTimeKind.Local).AddTicks(9297), "Zeytinyağlı Enginar", 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Text" },
                values: new object[] { new DateTime(2026, 3, 26, 19, 43, 36, 171, DateTimeKind.Local).AddTicks(2235), "Harika bir tarif!" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "RecipeId", "Text", "UserId" },
                values: new object[] { new DateTime(2026, 3, 26, 19, 43, 36, 171, DateTimeKind.Local).AddTicks(2239), 2, "Çok lezzetli görünüyor.", 1 });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "Yumurtayı tavaya kırarak yapabilirsiniz.", new DateTime(2026, 3, 26, 19, 43, 36, 171, DateTimeKind.Local).AddTicks(2198) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "Mercimekleri haşlayıp blenderdan geçirin.", new DateTime(2026, 3, 25, 19, 43, 36, 171, DateTimeKind.Local).AddTicks(2213) });
        }
    }
}
