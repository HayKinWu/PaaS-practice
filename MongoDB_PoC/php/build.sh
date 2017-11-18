#!/bin/bash

docker rmi php_mongo_client:1.0
docker build --tag php_mongo_client:1.0 docker/php_mongo_client
