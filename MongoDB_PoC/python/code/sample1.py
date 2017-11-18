#encoding:utf=8

import pymongo
import os

mongo_ip = os.environ.get("MONGODB_SERVER_IP","127.0.0.1")
mongo_port = os.environ.get("MONGODB_SERVER_PORT",27017)

cxn = pymongo.MongoClient(mongo_ip, int(mongo_port))

#
db = cxn.test
print "MongoDB Server IP=" + mongo_ip
print "MongoDB Server Port=" + str(mongo_port)
print "DB Name =" + db.name

#remove all data in database first
# delete
db.my_collection.remove()

# create
db.my_collection.save({"w": 10})
db.my_collection.save({"w": 20})
db.my_collection.save({"w": 30})
db.my_collection.save({"x": 123})
db.my_collection.save({"y": 456})

# retrieve
print "----- current status -----"
for item in db.my_collection.find():
    print item

print "----- current status end -----"
# update
print "Update item {'w': 10} => email:123@hotmail, Pwd:123"
db.my_collection.update({"w": 10},{"$set":{"Email":"123@hotmail","Pwd":"123"}})

# remove item
print "Remove item {'y': 456}"
db.my_collection.remove({"y": 456})

print "----- Result -----"
for item in db.my_collection.find():
    print item

# create index & sort
#db.my_collection.create_index("x")
#for item in db.my_collection.find().sort("x", pymongo.ASCENDING):
#    print item["x"]


cxn.close()
