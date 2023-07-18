using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class create_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginPassworld = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rootobjects",
                columns: table => new
                {
                    page = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    total_pages = table.Column<int>(type: "int", nullable: false),
                    total_results = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rootobjects", x => x.page);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adult = table.Column<bool>(type: "bit", nullable: false),
                    backdrop_path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    original_language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    original_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    overview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    poster_path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    media_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genre_ids = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    popularity = table.Column<float>(type: "real", nullable: false),
                    release_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    video = table.Column<bool>(type: "bit", nullable: false),
                    vote_average = table.Column<float>(type: "real", nullable: false),
                    vote_count = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    original_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    first_air_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    origin_country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rootobjectpage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.id);
                    table.ForeignKey(
                        name: "FK_Results_Rootobjects_Rootobjectpage",
                        column: x => x.Rootobjectpage,
                        principalTable: "Rootobjects",
                        principalColumn: "page");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_Rootobjectpage",
                table: "Results",
                column: "Rootobjectpage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Rootobjects");
        }
    }
}
