<?php
session_start();
$pageTitle = "Начало";
if (isset($_SESSION['isLogged']) && $_SESSION['isLogged'] == true) {
    header('Location: files.php');
    exit();
} else {
    $errors = array();
    $name = '';
    if ($_POST) {
        $name = trim($_POST['name']);
        $password = trim($_POST['password']);
        if (empty($name) || mb_strlen($name) < 4) {
            $errors['name'] = 'Името трябва да бъде поне 4 символа!';
        }
        if (empty($password) || mb_strlen($password) < 4) {
            $errors['password'] = 'Паролата трябва да бъде поне 4 символа!';
        }
        if (count($errors) == 0) {
            if ($name == 'user' && $password == 'qwerty') {
                $_SESSION['isLogged'] = true;
                header('Location: files.php');
                exit();
            } else {
                $errors['notLogged'] = 'Грешно име или парола';
            }
        }
    }
    include 'includes/header.php';
    ?>
    <form action="index.php" method="POST">
        <p class="error"><?= isset($errors['notLogged']) ? $errors['notLogged'] : '' ?></p>
        <p>
            <label for="name">Име:</label>
            <input type="text" name="name" value="<?= $name ?>" />
            <span class="error"><?= isset($errors['name']) ? $errors['name'] : '' ?></span>
        </p>
        <p>
            <label for="password">Парола:</label>
            <input type="password" name="password" />
            <span class="error"><?= isset($errors['password']) ? $errors['password'] : '' ?></span>
        </p>
        <input type="submit" value="Въведи" />
    </form>
    <?php
    include 'includes/footer.php';
}