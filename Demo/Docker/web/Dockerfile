FROM microsoft/nanoserver

# Copy files
RUN md c:\build
WORKDIR c:/build
COPY . c:/build

RUN md c:\wwwroot
COPY ./wwwroot c:/wwwroot

ENTRYPOINT node c:/wwwroot/index.js 
