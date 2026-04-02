using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeShare.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContentField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 2, 13, 7, 12, 891, DateTimeKind.Local).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 2, 14, 7, 12, 891, DateTimeKind.Local).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 2, 15, 7, 12, 891, DateTimeKind.Local).AddTicks(2342));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 2, 15, 7, 12, 891, DateTimeKind.Local).AddTicks(2343));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "Tereyağını sahanda eritip köpürmesini bekleyin. Yumurtaları sarılarını bozmadan kırın, üzerine bir tutam tuz ve pul biber ekleyerek beyazları tamamen pişene kadar orta ateşte tutun.", new DateTime(2026, 3, 28, 15, 7, 12, 891, DateTimeKind.Local).AddTicks(2303) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "Soğan, havuç ve patatesi kavurduktan sonra yıkanmış kırmızı mercimeği ekleyin. Sıcak su ilavesiyle mercimekler yumuşayana kadar haşlayıp blenderdan geçirin. Üzerine kızgın tereyağlı sos dökün.", new DateTime(2026, 3, 29, 15, 7, 12, 891, DateTimeKind.Local).AddTicks(2325) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "İnce açılmış hamurun üzerine taze fesleğenli domates sosu ve bol mozarella peyniri yayın. Tercihen taş fırında veya 250 derece ısıtılmış fırında kenarları çıtırlaşana kadar yaklaşık 10 dakika pişirin.", new DateTime(2026, 3, 30, 15, 7, 12, 891, DateTimeKind.Local).AddTicks(2327) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "Dinlendirilmiş dana kıymadan hazırlanan kalın köfteleri döküm tavada mühürleyin. Karamelize soğan, cheddar peyniri ve özel burger sosu ile ısıtılmış brioche ekmeği arasında servis yapın.", new DateTime(2026, 3, 31, 15, 7, 12, 891, DateTimeKind.Local).AddTicks(2328) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "Garnitür karışımını (bezelye, havuç, patates) limonlu suda bekletilmiş enginarların ortasına yerleştirin. Bol sızma zeytinyağı, bir tutam şeker ve portakal suyu ekleyerek kısık ateşte yumuşayana kadar pişirin.", new DateTime(2026, 4, 1, 15, 7, 12, 891, DateTimeKind.Local).AddTicks(2329) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "...", new DateTime(2026, 3, 28, 0, 11, 46, 58, DateTimeKind.Local).AddTicks(2558) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "...", new DateTime(2026, 3, 29, 0, 11, 46, 58, DateTimeKind.Local).AddTicks(2594) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "...", new DateTime(2026, 3, 30, 0, 11, 46, 58, DateTimeKind.Local).AddTicks(2595) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "...", new DateTime(2026, 3, 31, 0, 11, 46, 58, DateTimeKind.Local).AddTicks(2597) });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Content", "CreatedDate" },
                values: new object[] { "...", new DateTime(2026, 4, 1, 0, 11, 46, 58, DateTimeKind.Local).AddTicks(2598) });
        }
    }
}
