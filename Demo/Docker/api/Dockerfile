FROM microsoft/iis

RUN powershell add-windowsfeature web-asp-net45 

RUN powershell remove-item C:\inetpub\wwwroot\iisstart.*

# Copy files
RUN md c:\build
WORKDIR c:/build
COPY . c:/build

RUN xcopy c:\build\wwwroot c:\inetpub\wwwroot /s

ENTRYPOINT powershell 
