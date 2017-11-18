#### 1. 安装GitLab的需求編輯此區塊

#### 1.1 操作系统

#### 1.1.1 受支持的Unix衍生版

* Ubuntu
* Debian
* CentOS
* Red Hat Enterprise Linux (使用CentOS的包和命令)
* Scientific Linux (使用CentOS的包和命令)
* Oracle Linux (使用CentOS的包和命令) *

#### 1.1.2 不受支持的Unix衍生版

* Arch Linux
* Fedora
* FreeBSD
* Gentoo
* macOS

上面这些不受支持的Unix衍生版也可以自己手动编译安装GitLab。 请查阅 源码安装手册 和 GitLab安装手册。

#### 1.1.3 非Unix操作系统(Windows)

GitLab是专为Unix操作系统开发的。 GitLab 不可 运行在Windows操作系统上，而且我们近期也没有考虑支持Windows。 你可以在Linux虚拟机上或者Docker上来安装GitLab。

#### 1.2 硬件需求

#### 1.2.1 存储

存储空间的大小主要取决于你将存储的Git仓库的大小。但根据 rule of thumb(经验法则) 你应该考虑多留一些空间用来存储Git仓库的备份。

如果你想使用弹性的存储空间，你可以考虑在分配分区的时候使用LVM架构，这样可以在后期需要的清空下添加硬盘在增加存储空间。

除此之外你还可以挂在一个支持NFS的分卷，比如NAS、 SAN、AWS、EBS。

如果你的服务器有足够大的内存和CPU处理性能，GitLab的响应速度主要受限于硬盘的寻道时间。 使用更快的硬盘(7200转)或者SSD硬盘会很大程度的提升GitLab的响应速度。

#### 1.2.2 CPU

* 1 核心CPU最多支持100个用户，所有的workers和后台任务都在同一个核心工作这将导致GitLab服务响应会有点缓慢。
* 2 核心 支持500用户，这也是官方推荐的最低标准。
* 4 核心支持2,000用户。
* 8 核心支持5,000用户。
* 16 核心支持10,000用户。
* 32 核心支持20,000用户。
* 64 核心支持40,000用户。

如果想支持更多用户，可以使用 集群式架构

#### 1.2.3 Memory

安装使用GitLab需要至少4GB可用内存(RAM + Swap)! 由于操作系统和其他正在运行的应用也会使用内存, 所以安装GitLab前一定要注意当前服务器至少有4GB的可用内存. 少于4GB内存会导致在reconfigure的时候出现各种诡异的问题, 而且在使用过程中也经常会出现500错误.

* 1GB 物理内存 + 3GB 交换分区 是最低的要求，但我们 强烈反对 使用这样的配置。 查看下面unicorn worker章节获取更多建议。
* 2GB 物理内存 + 2GB 交换分区 支持100用户，但服务响应会很慢。
* 4GB 物理内存 支持100用户，也是 官方推荐 的配置。
* 8GB 物理内存 支持 1,000 用户。
* 16GB 物理内存 支持 2,000 用户。
* 32GB 物理内存 支持 4,000 用户。
* 64GB 物理内存 支持 8,000 用户。
* 128GB 物理内存 支持 16,000 用户。
* 256GB 物理内存 支持 32,000 用户。

如果想支持更多用户，可以使用 集群式架构
即使你服务器有足够多的RAM， 也要给服务器至少分配2GB的交换分区。 因为使用交换分区可以在你的可用内存波动的时候降低GitLab出错的几率。

注意: Sidekiq的25个workers在查看进程(top或者htop)的时候会发现它会单独显示每个worker，但是它们是共享内存分配的，这是因为Sidekiq是一个多线程的程序。 详细内容查看下面关于Unicorn workers 的介绍。

#### 2. Gitlab 安装

Server 操作系统是 Ubuntu16.04

更新 Ubuntu 源

    sudo apt-get update

#### 2.1 安装配置依赖项

首先通过下面命令开放系统防火墙里面的 HTTP 和 SSH 端口，为通过 Http 访问 Gitlab 做准备。 如果想使用 Postfix 来发送邮件,在安装期间请选择'Internet Site'.

您也可以用 sendmail 或者 配置SMTP服务 并 使用SMTP发送邮件

**這裡選擇 第一項： No configuration: 當前配製不變**

    sudo apt-get install curl openssh-server ca-certificates postfix

#### 2.2 添加GitLab仓库,并安装到服务器上

由于访问公网源的权限问题，下面通过离线包的方式安装， 手动下载相应版本的安装包

    //先将包下载到本地，未登录 Ubuntu Server 的情况下，现从本地 copy 到 Gitlab Server 的 apadmin 帐号home目录下
    scp gitlab-ce_9.2.2-ce.0_amd64.deb apadmin@10.67.44.135:~

    //登录 ubuntu apadmin账号，找到安装包并将其 Copy 到 Root 目录下
    scp apadmin@10.67.44.135:/home/apadmin/gitlab-ce_9.2.2-ce.0_amd64.deb  /root/   
    //切换到 Root 下安装
    dpkg -i gitlab-ce_9.2.2-ce.0_amd64.deb   

#### 2.3 启动GitLab

    sudo gitlab-ctl reconfigure

#### 3. 配置GitLab

配置域名（很重要），否则项目git clone的地址时错的

    vim  /etc/gitlab/gitlab.rb
    编辑：external_url '你的公网网址'
    例如：external_url 'http:gitlab.it.foxconn'

    //gitlab 配製信息：port , backup folder...
    $cat /opt/gitlab/embedded/service/gitlab-rails/config/gitlab.yml

    //DB link config
    $cat /var/opt/gitlab/gitlab-rails/etc/database.yml                 
    # 注意一般直接改/etc/gitlab/gitlab.rb,
    # 后使用 sudo gitlab-ctl reconfigure 后覆盖 gitlab.yml & database.yml 文件

    # git 倉庫目錄
    $cd /var/opt/gitlab/git-data/repositories

    vi postgresql/data/postgresql.conf

    # 修改监听地址为ip
    listen_addresses = '10.67.37.21'

    编辑完成后，重启Gitlab，使配置生效
    sudo gitlab-ctl reconfigure

    ps aux |grep gitlab
    73 ps aux |grep ngnix
    74 ps -ef|grep nginx

    sudo service nginx stop
    sudo service nginx start
    sudo service nginx restart
    sudo service nginx reload

常用命令

    //Start all GitLab components
    sudo gitlab-ctl start

    //Stop all GitLab components
    sudo gitlab-ctl stop

    //Restart all GitLab components
    sudo gitlab-ctl restart

    sudo gitlab-ctl status //查看状态
    sudo gitlab-ctl stop
    sudo gitlab-ctl start
    sudo gitlab-ctl restart
    sudo gitlab-ctl reconfigure          //重启 gitlab 使配置生效
    sudo gitlab-ctl restart postgresql   //重启PostgreSQL使配置生效

    sudo netstat -plnt | grep :80

參考： [Gitlab PostgreSQL 使用](http://www.cnblogs.com/sfnz/p/7131287.html?utm_source=itdadao&utm_medium=referral)
