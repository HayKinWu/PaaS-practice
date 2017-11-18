#/bin/bash

docker run --detach \
    --hostname gitlab.example.com \
    --publish 443:443 --publish 80:80 --publish 22:22 \
    --restart always \
    my_gitlab:1.0
