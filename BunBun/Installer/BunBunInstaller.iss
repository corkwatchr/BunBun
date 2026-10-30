[Setup]
AppName=BunBun
AppVersion=1.0
AppPublisher=DaBrEl
AppPublisherURL=https://dabrel.com
VersionInfoVersion=1.0.0
VersionInfoCompany=DaBrEl
VersionInfoDescription=BunBun
DefaultDirName={autopf}\BunBun
DefaultGroupName=BunBun
UninstallDisplayIcon={app}\BunBun.exe
OutputDir=Output
OutputBaseFilename=BunBunSetup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Files]
Source: "*"; DestDir: "{app}"; Flags: recursesubdirs


[Icons]
Name: "{group}\BunBun"; Filename: "{app}\BunBun.exe"
Name: "{commondesktop}\BunBun"; Filename: "{app}\BunBun.exe"

[Registry]
Root: HKCU; \
    Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; \
    ValueType: string; \
    ValueName: "BunBun"; \
    ValueData: """{app}\BunBun.exe"""; \
    Flags: uninsdeletevalue

[Run]
Filename: "{app}\BunBun.exe"; Description: "Launch BunBun"; Flags: nowait postinstall skipifsilent