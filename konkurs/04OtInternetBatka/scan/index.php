<!doctype html>
<html lang="bg">
    <head>
        <meta charset="utf-8">
    </head>
    <body>
        <pre>
            <?php
            require_once 'inc/funcs.php';
            $start_url = "http://telerikacademy.com/";
            $pages = array();
            $pages[0] = array('full_url' => $start_url, 'url' => $start_url);

            $adjList = makeSearch($pages);
            $fp = fopen("c:/wamp/www/scan/pages.txt",'w');
            foreach ($pages as $key => $value) {
                fwrite($fp,$key.":".$value['full_url'].';'.$value['url'].PHP_EOL);
            }
            fclose($fp);    
            $fpAdj = fopen("c:/wamp/www/scan/adj.txt",'w');
            foreach ($adjList as $key => $value) {
                fwrite($fpAdj,$key.":");
                $count = count($value);
                for($i=0; $i< $count ;$i++){
                   fwrite($fpAdj,$value[$i]);
                   if ($i<$count -1) {
                      fwrite($fpAdj,','); 
                   }
                }
                fwrite($fpAdj,PHP_EOL);
            }
            fclose($fpAdj)  ;   
            ?>
        </pre>
    </body>
</html>