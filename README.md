Here is the steps to run this project. I also include the activity diagram, here below. 
![image](https://drive.google.com/file/d/1YOXSjXuBMKIACjx0a48LX1UQV30WHuMZ/view?usp=sharing)

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
11. There are 3 roles, Admin, Approver 1 and Approver 2. Before testing, make sure you have registered users with these roles.
12. Role Admin has access to updating vehicle data and input the transaction. After a transaction is submitted, the data will need to be approved by Approver 1 and 2.
13. Role Approver 1 & 2 has access to approving the transaction data. Once approve / reject, the task will not be present in the list anymore.
14. Hence, the project is ready to be tested. 
