#!/bin/bash

code_full_dir=/Users/allan/Documents/02.Projects/poc_project/Redis_PoC/php/code
redis_server_addr=10.67.44.134
redis_server_port=6379

echo "----- Sample 1 -----"
echo "Path : code/sample1.php"
echo "Desc : Simple Hello World via Cui's Redis Server"
echo "--------------------"
docker run  -e "REDIS_SERVER_ADDRESS=$redis_server_addr" \
  -e "REDIS_SERVER_PORT=$redis_server_port" \
  -v "$code_full_dir:/root" \
  php_redis_client:1.0 \
  php sample1.php

echo "----- Sample 2 -----"
echo "Path : code/sample2.php"
echo "Desc : Pipeline & Numeric Operation"
echo "--------------------"
docker run  -e "REDIS_SERVER_ADDRESS=$redis_server_addr" \
  -e "REDIS_SERVER_PORT=$redis_server_port" \
  -v "$code_full_dir:/root" \
  php_redis_client:1.0 \
  php sample2.php

echo "----- Sample 3 -----"
echo "Path : code/sample3.php"
echo "Desc : Mutiple Set/Get via MSET/MGET"
echo "--------------------"
docker run  -e "REDIS_SERVER_ADDRESS=$redis_server_addr" \
  -e "REDIS_SERVER_PORT=$redis_server_port" \
  -v "$code_full_dir:/root" \
  php_redis_client:1.0 \
  php sample3.php

echo "----- Sample 4 -----"
echo "Path : code/sample4.php"
echo "Desc : List Operation"
echo "--------------------"
docker run  -e "REDIS_SERVER_ADDRESS=$redis_server_addr" \
  -e "REDIS_SERVER_PORT=$redis_server_port" \
  -v "$code_full_dir:/root" \
  php_redis_client:1.0 \
  php sample4.php
