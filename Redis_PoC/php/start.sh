#!/bin/bash

export REDIS_SERVER_ADDRESS=10.67.44.134
export REDIS_SERVER_PORT=6379

echo "----- Sample 1 -----"
echo "Path : code/sample1.py"
echo "Desc : Simple Hello World via Cui's Redis Server"
echo "--------------------"
php code/sample1.php

echo "----- Sample 2 -----"
echo "Path : code/sample2.py"
echo "Desc : Pipeline & Numeric Operation"
echo "--------------------"
php code/sample2.php

echo "----- Sample 3 -----"
echo "Path : code/sample3.py"
echo "Desc : Mutiple Set/Get via MSET/MGET"
echo "--------------------"
php code/sample3.php

echo "----- Sample 4 -----"
echo "Path : code/sample4.py"
echo "Desc : List Operation"
echo "--------------------"
php code/sample4.php
