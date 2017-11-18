<?php
require "vendor/autoload.php";
Predis\Autoloader::register();

$redis_ip = "127.0.0.1";
if (getenv("REDIS_SERVER_ADDRESS"))
  $redis_ip = getenv("REDIS_SERVER_ADDRESS");

$redis_port = 6379;
if (getenv("REDIS_SERVER_PORT"))
  $redis_port = getenv("REDIS_SERVER_PORT");

$redis = new Predis\Client(array('host' => $redis_ip, 'port' => $redis_port));


# clear all element in my_list
$count = $redis->llen('my_list');
for ($i = 0 ; $i < $count ; $i++) {
  $redis->lpop('my_list');
}

$redis->rpush('my_list',"XXX");
$redis->rpush('my_list',"YYY");
$redis->rpush('my_list',"ZZZ");
$redis->lpush('my_list',"AAA");
$redis->lpush('my_list',"BBB");
$redis->lpush('my_list',"CCC");


print 'my_list status';
print_r($redis->lrange('my_list',0,-1));
print "pop left = " + $redis->lpop('my_list');

print_r($redis->lrange('my_list',0,-1));
?>
