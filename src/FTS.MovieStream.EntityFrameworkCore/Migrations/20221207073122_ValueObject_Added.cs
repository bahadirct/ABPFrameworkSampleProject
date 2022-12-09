using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTS.MovieStream.Migrations
{
    public partial class ValueObject_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CastMember",
                table: "AppMovies");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppMovies");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppMovies");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppMovies");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppMovies");

            migrationBuilder.RenameColumn(
                name: "PublishDate",
                table: "AppMovies",
                newName: "Information_PublishDate");

            migrationBuilder.RenameColumn(
                name: "ProductionCompany",
                table: "AppMovies",
                newName: "Information_ProductionCompany");

            migrationBuilder.RenameColumn(
                name: "Director",
                table: "AppMovies",
                newName: "Information_Director");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "AppMovies",
                newName: "Information_Description");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Information_PublishDate",
                table: "AppMovies",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Information_ProductionCompany",
                table: "AppMovies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Information_Director",
                table: "AppMovies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Information_Description",
                table: "AppMovies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "CastMember",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CastMember_AppMovies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "AppMovies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CastMember_MovieId",
                table: "CastMember",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CastMember");

            migrationBuilder.RenameColumn(
                name: "Information_PublishDate",
                table: "AppMovies",
                newName: "PublishDate");

            migrationBuilder.RenameColumn(
                name: "Information_ProductionCompany",
                table: "AppMovies",
                newName: "ProductionCompany");

            migrationBuilder.RenameColumn(
                name: "Information_Director",
                table: "AppMovies",
                newName: "Director");

            migrationBuilder.RenameColumn(
                name: "Information_Description",
                table: "AppMovies",
                newName: "Description");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishDate",
                table: "AppMovies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductionCompany",
                table: "AppMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Director",
                table: "AppMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AppMovies",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CastMember",
                table: "AppMovies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppMovies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppMovies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppMovies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppMovies",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
