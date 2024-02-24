using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notify_event",
                columns: table => new
                {
                    sessionid = table.Column<string>(name: "session_id", type: "VARCHAR", nullable: false),
                    ordertype = table.Column<string>(name: "order_type", type: "VARCHAR", nullable: false),
                    card = table.Column<string>(type: "VARCHAR", nullable: false),
                    eventdate = table.Column<string>(name: "event_date", type: "VARCHAR", nullable: false),
                    websiteurl = table.Column<string>(name: "website_url", type: "VARCHAR", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notify_event", x => x.sessionid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notify_event");
        }
    }
}
