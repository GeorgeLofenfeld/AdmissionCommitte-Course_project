USE Commission 
GO
CREATE TABLE Certificates
(
	Certificate_ID int NOT NULL PRIMARY KEY,
	Applicant_ID int NOT NULL,
	Avarage_Score float NOT NULL,
	Place_of_education nvarchar(50) NOT NULL,
	Level_of_education nvarchar(50) NOT NULL
)