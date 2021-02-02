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
           ,'23404540'
           ,'Mikkelbrgger@gmail.com'
           ,'1997-09-21')
GO