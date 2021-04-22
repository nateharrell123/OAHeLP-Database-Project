Param(
   [string] $Server = "(LocalDB)\MSSQLLocalDb",
   #[string] $Database = "OAHELP"  
 [string] $Database = "C:\USERS\RSHALE\SOURCE\REPOS\OAHELP-DATABASE-PROJECT\OAHELP DATABASE PROJECT\DATABASE1.MDF"
)

# This script requires the SQL Server module for PowerShell.
# The below commands may be required.

# To check whether the module is installed.
# Get-Module -ListAvailable -Name SqlServer;

# Install the SQL Server Module
# Install-Module -Name SqlServer -Scope CurrentUser

$CurrentDrive = (Get-Location).Drive.Name + ":"

Write-Host ""
Write-Host "Rebuilding database $Database on $Server..."

<#
   If on your local machine, you can drop and re-create the database.
#>
<#
& ".\Scripts\DropDatabase.ps1" -Database $Database
& ".\Scripts\CreateDatabase.ps1" -Database $Database
#>
<#
   If on the department's server, you don't have permissions to drop or create databases.
   In this case, maintain a script to drop all tables.
#>
#Write-Host "Dropping tables..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DropTables.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DropProcedures.sql"

Write-Host "Creating schema..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DropCreateSchemas.sql"

Write-Host "Creating tables..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "CreateTables.sql"


Write-Host "Stored procedures..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "GetSubject.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "GetNames.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "GetOASubject.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "GetSubjectList.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "GetMedicalHistory.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "GetICSubject.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "DeleteSubject.sql"


Write-Host "Inserting data..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "InsertSubjectData.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "InsertNamesData.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "InsertClinicData.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "InsertVillageData.sql"

Write-Host "Rebuild completed."
Write-Host ""

Set-Location $CurrentDrive
