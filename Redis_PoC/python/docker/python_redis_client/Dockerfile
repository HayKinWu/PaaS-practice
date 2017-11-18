# FROM ubuntu:16.04
FROM ubuntu:16.04
MAINTAINER Allan <allanfann@gmail.com>

# update repositories
RUN apt-get update
RUN apt-get -y upgrade

RUN DEBIAN_FRONTEND=noninteractive apt-get -y install \
 python-dev \
 python-pycurl \
 python-pip \
 curl

RUN pip install redis

# remove temp file
RUN rm -rf /var/lib/apt/lists/*

WORKDIR /root
