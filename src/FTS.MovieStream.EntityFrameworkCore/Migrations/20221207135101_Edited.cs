using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTS.MovieStream.Migrations
{
    public partial class Edited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CastMember_AppMovies_MovieId",
                table: "CastMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CastMember",
                table: "CastMember");

            migrationBuilder.DropColumn(
                name: "FullMovieUrl",
                table: "AppMovies");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AppMovies");

            migrationBuilder.DropColumn(
                name: "Information_ProductionCompany",
                table: "AppMovies");

            migrationBuilder.DropColumn(
                name: "MovieTrailerUrl",
                table: "AppMovies");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "CastMember");

            migrationBuilder.RenameTable(
                name: "CastMember",
                newName: "AppCastMembers");

            migrationBuilder.RenameIndex(
                name: "IX_CastMember_MovieId",
                table: "AppCastMembers",
                newName: "IX_AppCastMembers_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCastMembers",
                table: "AppCastMembers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCastMembers_AppMovies_MovieId",
                table: "AppCastMembers",
                column: "MovieId",
                principalTable: "AppMovies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCastMembers_AppMovies_MovieId",
                table: "AppCastMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCastMembers",
                table: "AppCastMembers");

            migrationBuilder.RenameTable(
                name: "AppCastMembers",
                newName: "CastMember");

            migrationBuilder.RenameIndex(
                name: "IX_AppCastMembers_MovieId",
                table: "CastMember",
                newName: "IX_CastMember_MovieId");

            migrationBuilder.AddColumn<string>(
                name: "FullMovieUrl",
                table: "AppMovies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AppMovies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Information_ProductionCompany",
                table: "AppMovies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MovieTrailerUrl",
                table: "AppMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "CastMember",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CastMember",
                table: "CastMember",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CastMember_AppMovies_MovieId",
                table: "CastMember",
                column: "MovieId",
                principalTable: "AppMovies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
