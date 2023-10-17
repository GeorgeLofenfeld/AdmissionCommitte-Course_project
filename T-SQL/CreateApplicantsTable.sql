USE Commission
GO 
Create table Applicants
(
	Applicant_ID int not null PRIMARY KEY,
	LastName nvarchar(50) not null,
	FirstName nvarchar(50) not null,
	MiddleName nvarchar(50),
	dateOfBirth datetime not null
)