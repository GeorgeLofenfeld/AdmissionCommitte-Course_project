USE master;

IF EXISTS (SELECT * FROM SYS.DATABASES WHERE NAME = 'Commission')
	DROP DATABASE Commission
GO  
CREATE DATABASE Commission
ON   
( NAME = Commission_dat,  
    FILENAME = 'C:\Users\Public\commissiondat.mdf',  
    SIZE = 8,  
    MAXSIZE = 100,  
    FILEGROWTH = 10 )  
LOG ON  
( NAME = Commission_log,  
    FILENAME = 'C:\Users\Public\commissionlog.ldf',  
    SIZE = 5MB,  
    MAXSIZE = 25MB,  
    FILEGROWTH = 5MB );  
