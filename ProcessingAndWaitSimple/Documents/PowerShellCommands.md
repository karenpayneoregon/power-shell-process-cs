# Hogpog of extras

Extra commands to check out along with various links to documentation

# Online docs

- [Invoke-RestMethod](https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.utility/invoke-restmethod?view=powershell-7.1)
- [Microsoft.PowerShell.Management](https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.management/?view=powershell-7.1) 
- [Several ways to get current logged in user in Powershell](https://www.optimizationcore.com/scripting/ways-get-current-logged-user-powershell/) 

-----------------------------------------------------
Variations on what has been presented in code
-----------------------------------------------------

https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.utility/export-csv?view=powershell-7.1

https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.management/get-eventlog?view=powershell-5.1#examples

---

**Some of these are not presented in the article** 

Those with dates on log entries, change them to current dates as event logs can have a good deal of information for a day.

- Get-EventLog  -LogName "application" -After 3/10/2011 -Before 3/11/2012 -EntryType "Error" -Source "*SQL*" |select -last 100
- Get-EventLog -LogName application -After $StartDay | Select-Object Timegenerated, EntryType, Source, Message
- (Get-EventLog -LogName application -After $StartDay )[0] | fl * #format-list
- Get-EventLog -LogName application -After 3/03/2021 | Select-Object Timegenerated, EntryType, Source, Message | Export-Csv   -Path Events.csv
- Get-EventLog -Logname Application -entrytype Information | select -First 1 TimeGenerated | gm
- Get-EventLog -LogName application -After 3/03/2021 | Select-Object -First 1 Timegenerated, EntryType, Source, Message | ConvertTo-Json
- Get-EventLog -LogName application -After 3/03/2021 | Select-Object -First 1 [datetime]Timegenerated, EntryType, Source, Message | ConvertTo-Json
- the following command will permit you to retreive the last 50 errors in System EventLog of the machine
- Get-EventLog -LogName system -EntryType `Error` -Newest 50
- Free space on a drive `(gdr c).Free/1gb`
- How long a PowerShell session has been running
- OED Model wmic csproduct get name
- Get local accountsGet-WmiObject -Class Win32_UserAccount -Filter "LocalAccount='True'"
- Get last boot time Get-CimInstance -ClassName win32_operatingsystem | select  lastbootuptime
- Get current IP configuration Get-NetIPConfiguration
- Get-NetAdapter
- Is 64bit [Environment]::Is64BitProcess


[10 Examples to Check Event Log](https://www.nextofwindows.com/10-examples-to-check-event-log-on-local-and-remote-computer-using-powershell) on Local and Remote Computer Using PowerShell


**With Select-Object**

- Get-ChildItem "Cert:\LocalMachine\My" | Select-Object Name,Thumbprint,@{Name="Template";Expression={Get-CertificateTemplate $_}}

Creates a graphic tree, this can take a while for a large directory done recursively.

- Tree $Path /F | Select-Object -Skip 2  
- Tree $Path /F | Select-Object -Skip 1 >test.txt
- Tree C:\OED\Dotnetland\VS2019\PowerShellSolution /F | Select-Object -Skip 2 >test.txt

- Get-ChildItem C:\OED\Dotnetland\VS2019\PowerShellSolution -recurse  | ConvertTo-csv  >test.csv
- Get-ChildItem C:\OED\Dotnetland\VS2019\PowerShellSolution -recurse -Depth 2 -Attributes !Directory,!Directory+Hidden -Name | ConvertTo-csv  >test.csv
- Get-NetIPAddress **-AddressFamily IPv4** | where-object IPAddress -notmatch "^(169)|(127)" | Sort-Object IPAddress | select IPaddress,Interface* | ConvertTo-Json

**User details**
- Get-LocalGroupMember -Group "Administrators" | ConvertTo-Json


- Get-ComputerInfo -Property "os*"
- Get-Clipboard

https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.management/add-content?view=powershell-7.1

- Get-Content -Path .\data.txt
- Get-WmiObject -Class Win32_BIOS
- Computer name (Get-Item -Path Env:computername).Value
- Computer os  (Get-Item -Path Env:os).Value