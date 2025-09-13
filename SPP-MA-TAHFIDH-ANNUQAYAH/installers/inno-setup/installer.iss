[Setup]
AppName=SPP MA TAHFIDH ANNUQAYAH
AppVersion=1.0
DefaultDirName={pf}\SPP MA TAHFIDH ANNUQAYAH
DefaultGroupName=SPP MA TAHFIDH ANNUQAYAH
OutputDir=.
OutputBaseFilename=SPP_MA_TAHFIDH_ANNUQAYAH_Installer
Compression=lzma
SolidCompression=yes

[Files]
Source: "src\SPP.App\bin\Release\SPP.App.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "src\SPP.App\bin\Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "src\SPP.App\bin\Release\*.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "src\SPP.App\bin\Release\*.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "src\SPP.App\Resources\*"; DestDir: "{app}\Resources"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "src\SPP.App\Views\*"; DestDir: "{app}\Views"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\SPP MA TAHFIDH ANNUQAYAH"; Filename: "{app}\SPP.App.exe"
Name: "{commondesktop}\SPP MA TAHFIDH ANNUQAYAH"; Filename: "{app}\SPP.App.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\SPP.App.exe"; Description: "{cm:LaunchProgram,SPP MA TAHFIDH ANNUQAYAH}"; Flags: nowait postinstall skipifsilent

[UninstallRun]
Filename: "{app}\uninstall.exe"; Description: "{cm:UninstallProgram,SPP MA TAHFIDH ANNUQAYAH}"; Flags: nowait postinstall skipifsilent