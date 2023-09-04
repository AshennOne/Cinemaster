using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImagesSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_960,h_1400/v1691161775/shrek_q7kypt.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_960,h_1400/v1691161764/theGodfather_isikq1.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_960,h_1400/v1693654114/cinemaster/rz2l4qrdzewkjbetps8h.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_960,h_1400/v1693653947/cinemaster/sux34vs7rceqjrf6c3r6.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_960,h_1400/v1693654324/cinemaster/n15y3q7pn9xidumtftap.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_960,h_1400/v1693654065/cinemaster/hugmltz8lkwizzburvdb.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_960,h_1400/v1693817252/cinemaster/rkawofbz2bisyy72ui7g.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_960,h_1400/v1693654263/cinemaster/llqtpuuplswi9oc2camv.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_960,h_1400/v1693653999/cinemaster/dhma7fwmmsf1qz05ij9f.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_960,h_1400/v1693653899/cinemaster/lhwpvglpjbromouh03xg.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691161775/shrek_q7kypt.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691161764/theGodfather_isikq1.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691162620/babrie_xe7yii.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691161775/shrek_q7kypt.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691161764/theGodfather_isikq1.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691162620/babrie_xe7yii.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691161775/shrek_q7kypt.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691161764/theGodfather_isikq1.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691162620/babrie_xe7yii.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImgUrl",
                value: "https://res.cloudinary.com/dwy4hhhjr/image/upload/w_240,h_350/v1691161775/shrek_q7kypt.jpg");
        }
    }
}
