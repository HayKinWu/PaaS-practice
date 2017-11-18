import redis
import time
import os

redis_ip = os.environ.get("REDIS_SERVER_ADDRESS","127.0.0.1")
redis_port = os.environ.get("REDIS_SERVER_PORT",6379)

r = redis.StrictRedis(host= redis_ip, port=redis_port)

# simple set,increase
pipe = r.pipeline()
pipe.set('Number',123).incr('Number',123).execute()
print "Number = %s" % r.get('Number')
