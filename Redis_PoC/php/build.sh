#!/bin/bash

docker rmi php_redis_client:1.0
docker build --tag php_redis_client:1.0 docker/php_redis_client
