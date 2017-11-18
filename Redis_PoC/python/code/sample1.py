import redis
import time
import os

redis_ip = os.environ.get("REDIS_SERVER_ADDRESS","127.0.0.1")
redis_port = os.environ.get("REDIS_SERVER_PORT",6379)

r = redis.StrictRedis(host= redis_ip, port=redis_port)

r.set('Hello','World',3)
print "Check key 'Hello' exist : " + str(r.exists('Hello'))
print "First time to get('Hello')=" + r.get('Hello')

time.sleep(3)

# Data in redis will be aging
print "Check key 'Hello' exist : " + str(r.exists('Hello'))
print "After 3 seconds to get('Hello')=" + str(r.get('Hello'))
