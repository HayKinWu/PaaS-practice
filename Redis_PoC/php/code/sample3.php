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


$my_list = array("key1"=>"value1","foo"=>"bar","Num"=>123);
$redis->mset($my_list);

print_r($redis->mget('key1','foo','Num'));
?>
