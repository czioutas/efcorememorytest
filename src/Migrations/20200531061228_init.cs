using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using efcorememorytest.Entities;

namespace efcorememorytest.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nested1TestModel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nested1TestModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nested2TestModel",
                columns: table => new
                {
                    A = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Nested3TestModel",
                columns: table => new
                {
                    A = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Nested4TestModel",
                columns: table => new
                {
                    A = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Nested5TestModel",
                columns: table => new
                {
                    A = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Nested6TestModel",
                columns: table => new
                {
                    A = table.Column<string>(nullable: true),
                    SubNested6TestModel1 = table.Column<IEnumerable<SubNested6TestModel1>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TestModels",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Num1 = table.Column<long>(nullable: false),
                    Num2 = table.Column<long>(nullable: false),
                    Num3 = table.Column<long>(nullable: false),
                    A = table.Column<string>(nullable: true),
                    AA = table.Column<string>(nullable: true),
                    AAA = table.Column<string>(nullable: true),
                    AAAA = table.Column<string>(nullable: true),
                    AAAAA = table.Column<string>(nullable: true),
                    AAAAAA = table.Column<string>(nullable: true),
                    IEnumerableShortJsonB = table.Column<IEnumerable<short>>(type: "jsonb", nullable: true),
                    IEnumerableShortJsonBB = table.Column<IEnumerable<short>>(type: "jsonb", nullable: true),
                    BoolB = table.Column<bool>(nullable: true),
                    BoolA = table.Column<bool>(nullable: true),
                    BoolAA = table.Column<bool>(nullable: true),
                    BoolAAA = table.Column<bool>(nullable: true),
                    BoolAAAA = table.Column<bool>(nullable: true),
                    ValidToA = table.Column<DateTimeOffset>(nullable: true),
                    ValidToAA = table.Column<DateTimeOffset>(nullable: true),
                    ValidToAAA = table.Column<DateTimeOffset>(nullable: true),
                    ValidToAAAA = table.Column<DateTimeOffset>(nullable: true),
                    ValidToAAAAA = table.Column<DateTimeOffset>(nullable: true),
                    ValidToAAAAAA = table.Column<DateTimeOffset>(nullable: true),
                    Nested1TestModelId = table.Column<long>(nullable: true),
                    Nested2TestModel = table.Column<IEnumerable<Nested2TestModel>>(type: "jsonb", nullable: true),
                    Nested3TestModel = table.Column<IEnumerable<Nested3TestModel>>(type: "jsonb", nullable: true),
                    Nested4TestModel = table.Column<IEnumerable<Nested4TestModel>>(type: "jsonb", nullable: true),
                    Nested5TestModel = table.Column<IEnumerable<Nested5TestModel>>(type: "jsonb", nullable: true),
                    Nested6TestModel = table.Column<IEnumerable<Nested6TestModel>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestModels_Nested1TestModel_Nested1TestModelId",
                        column: x => x.Nested1TestModelId,
                        principalTable: "Nested1TestModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestModels_Nested1TestModelId",
                table: "TestModels",
                column: "Nested1TestModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nested2TestModel");

            migrationBuilder.DropTable(
                name: "Nested3TestModel");

            migrationBuilder.DropTable(
                name: "Nested4TestModel");

            migrationBuilder.DropTable(
                name: "Nested5TestModel");

            migrationBuilder.DropTable(
                name: "Nested6TestModel");

            migrationBuilder.DropTable(
                name: "TestModels");

            migrationBuilder.DropTable(
                name: "Nested1TestModel");
        }
    }
}
