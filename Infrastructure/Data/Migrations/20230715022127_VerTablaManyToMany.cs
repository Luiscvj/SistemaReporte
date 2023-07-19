using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class VerTablaManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailTrainer_Email_EmailId",
                table: "EmailTrainer");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailTrainer_Email_EmailId1",
                table: "EmailTrainer");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailTrainer_Trainer_TrainerId",
                table: "EmailTrainer");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailTrainer_Trainer_TrainerId1",
                table: "EmailTrainer");

            migrationBuilder.DropIndex(
                name: "IX_EmailTrainer_EmailId1",
                table: "EmailTrainer");

            migrationBuilder.DropIndex(
                name: "IX_EmailTrainer_TrainerId1",
                table: "EmailTrainer");

            migrationBuilder.DropColumn(
                name: "EmailId1",
                table: "EmailTrainer");

            migrationBuilder.DropColumn(
                name: "TrainerId1",
                table: "EmailTrainer");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "EmailTrainer",
                newName: "TrainerID");

            migrationBuilder.RenameColumn(
                name: "EmailId",
                table: "EmailTrainer",
                newName: "EmailID");

            migrationBuilder.RenameIndex(
                name: "IX_EmailTrainer_TrainerId",
                table: "EmailTrainer",
                newName: "IX_EmailTrainer_TrainerID");

            migrationBuilder.AlterColumn<string>(
                name: "DireccionEmail",
                table: "EmailTrainer",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailTrainer_Email_EmailID",
                table: "EmailTrainer",
                column: "EmailID",
                principalTable: "Email",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailTrainer_Trainer_TrainerID",
                table: "EmailTrainer",
                column: "TrainerID",
                principalTable: "Trainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailTrainer_Email_EmailID",
                table: "EmailTrainer");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailTrainer_Trainer_TrainerID",
                table: "EmailTrainer");

            migrationBuilder.RenameColumn(
                name: "TrainerID",
                table: "EmailTrainer",
                newName: "TrainerId");

            migrationBuilder.RenameColumn(
                name: "EmailID",
                table: "EmailTrainer",
                newName: "EmailId");

            migrationBuilder.RenameIndex(
                name: "IX_EmailTrainer_TrainerID",
                table: "EmailTrainer",
                newName: "IX_EmailTrainer_TrainerId");

            migrationBuilder.UpdateData(
                table: "EmailTrainer",
                keyColumn: "DireccionEmail",
                keyValue: null,
                column: "DireccionEmail",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "DireccionEmail",
                table: "EmailTrainer",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "EmailId1",
                table: "EmailTrainer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainerId1",
                table: "EmailTrainer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailTrainer_EmailId1",
                table: "EmailTrainer",
                column: "EmailId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTrainer_TrainerId1",
                table: "EmailTrainer",
                column: "TrainerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailTrainer_Email_EmailId",
                table: "EmailTrainer",
                column: "EmailId",
                principalTable: "Email",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailTrainer_Email_EmailId1",
                table: "EmailTrainer",
                column: "EmailId1",
                principalTable: "Email",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailTrainer_Trainer_TrainerId",
                table: "EmailTrainer",
                column: "TrainerId",
                principalTable: "Trainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailTrainer_Trainer_TrainerId1",
                table: "EmailTrainer",
                column: "TrainerId1",
                principalTable: "Trainer",
                principalColumn: "Id");
        }
    }
}
