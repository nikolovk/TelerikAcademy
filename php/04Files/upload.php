<?php
session_start();
$pageTitle = "Качване";
if ($_SESSION['isLogged'] != true) {
    header('Location: index.php');
    exit();
} else {
    $message = '';
    if ($_FILES) {
        if (count($_FILES) > 0) {
            if (move_uploaded_file($_FILES['fileName']['tmp_name'], 'files' . DIRECTORY_SEPARATOR . $_FILES['fileName']['name'])) {
                $message = 'Файлът е качен успешно';
            } else {
                $message = 'Грешка при качването!';
            }
        }
    }
    include 'includes/header.php';
    ?>
    <div>
        <a href="files.php">Списък</a>
        <a href="logout.php">Изход</a>                
    </div>
    <form action="upload.php" method="POST" enctype="multipart/form-data">
        <p class="error"><?= $message ?></p>
        <p>
            <label for="fileName">Файл:</label>
            <input type="file" name="fileName" />
        </p>
        <input type="submit" value="Въведи" />
    </form>
    <?php
    include 'includes/footer.php';
}
