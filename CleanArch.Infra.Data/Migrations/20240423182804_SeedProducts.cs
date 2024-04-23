using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId) " +
                   "VALUES ('Caderno', 'Caderno espiral 100 folhas', 7.45, 50, 'caderno.jpg', 1)");
            mb.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId) " +
                   "VALUES ('Borracha', 'Borracha branca pequena', 2.45, 100, 'borracha.jpg', 1)");
            mb.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId) " +
                   "VALUES ('Calculadora Escolar', 'Calculadora simples', 15.39, 20, 'calculadora.jpg', 2)");
            mb.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId) " +
                   "VALUES ('Caneta', 'Caneta azul', 1.45, 200, 'caneta.jpg', 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products WHERE Name IN ('Caderno', 'Borracha', 'Calculadora Escolar', 'Caneta')");
        }
    }
}
