::JAVA_HOME, path to allure bin file and to nunit3-console.exe should be added to environment variables
cd %~dp0
nunit3-console.exe FinalTask\FinalTask\bin\Debug\FinalTask.dll
allure serve C:\allure\reports