<?php
    require_once('../inlcudes/User.class.php');
    
    if($_SERVER['REQUEST_METHOD'] == 'POST' && isset($_GET['name']) && isset($_GET['email']) && isset($_GET['password'] )){
        User::create_user($_GET['email'], $_GET['name'], $_GET['password']);
    }
?>