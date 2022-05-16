using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PptNemocnice.Api.Migrations
{
    public partial class pridanadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vybavenis",
                columns: new[] { "Id", "BoughtDateTime", "Name", "PriceCzk" },
                values: new object[] { new Guid("111ca371-e28b-4107-845c-ac9823893da4"), new DateTime(2015, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "MRI", 10000 });

            migrationBuilder.InsertData(
                table: "Vybavenis",
                columns: new[] { "Id", "BoughtDateTime", "Name", "PriceCzk" },
                values: new object[] { new Guid("aaaca371-e28b-4107-845c-ac9823893da4"), new DateTime(2017, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "CT", 100000 });

            migrationBuilder.InsertData(
                table: "Revizes",
                columns: new[] { "Id", "DateTime", "Name", "VybaveniId" },
                values: new object[] { new Guid("bbbca371-e28b-4107-845c-ac9823893da4"), new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Přísná revize", new Guid("aaaca371-e28b-4107-845c-ac9823893da4") });

            migrationBuilder.InsertData(
                table: "Revizes",
                columns: new[] { "Id", "DateTime", "Name", "VybaveniId" },
                values: new object[] { new Guid("dddca371-e28b-4107-845c-ac9823893da4"), new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicmoc revize", new Guid("aaaca371-e28b-4107-845c-ac9823893da4") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("bbbca371-e28b-4107-845c-ac9823893da4"));

            migrationBuilder.DeleteData(
                table: "Revizes",
                keyColumn: "Id",
                keyValue: new Guid("dddca371-e28b-4107-845c-ac9823893da4"));

            migrationBuilder.DeleteData(
                table: "Vybavenis",
                keyColumn: "Id",
                keyValue: new Guid("111ca371-e28b-4107-845c-ac9823893da4"));

            migrationBuilder.DeleteData(
                table: "Vybavenis",
                keyColumn: "Id",
                keyValue: new Guid("aaaca371-e28b-4107-845c-ac9823893da4"));
        }
    }
}
