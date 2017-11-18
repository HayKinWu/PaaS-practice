# FROM ubuntu:16.04
FROM ubuntu:16.04
MAINTAINER Allan <allanfann@gmail.com>

# update repositories
RUN apt-get update
RUN apt-get -y upgrade

# 1. Install and configure the necessary dependencies
RUN DEBIAN_FRONTEND=noninteractive apt-get -y install \
 curl openssh-server ca-certificates postfix

# 2. Add the GitLab package server and install the package
RUN curl -sS https://packages.gitlab.com/install/repositories/gitlab/gitlab-ce/script.deb.sh | bash
RUN apt-get install gitlab-ce

# 3. Configure and start GitLab
# we shoud run this line in start.sh
# RUN gitlab-ctl reconfigure

# remove temp file
RUN rm -rf /var/lib/apt/lists/*

WORKDIR /root
