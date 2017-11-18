#!/bin/bash


# declare environment variables

code_full_dir=/Users/allan/Documents/02.Projects/poc_project/Redis_PoC/python/code
redis_server_addr=10.67.44.134
redis_server_port=6379

echo "----- Sample 1 -----"
echo "Path : code/sample1.py"
echo "Desc : Simple Hello World via Cui's Redis Server"
echo "--------------------"
docker run  -e "REDIS_SERVER_ADDRESS=$redis_server_addr" \
  -e "REDIS_SERVER_PORT=$redis_server_port" \
  -v "$code_full_dir:/root" \
  python_redis_client:1.0 \
  python sample1.py
echo "\n\n"


echo "----- Sample 2 -----"
echo "Path : code/sample2.py"
echo "Desc : Pipeline & Numeric Operation"
echo "--------------------"
docker run  -e "REDIS_SERVER_ADDRESS=$redis_server_addr" \
  -e "REDIS_SERVER_PORT=$redis_server_port" \
  -v "$code_full_dir:/root" \
  python_redis_client:1.0 \
  python sample2.py
echo "\n\n"

echo "----- Sample 3 -----"
echo "Path : code/sample3.py"
echo "Desc : Mutiple Set/Get via MSET/MGET"
echo "--------------------"
docker run  -e "REDIS_SERVER_ADDRESS=$redis_server_addr" \
  -e "REDIS_SERVER_PORT=$redis_server_port" \
  -v "$code_full_dir:/root" \
  python_redis_client:1.0 \
  python sample3.py
echo "\n\n"


echo "----- Sample 4 -----"
echo "Path : code/sample3.py"
echo "Desc : List Operation"
echo "--------------------"
docker run  -e "REDIS_SERVER_ADDRESS=$redis_server_addr" \
  -e "REDIS_SERVER_PORT=$redis_server_port" \
  -v "$code_full_dir:/root" \
  python_redis_client:1.0 \
  python sample4.py
echo "\n\n"
