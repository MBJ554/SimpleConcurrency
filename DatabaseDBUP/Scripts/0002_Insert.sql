USE [simpleConcurrency]
GO

INSERT INTO [dbo].[Customer]
           ([FirstName]
           ,[LastName]
           ,[Phone]
           ,[Email]
           ,[Birthday])
     VALUES
           ('Mikkel'
           ,'Jensen'
           ,'58585959'
           ,'dummyemail@gmail.com'
           ,'1995-09-23')
GO