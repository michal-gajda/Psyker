# Psyker

```powershell
ssh-keygen.exe -t ecdsa -C "michal@z230"
```

```powershell
git config --global user.name "Michal Gajda"
git config --global user.email "michal@gajda.co.uk"
```

```powershell
git config --global push.autoSetupRemote true
```

```powershell
git config --system core.longpaths true
```

```
Windows Registry Editor Version 5.00

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\FileSystem]
"LongPathsEnabled"=dword:00000001
```

```powershell
git flow feature start feature_name
```
