1. This project is created using Visual Studio 2022, .NET Core 6 using MVC architecture, SQL Server 2022 Developer edition.
2. It also uses EntityFrameworkCore 7.0.20, because version 8 and above are not supported in .NET Core 6.
3. For database, SQL Server 2016 and above are still supported. I am not really sure though if you are using SQL Server 2016 and below.
4. This project also includes migration files for deploying database and tables, will be explained on the next steps.
5. Open RentVehiclePool.sln using VS version mentioned in (1).
6. Change appsettings.json for ConnectionString if necessary.
7. Then open Package Manager Console
   ![image](https://github.com/user-attachments/assets/cb1767e8-0b59-453e-a643-99ab4556b4ad)
8. This project has 2 DB contexts. Make sure to execute the commands for deploying data in orderly fashion and configure ConnectionString correctly in your machine.
9. Execute command Update-Database -Context AccountContext, for deploying tables related to Users and Roles.
10. Then execute command Update-Database -Context AppDbContext, for deploying the rest of the tables and initial values for table Roles.
11. The project is ready to be run and tested. 
