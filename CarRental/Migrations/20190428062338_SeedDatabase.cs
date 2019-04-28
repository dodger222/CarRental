using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Users (LastName, FirstName, BirthDate, DriveLicenseNumber) VALUES ('Sipakov', 'Maxim', '1998.05.03', '5AI 038540')");
            migrationBuilder.Sql("INSERT INTO Users (LastName, FirstName, BirthDate, DriveLicenseNumber) VALUES ('Mihnovec', 'Evgeny', '1998.08.12', '3NY 872346')");
            migrationBuilder.Sql("INSERT INTO Users (LastName, FirstName, BirthDate, DriveLicenseNumber) VALUES ('Bronovizky', 'Yaroslav', '1998.04.16', '6KE 827322')");

            migrationBuilder.Sql("INSERT INTO Cars (Make, Model, CarClass, YearOfIssue, RegistrationNumber) VALUES ('BMW', '5-series', 'E', 2003, '6734-RT5')");
            migrationBuilder.Sql("INSERT INTO Cars (Make, Model, CarClass, YearOfIssue, RegistrationNumber) VALUES ('Audi', 'A8', 'S', 2007, '8729-MR3')");
            migrationBuilder.Sql("INSERT INTO Cars (Make, Model, CarClass, YearOfIssue, RegistrationNumber) VALUES ('VW', 'Passat', 'E', 2011, '7942-AM7')");

            migrationBuilder.Sql("INSERT INTO Orders (UserId, CarId, StartDate, FinalDate, Comment) VALUES ((SELECT ID FROM Users WHERE DriveLicenseNumber = '5AI 038540'), (SELECT ID FROM Cars WHERE RegistrationNumber = '8729-MR3'), '2019.04.25', '2019.04.27', 'Cool car. I am pleased.')");
            migrationBuilder.Sql("INSERT INTO Orders (UserId, CarId, StartDate, FinalDate, Comment) VALUES ((SELECT ID FROM Users WHERE DriveLicenseNumber = '6KE 827322'), (SELECT ID FROM Cars WHERE RegistrationNumber = '6734-RT5'), '2019.03.17', '2019.03.18', 'Cool car. I am pleased.')");
            migrationBuilder.Sql("INSERT INTO Orders (UserId, CarId, StartDate, FinalDate, Comment) VALUES ((SELECT ID FROM Users WHERE DriveLicenseNumber = '3NY 872346'), (SELECT ID FROM Cars WHERE RegistrationNumber = '7942-AM7'), '2018.12.30', '2019.01.01', 'Cool car. I am pleased.')");
            migrationBuilder.Sql("INSERT INTO Orders (UserId, CarId, StartDate, FinalDate, Comment) VALUES ((SELECT ID FROM Users WHERE DriveLicenseNumber = '6KE 827322'), (SELECT ID FROM Cars WHERE RegistrationNumber = '8729-MR3'), '2019.04.25', '2019.04.27', 'Cool car. I am pleased.')");
            migrationBuilder.Sql("INSERT INTO Orders (UserId, CarId, StartDate, FinalDate, Comment) VALUES ((SELECT ID FROM Users WHERE DriveLicenseNumber = '3NY 872346'), (SELECT ID FROM Cars WHERE RegistrationNumber = '6734-RT5'), '2019.03.17', '2019.03.18', 'Cool car. I am pleased.')");
            migrationBuilder.Sql("INSERT INTO Orders (UserId, CarId, StartDate, FinalDate, Comment) VALUES ((SELECT ID FROM Users WHERE DriveLicenseNumber = '5AI 038540'), (SELECT ID FROM Cars WHERE RegistrationNumber = '7942-AM7'), '2018.12.30', '2019.01.01', 'Cool car. I am pleased.')");
            migrationBuilder.Sql("INSERT INTO Orders (UserId, CarId, StartDate, FinalDate, Comment) VALUES ((SELECT ID FROM Users WHERE DriveLicenseNumber = '3NY 872346'), (SELECT ID FROM Cars WHERE RegistrationNumber = '8729-MR3'), '2019.04.25', '2019.04.27', 'Cool car. I am pleased.')");
            migrationBuilder.Sql("INSERT INTO Orders (UserId, CarId, StartDate, FinalDate, Comment) VALUES ((SELECT ID FROM Users WHERE DriveLicenseNumber = '5AI 038540'), (SELECT ID FROM Cars WHERE RegistrationNumber = '6734-RT5'), '2019.03.17', '2019.03.18', 'Cool car. I am pleased.')");
            migrationBuilder.Sql("INSERT INTO Orders (UserId, CarId, StartDate, FinalDate, Comment) VALUES ((SELECT ID FROM Users WHERE DriveLicenseNumber = '6KE 827322'), (SELECT ID FROM Cars WHERE RegistrationNumber = '7942-AM7'), '2018.12.30', '2019.01.01', 'Cool car. I am pleased.')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Users WHERE DriveLicenseNumber IN ('5AI 038540', '3NY 872346', '6KE 827322')");
            migrationBuilder.Sql("DELETE FROM Cars WHERE RegistrationNumber IN ('6734-RT5', '8729-MR3', '7942-AM7')");
        }
    }
}
