<?php

require_once 'url_to_absolute.php';

function makeSearch(&$pages) {
    $id = 0;
    $page_id = 0;
    $adj_list = array();
    while (isset($pages[$id])) {
        // find links in one url
        $url_result = findLinks($pages[$id]['full_url']);
        if ($url_result) {
            // add url to queue
            $current_list = array();
            foreach ($url_result as $url) {
                if (!in_array($url, $pages)) {
                    $page_id++;
                    $pages[$page_id] = $url;
                    array_push($current_list, $page_id);
                } else {
                    array_push($current_list, array_search($url, $pages));
                }
            }
            $adj_list[$id] = $current_list;
        } else {
            unset($pages[$id]);
        }

        $id++;
        $countPages = count($pages);
        echo "Count pages - $id / $countPages <br>";
    }
    return $adj_list;
}

//Search all links in one url
function findLinks($target_url) {
    $ch = curl_init();
    $userAgent = 'Mozilla/4.0 (compatible; MSIE 5.01; Windows NT 5.0)';
    curl_setopt($ch, CURLOPT_USERAGENT, $userAgent);
    curl_setopt($ch, CURLOPT_URL, $target_url);
    curl_setopt($ch, CURLOPT_FAILONERROR, true);
    curl_setopt($ch, CURLOPT_FOLLOWLOCATION, true);
    curl_setopt($ch, CURLOPT_AUTOREFERER, true);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($ch, CURLOPT_SSL_VERIFYHOST, false);
    curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);
    curl_setopt($ch, CURLOPT_HEADER, true);
    curl_setopt($ch, CURLOPT_TIMEOUT, 10);
    curl_setopt($ch, CURLOPT_ENCODING, "gzip");
    $html = curl_exec($ch);
    if (!$html) {
        echo "<br />cURL error number:" . curl_errno($ch);
        echo "<br />cURL error:" . curl_error($ch);
        echo "<br />URL:" . $target_url;
        return false;
    }
    //echo $html;
    $dom = new DOMDocument();
    @$dom->loadHTML($html);

    if (stripos($target_url, '://telerikacademy.com')) {
        $div = $dom->getElementById('RecentVideos');
        if ($div) {
            $div->parentNode->removeChild($div);
        }
        $div = $dom->getElementById('LetestForumPosts');
        if ($div) {
            $div->parentNode->removeChild($div);
        }
        $div = $dom->getElementById('Calendar');
        if ($div) {
            $div->parentNode->removeChild($div);
        }
        $div = $dom->getElementById('BlogPosts');
        if ($div) {
            $div->parentNode->removeChild($div);
        }
        $div = $dom->getElementById('fb0021a1c');
        if ($div) {
            $div->parentNode->removeChild($div);
        }
    }
    if (stripos($target_url, '://konkurs.pcmagbg.net')) {
        $div = $dom->getElementById('respond');
        if ($div) {
            $div->parentNode->removeChild($div);
        }
    }

    $xpath = new DOMXPath($dom);


    if (stripos($target_url, '://www.youtube.com/playlist')) {
        $hrefs = $xpath->evaluate('//div[contains(@class,"primary-pane")]//a');
    } else if (stripos($target_url, '://www.youtube.com/watch')) {
        $hrefs = $xpath->evaluate('//p/a');
    } else {
        $hrefs = $xpath->evaluate('body//a');
    }

    $links = array();
    for ($i = 0; $i < $hrefs->length; $i++) {
        $href = $hrefs->item($i);
        //var_dump ($href);
        $url = $href->getAttribute('href');

        $full_url = url_to_absolute($target_url, $url);
        if (stripos($full_url, '#')) {
            $position = stripos($full_url, '#');
            $full_url = substr($full_url, 0, $position);
        }

        $path = parse_url($full_url, PHP_URL_PATH);
        $ext = pathinfo($path, PATHINFO_EXTENSION);

        if (isInSearch($full_url) && !inList($full_url, $links) && ($full_url != $target_url) && !$ext) {
            array_push($links, array('full_url' => $full_url, 'url' => $url));
        }

    }
    return($links);
}

function inList($full_url, $links) {
    $inList = false;
    foreach ($links as $link) {
        if ($link['full_url'] == $full_url) {
            $inList = true;
            break;
        }
    }
    return $inList;
}

function isInSearch($url) {
    $inSearch = false;
    if (stripos($url, '//academy.telerik.com')) {
        $inSearch = true;
    }
    if (stripos($url, '//telerikacademy.com')) {
        $inSearch = true;
    }
    if (stripos($url, '//konkurs.pcmagbg.net')) {
        $inSearch = true;
    }
    if (stripos($url, '//www.youtube.com/playlist')) {
        $inSearch = true;
    }
    if (stripos($url, '//www.youtube.com/watch')) {
        $inSearch = true;
    }
    return $inSearch;
}