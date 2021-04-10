<#
.SYNOPSIS
    Get details from the registry
.DESCRIPTION
    For code in PowerShellOperations1.cs
.NOTES
    Prerequisite   : Tested with PowerShell V5.1

#>
Get-EventLog -LogName system -EntryType `Error` -Newest 50
