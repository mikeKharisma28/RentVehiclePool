Here is the steps to run this project. I also include the activity diagram, in this link below. 
https://drive.google.com/file/d/1YOXSjXuBMKIACjx0a48LX1UQV30WHuMZ/view?usp=sharing

1. This project is created using Visual Studio 2022, .NET Core 6 using MVC architecture, SQL Server 2022 Developer edition.
2. It also uses EntityFrameworkCore 7.0.20, because version 8 and above are not supported in .NET Core 6.
3. For database, SQL Server 2016 and above are still supported. I am not really sure though if you are using SQL Server 2016 and below.
4. This project also includes migration files for deploying database and tables, will be explained on the next steps.
5. Open RentVehiclePool.sln using VS version mentioned in (1).
6. Change appsettings.json for ConnectionString if necessary.
7. Then open Package Manager Console
   ![image](https://github.com/user-attachments/assets/cb1767e8-0b59-453e-a643-99ab4556b4ad)
9. Execute command Update-Database to migrate to your database.
10. This project is provided with 2 modules Employee and Positions.
11. Hence, the project is ready to be tested. 
