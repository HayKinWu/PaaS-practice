# FROM ubuntu:16.04
FROM ubuntu:16.04
MAINTAINER Allan <allanfann@gmail.com>

# update repositories
RUN apt-get update
RUN apt-get -y upgrade

# install apache and php
RUN DEBIAN_FRONTEND=noninteractive apt-get -y install \
 php composer php-mongodb

# install mon

#RUN pecl install mongodb
#RUN echo "extension=mongodb.so" >> `php --ini | grep "Loaded Configuration" | sed -e "s|.*:\s*||"`

# remove temp file
RUN rm -rf /var/lib/apt/lists/*

WORKDIR /root

#ADD composer.json /root
#RUN composer install
