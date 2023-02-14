<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Car Listing</title>
    <link href = "assign1.css" type = "text/css" rel = "stylesheet">
</head>
<body>
    
<h1>Car Inventory</h1>

<?php

$connect = mysqli_connect(

    'sql300.epizy.com', // Host
    'epiz_33409930', // Database username
    'qIJP5D7pf9', // Database password
    'epiz_33409930_assign1' // Database name
);

if(mysqli_connect_errno()) {

    echo mysqli_connect_error();
    exit();
}

$query = "SELECT * 
    FROM car_inventory
    ORDER BY car_make";

$result = mysqli_query($connect, $query)
or die(mysqli_error($connect));

echo "Number of rows ".mysqli_num_rows($result);

while($record = mysqli_fetch_assoc($result)) {

    echo '<div class = "carList">';
    echo '<h2>'.$record['car_make'].'</h2>';
    echo '<p>Model: '.$record['car_model'].'</p>';
    echo '<p>Year: '.$record['car_year'].'</p>';
    echo '<p>Mileage: '.$record['car_mileage'].'</p>';
    echo '<p>Cost: '.$record['car_cost'].'</p>';
    echo '<img src = "'.$record['car_image'].'" width = "200">';

    if ($record['car_cost'] > 14000) {
        echo '<p>You are the boss!!</p>';
        $boss = ($record['car_cost'] - 14000) / 1000;
        for ($i = 0; $i < $boss; $i++){
            echo '&#9787';
        }
        
    }elseif ($record['car_cost'] < 14000) {
        echo '<p>You are trying!!</p>';
        $boss2 = (14000 - $record['car_cost']) / 1000;
        for ($i = 0; $i < $boss2; $i++) {
            echo '&#9785';
        }
    }else {
        echo '<p>You are on point!!</p>';
        echo '&#129309';
    }
    echo '</div>';
    //print_r($record);

}

?>


</body>
</html>