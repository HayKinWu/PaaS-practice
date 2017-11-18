#!/bin/bash

docker rmi python_redis_client:1.0
docker build --tag python_redis_client:1.0 docker/python_redis_client
