#!/usr/lib/python

export REDIS_SERVER_ADDRESS=10.67.44.134
export REDIS_SERVER_PORT=6379

echo "----- Sample 1 -----"
echo "Path : code/sample1.py"
echo "Desc : Simple Hello World via Cui's Redis Server"
echo "--------------------"
python code/sample1.py
echo "\n\n"


echo "----- Sample 2 -----"
echo "Path : code/sample2.py"
echo "Desc : Pipeline & Numeric Operation"
echo "--------------------"
python code/sample2.py
echo "\n\n"

echo "----- Sample 3 -----"
echo "Path : code/sample3.py"
echo "Desc : Mutiple Set/Get via MSET/MGET"
echo "--------------------"
python code/sample3.py
echo "\n\n"


echo "----- Sample 4 -----"
echo "Path : code/sample3.py"
echo "Desc : List Operation"
echo "--------------------"
python code/sample4.py
echo "\n\n"
