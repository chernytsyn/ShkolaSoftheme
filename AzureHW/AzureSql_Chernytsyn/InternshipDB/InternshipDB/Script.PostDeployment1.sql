/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
insert into dbo.Students
(StudentName)
values
('Vlad Chernytsyn'),
('Katya Dubok'),
('Serhiy Yakhin'),
('Vytaliy Kharchuk'),
('Anna Tytova'),
('Daniil Zhakobin')
go