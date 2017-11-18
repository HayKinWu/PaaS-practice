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


$pipe = $redis->pipeline();
$pipe->set('Number',123)->incrby('Number',123)->execute();
print "Number = " . $redis->get('Number') . "\n";

?>
