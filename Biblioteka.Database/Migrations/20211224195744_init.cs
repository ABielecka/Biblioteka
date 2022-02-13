using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteka.Database.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADDRESS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    POSTAL_CODE = table.Column<string>(type: "NVARCHAR2(6)", maxLength: 6, nullable: false),
                    CITY = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    STREET = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    NUMBER = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BOOK_TYPE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOK_TYPE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COUNTRY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUNTRY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "READER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    R_INDEX_NUMBER = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FIRST_NAME = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    LAST_NAME = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    NUMBER_OF_BOOKS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ADDRESS_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_READER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_READER_ADDRESS_ADDRESS_ID",
                        column: x => x.ADDRESS_ID,
                        principalTable: "ADDRESS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AUTHOR",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LAST_NAME = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    COUNTRY_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTHOR", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AUTHOR_COUNTRY_COUNTRY_ID",
                        column: x => x.COUNTRY_ID,
                        principalTable: "COUNTRY",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    LAST_NAME = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    PASSWORD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ROLE_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_ROLE_ROLE_ID",
                        column: x => x.ROLE_ID,
                        principalTable: "ROLE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "BOOK",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    B_INDEX_NUMBER = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TITLE = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    YEAR = table.Column<string>(type: "NVARCHAR2(4)", maxLength: 4, nullable: false),
                    LANGUGE = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    IS_RETURNED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    STATUS = table.Column<bool>(type: "NUMBER(1)", nullable: true),
                    BOOK_TYPE_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AUTHOR_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOK", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BOOK_AUTHOR_AUTHOR_ID",
                        column: x => x.AUTHOR_ID,
                        principalTable: "AUTHOR",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_BOOK_BOOK_TYPE_BOOK_TYPE_ID",
                        column: x => x.BOOK_TYPE_ID,
                        principalTable: "BOOK_TYPE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RENTAL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    RENTAL_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    RETURN_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IS_RETURNED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    OVERDUE_TIME = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    FINE = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    BOOK_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    READER_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RENTAL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RENTAL_BOOK_BOOK_ID",
                        column: x => x.BOOK_ID,
                        principalTable: "BOOK",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RENTAL_READER_READER_ID",
                        column: x => x.READER_ID,
                        principalTable: "READER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUTHOR_COUNTRY_ID",
                table: "AUTHOR",
                column: "COUNTRY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BOOK_AUTHOR_ID",
                table: "BOOK",
                column: "AUTHOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BOOK_BOOK_TYPE_ID",
                table: "BOOK",
                column: "BOOK_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_READER_ADDRESS_ID",
                table: "READER",
                column: "ADDRESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RENTAL_BOOK_ID",
                table: "RENTAL",
                column: "BOOK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RENTAL_READER_ID",
                table: "RENTAL",
                column: "READER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROLE_ID",
                table: "USER",
                column: "ROLE_ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RENTAL");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "BOOK");

            migrationBuilder.DropTable(
                name: "READER");

            migrationBuilder.DropTable(
                name: "ROLE");

            migrationBuilder.DropTable(
                name: "AUTHOR");

            migrationBuilder.DropTable(
                name: "BOOK_TYPE");

            migrationBuilder.DropTable(
                name: "ADDRESS");

            migrationBuilder.DropTable(
                name: "COUNTRY");
        }
    }
}
