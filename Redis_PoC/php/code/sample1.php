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

$redis->set('Hello','World');
print "Check key 'Hello' exist : ";
if ($redis->exists('Hello'))
  print "True";
else
  print "False";
print "\n";

print "First time to get('Hello') : " . $redis->get('Hello') . "\n";

sleep(3);

# Data in redis will be aging
print "Check key 'Hello' exist : ";
if ($redis->exists('Hello'))
  print "True";
else
  print "False";
print "\n";

print "After 3 seconds to get('Hello')=" + $redis->get('Hello') . "\n";


?>
