IF NOT EXISTS
   (
      SELECT *
      FROM sys.schemas s
      WHERE s.[name] = N'Person'
   )
BEGIN
   EXEC(N'CREATE SCHEMA [Person] AUTHORIZATION [dbo]');
END;
