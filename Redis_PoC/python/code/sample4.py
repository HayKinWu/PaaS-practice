import redis
import time
import os

redis_ip = os.environ.get("REDIS_SERVER_ADDRESS","127.0.0.1")
redis_port = os.environ.get("REDIS_SERVER_PORT",6379)

r = redis.StrictRedis(host= redis_ip, port=redis_port)

# clear all element in my_list
count = r.llen('my_list')
for i in range(0,count):
    r.lpop('my_list')

r.rpush('my_list',"XXX")
r.rpush('my_list',"YYY")
r.rpush('my_list',"ZZZ")
r.lpush('my_list',"AAA")
r.lpush('my_list',"BBB")
r.lpush('my_list',"CCC")


print 'my_list status'
print r.lrange('my_list',0,-1)
print "pop left = " + r.lpop('my_list')

print r.lrange('my_list',0,-1)
