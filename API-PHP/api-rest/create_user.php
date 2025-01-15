<?php
require_once('../inlcudes/User.class.php');

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    
    $body = json_decode(file_get_contents('php://input'), true);
    
    $email = $body['email'];
    $name = $body['name'];
    $password = $body['password'];
    User::create_user($email, $name, $password);
}

?>
