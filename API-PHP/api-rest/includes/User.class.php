<?php
    require_once('Database.class.php');

    //CONTENDRA TODOS LOS METODOS PARA MANIPULAR LA BADE DE DATOS

    class User{
        public static function create_user($email, $name, $password){
            echo "$email.'----''.$password.'----''.$name.'----'";
            $database = new Database();
            $conn = $database->getConnection();

            $stmt = $conn->prepare('INSERT INTO users_list(email, name, password)
                VALUES (:email, :name, :password)');

            $stmt->bindParam(':email', $email);
            $stmt->bindParam(':name', $name);
            $stmt->bindParam(':password', $password);

            if ( $stmt-> execute()){
                header('HTTP/1.1 201 User created saccessfully');
            }else{
                header('HTTP/1.1 404 User did not created');
            }
        }
    }
?>