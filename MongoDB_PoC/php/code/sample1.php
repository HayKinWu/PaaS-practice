<?php
require 'vendor/autoload.php'; // include Composer's autoloader

$mongo_ip = "127.0.0.1";
$mongo_port = 27017;

# get
if (empty(getenv("MONGODB_SERVER_IP")) == False)
  $mongo_ip = getenv("MONGODB_SERVER_IP");

if (empty(getenv("MONGODB_SERVER_PORT")) == False)
  $mongo_port = getenv("MONGODB_SERVER_PORT");

echo "MongoDB Server IP=" . $mongo_ip . "\n";
echo "MongoDB Server Port=" . $mongo_port . "\n";
$cxn_str = sprintf("mongodb://%s:%d",$mongo_ip,$mongo_port);

echo "Connection String=" . $cxn_str . "\n";

$client = new MongoDB\Client($cxn_str);

$db = $client->test;
$collection = $db->my_collection;

print "DB Name =" . $db->name . "\n";
# remove all element in collection (drop all data)
# delete
$collection->drop();

# create
$collection->insertOne( array("w" => 10) );
$collection->insertOne( array("w" => 20) );
$collection->insertOne( array("w" => 30) );
$collection->insertOne( array("w" => 123) );
$collection->insertOne( array("y" => 456) );

# retrieve
echo "----- current status -----\n";
$items = $collection->find();
foreach ( $items as $item ){
  echo json_encode($item);
  echo "\n";
}

echo "----- current status end -----\n";

#update
echo "Update item {'w': 10} => email:123@hotmail, Pwd:123\n";
$collection->updateOne(array("w"=>10), array( '$set' => array("Email"=>"123@hotmail.com","Pwd"=>"123")));

#remove item
echo "Remove item {'y': 456}\n";
$collection->deleteOne(array("y"=>456));

echo "----- Result -----\n";
$items = $collection->find();
foreach ( $items as $item ) {
  echo json_encode($item);
  echo "\n";
}
?>
