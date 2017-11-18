# Installation

### 0. 前置條件

1. Windows Server 2016

### 1. 系統更新

首先將系統更新到最新
1. 點選 [Start] => [Settings]
2. 點選 [Update & Security]
3. 點選 [Windows Update] => [Check Updates] 檢查更新
4. 進行更新

### 2. 安裝 套件管理器 及 Docker

開啟 Power Shell 輸入以下指令，進行套件的安裝

```shell
# 安裝 Nuget 套件管理器
Install-PackageProvider -Name NuGet -MinimumVersion 2.8.5.201 -Force

# 安裝 Docker
Install-Module -Name DockerMsftProvider -Force
Install-Package -Name docker -ProviderName DockerMsftProvider -Force

# 重啟電腦
Restart-Computer -Force
```

### 3. 系統設置

接下來針對防火牆進行設置，並讓 docker daemon 同時監聽 pipe 跟 TCP

```shell
# 進行 docker 所需要的 防火牆設置
netsh advfirewall firewall add rule name="docker engine" dir=in action=allow protocol=TCP localport=2375

# 重新配置 docker daemon，讓 docker 同時監聽 pipe and TCP
Stop-Service docker
dockerd --unregister-service
dockerd -H npipe:// -H 0.0.0.0:2375 --register-service
Start-Service docker
```

### 4. 檢查 Docker 安裝狀態

檢查 Docker 安裝狀態

```shell
docker version
```

若順利安裝完成，應該可以看到以下資訊

```shell
Client:
Version:      17.06.1-ee-2
API version:  1.30
Go version:   go1.8.3
Git commit:   8e43158
Built:        Wed Aug 23 21:16:53 2017
OS/Arch:      windows/amd64

Server:
Version:      17.06.1-ee-2
API version:  1.30 (minimum version 1.24)
Go version:   go1.8.3
Git commit:   8e43158
Built:        Wed Aug 23 21:25:53 2017
OS/Arch:      windows/amd64
Experimental: false
```

### 5. 執行 Windows Container

首先下載 windows 的 docker image

```shell
docker pull microsoft/windowsservercore
```

順利啟動下載後，可以看到以下的畫面

```shell
Using default tag: latest
latest: Pulling from microsoft/windowsservercore
3889bb8d808b: Downloading [===========>                                       ]  960.4MB/4.07GB
8df8e568af76: Downloading [======================================>            ]  988.9MB/1.281GB
```

接著嘗試啟動 Windows Container

```shell
docker run microsoft/windowsservercore ipconfig /all
```


### 6. 利用 Docker 建立 IIS 服務器

微軟已經在 GitHub 上提供了建立 IIS 服務器的[範例](https://github.com/allanfann/iis-docker.git)．協助使用者簡化部署的步驟，
[ServiceMonitor.exe](https://github.com/Microsoft/IIS.ServiceMonitor) 則是微軟開發用來將 IIS 在 Windows Container 內啟動的進入點
