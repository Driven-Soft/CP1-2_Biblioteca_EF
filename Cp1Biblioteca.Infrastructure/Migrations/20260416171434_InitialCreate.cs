using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cp1Biblioteca.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LIB_Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIB_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LIB_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIB_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LIB_Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIB_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LIB_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    TelNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIB_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LIB_Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PublisherId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIB_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LIB_Books_LIB_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "LIB_Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LIB_BookAuthors",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIB_BookAuthors", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_LIB_BookAuthors_LIB_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "LIB_Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LIB_BookAuthors_LIB_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "LIB_Books",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LIB_BookCategories",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIB_BookCategories", x => new { x.BookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_LIB_BookCategories_LIB_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "LIB_Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LIB_BookCategories_LIB_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "LIB_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LIB_Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExpectedReturnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIB_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LIB_Loans_LIB_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "LIB_Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LIB_Loans_LIB_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "LIB_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LIB_BookAuthors_AuthorId",
                table: "LIB_BookAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_LIB_BookCategories_CategoryId",
                table: "LIB_BookCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LIB_Books_PublisherId",
                table: "LIB_Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_LIB_Loans_BookId",
                table: "LIB_Loans",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LIB_Loans_UserId",
                table: "LIB_Loans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LIB_Users_Email",
                table: "LIB_Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LIB_BookAuthors");

            migrationBuilder.DropTable(
                name: "LIB_BookCategories");

            migrationBuilder.DropTable(
                name: "LIB_Loans");

            migrationBuilder.DropTable(
                name: "LIB_Authors");

            migrationBuilder.DropTable(
                name: "LIB_Categories");

            migrationBuilder.DropTable(
                name: "LIB_Books");

            migrationBuilder.DropTable(
                name: "LIB_Users");

            migrationBuilder.DropTable(
                name: "LIB_Publishers");
        }
    }
}
