using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imgUrl",
                table: "Movies",
                newName: "ImgUrl");

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Duration", "Genre", "ImgUrl", "Premiere", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut et consectetur velit. Donec ut orci eget massa ullamcorper vestibulum. Etiam non interdum est, vel lobortis justo. Vivamus ligula libero, hendrerit aliquet justo vel, pharetra fermentum felis.", 90, "Family", "https://www.imdb.com/title/tt0126029/mediaviewer/rm955136512/?ref_=tt_ov_i", new DateTime(2004, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shrek" },
                    { 2, "Mauris at tristique quam. Vestibulum at augue euismod, consectetur tortor in, ultrices mi. Nulla maximus aliquam orci quis commodo. Nam tristique neque a metus egestas mollis a placerat lectus. Morbi felis urna, fringilla ut ligula sed, sagittis semper leo.", 175, "Crime", "https://www.imdb.com/title/tt0068646/mediaviewer/rm746868224/?ref_=tt_ov_i", new DateTime(1972, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { 3, "onec nisl nunc, fringilla eu tincidunt in, lobortis id orci. Proin sem libero, condimentum id erat ut, fringilla hendrerit justo. Proin a imperdiet erat, sed convallis quam. Integer sed tellus purus. Ut tempor mauris eu odio lobortis, in maximus velit mattis. Nam vel mi id risus malesuada porta in id lacus.", 187, "Crime", "https://www.imdb.com/title/tt0110912/mediaviewer/rm1959546112/?ref_=tt_ov_i", new DateTime(1994, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp fiction" },
                    { 4, "Roin sit amet leo sed ante hendrerit fermentum sed et mi. Nulla facilisi. Morbi orci est, tristique non pharetra ac, tincidunt quis ligula. Vestibulum pretium sodales tempus. Sed sollicitudin pharetra ante, sit amet pharetra neque tristique tincidunt. ", 159, "Action", "https://www.imdb.com/title/tt1375666/mediaviewer/rm3426651392/?ref_=tt_ov_i", new DateTime(2010, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" },
                    { 5, "Aliquam consectetur vehicula velit eget interdum. Donec dui libero, malesuada nec efficitur in, convallis vitae lorem. Vivamus ac pulvinar enim, pharetra finibus massa.", 149, "Action", "https://www.imdb.com/title/tt9362722/mediaviewer/rm1009725185/?ref_=tt_ov_i", new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-man: Across the spider verse" },
                    { 6, "Aenean ornare tortor nec odio rhoncus dignissim. Aliquam orci magna, semper sed pulvinar non, dictum vitae turpis. Suspendisse bibendum magna ac ante vehicula lacinia. Nulla congue libero auctor tempus lobortis. ", 180, "History", "https://www.imdb.com/title/tt15398776/mediaviewer/rm2670601217/?ref_=tt_ov_i", new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oppenheimer" },
                    { 7, "Aliquam et ornare libero, sed fermentum turpis. Praesent fermentum felis vitae consectetur maximus. Maecenas eu eleifend neque. Sed lorem lorem, commodo quis scelerisque feugiat, faucibus quis justo.", 150, "Action", "https://www.imdb.com/title/tt4154756/mediaviewer/rm4044245504/?ref_=tt_ov_i", new DateTime(2018, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avengers: infinity war" },
                    { 8, "Curabitur luctus massa ligula, vitae vestibulum leo aliquam eu. Etiam a felis semper, mollis metus eget, sollicitudin ante. Cras ultricies arcu eu arcu scelerisque consectetur.", 110, "Animation", "https://www.imdb.com/title/tt5311514/mediaviewer/rm3216783616/?ref_=tt_ov_i", new DateTime(2016, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Your name" },
                    { 9, "Sed ligula mauris, congue ac ex in, sagittis ultrices ante. Proin sagittis, ante sed consequat ornare, urna neque porttitor magna, ut posuere ante ligula nec libero. Maecenas lacinia ornare massa, at luctus sapien imperdiet nec.", 160, "Action", "https://www.imdb.com/title/tt0133093/mediaviewer/rm525547776/?ref_=tt_ov_i", new DateTime(1999, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matrix" },
                    { 10, "Aliquam quis gravida ipsum, ac sollicitudin orci. Ut iaculis mattis tincidunt. Duis quam risus, dignissim et ex in, vestibulum blandit erat. Nam vulputate est et iaculis pretium. Cras vitae purus enim. Integer ac condimentum turpis.", 150, "Drama", "https://www.imdb.com/title/tt0137523/mediaviewer/rm1412004864/?ref_=tt_ov_i", new DateTime(1999, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fight club" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "Movies",
                newName: "imgUrl");
        }
    }
}
