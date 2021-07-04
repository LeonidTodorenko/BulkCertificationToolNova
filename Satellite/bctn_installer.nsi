!define PRODUCT_NAME "Bulk Certification Tool Nova"

!include MUI2.nsh

; MUI Settings
!define MUI_ABORTWARNING
!define MUI_ICON "${NSISDIR}\Contrib\Graphics\Icons\modern-install.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\modern-uninstall.ico"

;Registry keys
!define PRODUCT_DIR_REGKEY "Software\BulkCertificationToolNova"
!define REG_SHELL_BULKCERTIFICATIONTOOL_PATH "*\shell\BulkCertificationToolNova"
!define REG_SHELL_BULKCERTIFICATIONTOOL_COMMAND_PATH "*\shell\BulkCertificationToolNova\command"

;--------------------------------
;General

Name "${PRODUCT_NAME}"
OutFile "BulkCertificationToolNovaSetup.exe"
RequestExecutionLevel admin
InstallDir "$PROGRAMFILES\Bulk Certification Tool Nova"
InstallDirRegKey HKLM "${PRODUCT_DIR_REGKEY}" "Install_Dir"
ShowInstDetails show
ShowUnInstDetails show

;--------------------------------
;Pages

!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH

; Uninstaller pages
!insertmacro MUI_UNPAGE_WELCOME
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH

; Language files
!insertmacro MUI_LANGUAGE "English"

; MUI end ------

Function .onInit
  !insertmacro MUI_LANGDLL_DISPLAY
FunctionEnd

;--------------------------------

Section "Bulk Certification Tool Nova" MainSec
  SectionIn RO
  SetOutPath "$INSTDIR"
  SetOverwrite ifnewer
  File "..\BulkCertificationToolNova\bin\Release\Spire.Pdf.dll"
  File "..\BulkCertificationToolNova\bin\Release\Spire.License.dll"
  File "..\BulkCertificationToolNova\bin\Release\Spire.Doc.dll"
  File "..\BulkCertificationToolNova\bin\Release\ClosedXML.dll"
  File "..\BulkCertificationToolNova\bin\Release\DocumentFormat.OpenXml.dll"
  File "..\BulkCertificationToolNova\bin\Release\DocX.dll"
  File "..\BulkCertificationToolNova\bin\Release\BulkCertificationToolNova.exe"
  File "..\BulkCertificationToolNova\bin\Release\BulkCertificationToolNova.exe.config"

  ; Write the installation path into the registry
  WriteRegStr HKLM "${PRODUCT_DIR_REGKEY}" "Install_Dir" "$INSTDIR"

  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BulkCertificationToolNova" "DisplayName" "Bulk Certification Tool Nova"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BulkCertificationToolNova" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BulkCertificationToolNova" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BulkCertificationToolNova" "NoRepair" 1
  ;Enlarge more than 15 file are selected
  WriteRegDWORD HKCU "Software\Microsoft\Windows\CurrentVersion\Explorer" "MultipleInvokePromptMinimum" 0x000000FF
  ;Create uninstaller
  WriteUninstaller "$INSTDIR\Uninstall.exe"
  
  WriteRegStr HKCR "${REG_SHELL_BULKCERTIFICATIONTOOL_PATH}" "MUIVerb" "Bulk Certification Tool Nova"
  WriteRegStr HKCR "${REG_SHELL_BULKCERTIFICATIONTOOL_COMMAND_PATH}" "" '"$INSTDIR\BulkCertificationToolNova.exe" "%1"'
SectionEnd

;--------------------------------
;Descriptions

  ;Language strings
  LangString DESC_MainSec ${LANG_ENGLISH} "Bulk Certification Tool Nova"

  ;Assign language strings to sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${MainSec} $(DESC_MainSec)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

Section Uninstall
  Delete "$INSTDIR\Spire.Pdf.dll"
  Delete "$INSTDIR\Spire.License.dll"
  Delete "$INSTDIR\Spire.Doc.dll"
  Delete "$INSTDIR\BulkCertificationToolNova.exe"
  Delete "$INSTDIR\BulkCertificationToolNova.exe.config"
  Delete "$INSTDIR\DocX.dll"
  Delete "$INSTDIR\DocumentFormat.OpenXml.dll"
  Delete "$INSTDIR\ClosedXML.dll"
  
  Delete "$INSTDIR\Uninstall.exe"

  RMDir "$INSTDIR"
  
  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\BulkCertificationToolNova"
  DeleteRegKey HKLM "SOFTWARE\BulkCertificationToolNova"
  DeleteRegKey HKCR "${REG_SHELL_BULKCERTIFICATIONTOOL_PATH}"
  DeleteRegKey HKCR "${REG_SHELL_BULKCERTIFICATIONTOOL_COMMAND_PATH}"
SectionEnd