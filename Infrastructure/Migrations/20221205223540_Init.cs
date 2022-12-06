using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Blog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_Blog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blog",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BlogTags",
                columns: table => new
                {
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTags", x => new { x.BlogId, x.TagId });
                    table.ForeignKey(
                        name: "FK_BlogTags_Blog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogTags_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Blog",
                columns: new[] { "Id", "Body", "CreatedAt", "Description", "Slug", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2d5a1f3c-c149-4b3c-8ee9-6aaa0e870340"), "The app is simple to use, and will help you decide on your best furniture fit.", new DateTime(2022, 11, 29, 23, 35, 39, 917, DateTimeKind.Local).AddTicks(3712), "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.", "augmented-reality-ios-application-3", "Augmented Reality iOS Application 3", new DateTime(2022, 12, 3, 23, 35, 39, 917, DateTimeKind.Local).AddTicks(3713) },
                    { new Guid("fafc7e94-6b81-4b55-ae7e-7d542d727815"), "The app is simple to use, and will help you decide on your best furniture fit.", new DateTime(2022, 12, 1, 23, 35, 39, 917, DateTimeKind.Local).AddTicks(3664), "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.", "augmented-reality-ios-application", "Augmented Reality iOS Application", new DateTime(2022, 12, 4, 23, 35, 39, 917, DateTimeKind.Local).AddTicks(3703) },
                    { new Guid("fe7bcfea-a650-4e18-979e-75c113c05908"), "The app is simple to use, and will help you decide on your best furniture fit.", new DateTime(2022, 12, 3, 23, 35, 39, 917, DateTimeKind.Local).AddTicks(3708), "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.", "augmented-reality-ios-application-2", "Augmented Reality iOS Application 2", new DateTime(2022, 12, 5, 23, 35, 39, 917, DateTimeKind.Local).AddTicks(3709) }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "BlogId", "Name" },
                values: new object[,]
                {
                    { 1, null, "IOS" },
                    { 2, null, "AR" },
                    { 3, null, "Gazzda" }
                });

            migrationBuilder.InsertData(
                table: "BlogTags",
                columns: new[] { "BlogId", "TagId" },
                values: new object[,]
                {
                    { new Guid("2d5a1f3c-c149-4b3c-8ee9-6aaa0e870340"), 1 },
                    { new Guid("fafc7e94-6b81-4b55-ae7e-7d542d727815"), 2 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BlogId", "BlogSlug", "Body", "CreatedAt", "Slug", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("552fb2d3-970f-4de0-9daf-1c7710c65224"), new Guid("fafc7e94-6b81-4b55-ae7e-7d542d727815"), "augmented-reality-ios-application-3", "Great blog.", new DateTime(2022, 11, 29, 23, 35, 39, 917, DateTimeKind.Local).AddTicks(3740), "augmented-reality-ios-application-3", new DateTime(2022, 12, 3, 23, 35, 39, 917, DateTimeKind.Local).AddTicks(3742) },
                    { new Guid("8edd0363-4708-4cbd-89fc-cd9591a54f13"), new Guid("fafc7e94-6b81-4b55-ae7e-7d542d727815"), "augmented-reality-ios-application", "Great grate blog.", new DateTime(2022, 12, 3, 23, 35, 39, 917, DateTimeKind.Local).AddTicks(3825), "augmented-reality-ios-application", new DateTime(2022, 12, 5, 23, 35, 39, 917, DateTimeKind.Local).AddTicks(3827) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogTags_TagId",
                table: "BlogTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_BlogId",
                table: "Tag",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogTags");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Blog");
        }
    }
}
