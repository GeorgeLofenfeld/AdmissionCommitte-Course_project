USE Commission 
GO
CREATE TABLE Specialties
(
	Specialty_Code nvarchar(50) not null primary key,
	Budget_places int not null,
	Extra_budgetary_places int not null
)