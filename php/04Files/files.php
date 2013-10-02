<?php
$pageTitle = "Списък";
include 'includes/header.php';
if ($_SESSION['isLogged'] != true) {
    header('Location: index.php');
    exit();
} else {
    $filesList = scandir('files');
    ?>
    <div>
        <a href="upload.php">Качване</a>
        <a href="logout.php">Изход</a>                
    </div>
    <div>
        <table>
            <tr>
                <td>Файл</td>
                <td>Размер</td>
            </tr>
            <?php
            $filesCount = count($filesList);
                for ($index = 2; $index < $filesCount; $index++) {
                    echo '<tr>';
                    echo '<td><a href="files'.DIRECTORY_SEPARATOR.$filesList[$index].'" target="_blank">'.$filesList[$index].'</a></td>';
                    echo '<td>'.filesize("files".DIRECTORY_SEPARATOR.$filesList[$index]).'</td>';
                    echo '</tr>';
                }
            ?>
        </table>
    </div>
    <?php
    include 'includes/footer.php';
}