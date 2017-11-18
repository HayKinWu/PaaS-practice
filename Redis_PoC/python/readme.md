## Python x Redis Practice

1. Brief
----

* Python Redis Sample Code - 測試 Python 如何介接 Redis 資料庫
* Redis Test Connection - 測試建剛所提供的 Redis 是否可以對外提供連接


2. Environment
----

* Ubuntu 14.04


3. Install Python & Redis Driver
----
    sudo apt-get update
    sudo apt-get install python-dev pip
    sudo pip install redis

4. Samples
----

  1. Sample 1

      * Brief

          Simple Hello World via Cui's Redis Server

      * Source Code

            #!/bin/python

            import redis
            import time

            r = redis.StrictRedis(host='10.67.44.134',port=6379)

            r.set('Hello','World',3)
            print "Check key 'Hello' exist : " + str(r.exists('Hello'))
            print "First time to get('Hello')=" + r.get('Hello')

            time.sleep(3)

            # Data in redis will be aging
            print "Check key 'Hello' exist : " + str(r.exists('Hello'))
            print "After 3 seconds to get('Hello')=" + str(r.get('Hello'))

      * Result
            Check key 'Hello' exist : True
            First time to get('Hello')=World
            Check key 'Hello' exist : False
            After 3 seconds to get('Hello')=None

  2. Sample 2

      * Brief

          Set value with pipeline

      * Source Code

            import redis

            r = redis.StrictRedis(host='10.67.44.134',port=6379)

            # simple set,increase
            pipe = r.pipeline()
            pipe.set('Number',123).incr('Number',123).execute()
            print "Number = %s" % r.get('Number')

      * Result

            Number = 246

  3. Sample 3

      * Brief

          Mutiple Set/Get via MSET/MGET

      * Source Code

            import redis

            r = redis.StrictRedis(host='10.67.44.134',port=6379)

            pipe = r.pipeline()
            my_list = { "key1":"value1", "foo":"bar", "Num":123 }
            r.mset(my_list)

            print r.mget('key1','foo',"Num")

      * Result

            ['value1', 'bar', '123']

  4. Sample 4

      * Brief

          List Operation

      * Source Code

            import redis

            r = redis.StrictRedis(host='10.67.44.134',port=6379)

            # remove all element in list
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

      * Result

            my_list status
            ['CCC', 'BBB', 'AAA', 'XXX', 'YYY', 'ZZZ']
            pop left = CCC
            ['BBB', 'AAA', 'XXX', 'YYY', 'ZZZ']
