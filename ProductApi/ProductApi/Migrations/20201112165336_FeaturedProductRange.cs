using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ProductApi.Migrations
{
    public partial class FeaturedProductRange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeaturedProductRange",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKUMin = table.Column<int>(nullable: false),
                    SKUMax = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturedProductRange", x => x.ID);
                });

            migrationBuilder.Sql("" +
                "Insert Into FeaturedProductRange(Skumin, Skumax) Values(10000, 19999);" + 
                "Insert Into FeaturedProductRange(Skumin, Skumax) Values(20000, 29999);" + 
                "Insert Into FeaturedProductRange(Skumin, Skumax) Values(30000, 39999);" +
                "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeaturedProductRange");
        }
    }
}
