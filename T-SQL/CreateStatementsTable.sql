USE Commission
GO
Create table Statements 
(
	Statement_ID int not null primary key,
	Applicant_ID int not null,
	Spicialty_Code nvarchar(50) not null,
	Academic_year int not null,
)