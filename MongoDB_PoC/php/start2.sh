#/usr/bin/php

code_full_dir=/Users/allan/Documents/02.Projects/poc_project/MongoDB_PoC/php/code
mongodb_server_addr=172.20.10.2
mongodb_server_port=27017

docker run -e "MONGODB_SERVER_IP=$mongodb_server_addr" \
  -e "MONGODB_SERVER_PORT=$mongodb_server_port" \
  -v "$code_full_dir:/root" \
  php_mongo_client:1.0 \
  php sample1.php
