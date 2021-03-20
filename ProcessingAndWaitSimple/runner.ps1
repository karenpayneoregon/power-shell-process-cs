<#
.SYNOPSIS
    Get details from the registry
.DESCRIPTION
    For code in PowerShellOperations1.cs
.NOTES
    Prerequisite   : Tested with PowerShell V5.1

#>
reg export Hkey_local_Machine\Software\Microsoft\ASP.NET C:\OED\Dotnetland\VS2019\PowerShellSolution\ProcessingAndWaitSimple\bin\Debug\net5.0-windows\regFile.txt
