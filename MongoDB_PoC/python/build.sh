#!/bin/bash

docker rmi python_mongo_client:1.0
docker build --tag python_mongo_client:1.0 docker/python_mongo_client
