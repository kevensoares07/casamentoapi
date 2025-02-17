﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMatheus.Migrations
{
    /// <inheritdoc />
    public partial class EuamoaMariahehe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pessoa",
                table: "PresentesSelecionados",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pessoa",
                table: "PresentesSelecionados");
        }
    }
}
