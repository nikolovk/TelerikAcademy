<?php
session_start();
$types = array(1=>'Храна', 2=>'Цигари',
    3=>'Алкохол', 4=>'Бензин');
$fileName = 'files/' . session_id() . '_data.txt';
?>
