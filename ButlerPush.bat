@echo off

REM Butler Push
REM Add to post build event of project to automatically zip and push the build to itch.io
REM Needs a 7z.exe at the root of the repo
REM Also requires the itch.io Butler to be added to PATH
REM Events: post build event -> check master branch -> zip release folder -> push to itch


goto comment
rem Add this to the post-build event of your project

@echo off

set account=account-name
set project=project-name
set channel=channel-name

set configuration=$(ConfigurationName)
set solutionDir=$(SolutionDir)
set targetDir=$(TargetDir)

call %solutionDir%ButlerPush.bat %account% %project% %channel% %configuration% %solutionDir% %targetDir%

:comment


set account=%1
set project=%2
set channel=%3

set configuration=%4
set solutionDir=%5
set targetDir=%6

echo account: %account%
echo project: %project%
echo channel: %channel%

echo config: %configuration%
echo solution: %solutionDir%
echo target: %targetDir%

butler.exe status %account%/%project%

git branch --show-current | find /v "" | findstr /r /c:"^master$" > nul & if errorlevel 1 (
    echo "not on master"
) else (
    echo "on master"
    if %configuration% == Release (
        echo "pushing"
        %solutionDir%7z.exe a %targetDir%..\%project%.zip %targetDir%*
        butler.exe push %targetDir%..\%project%.zip %account%/%project%:%channel%
    )
)

butler.exe status %account%/%project%

pause