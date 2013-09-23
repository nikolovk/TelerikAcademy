<?php
$pageTitle = "Въвеждане";
include 'includes/header.php';
$isUpdate = false;
$row = '';
$errors = array();
$now = strtotime(date('Y-m-d'));
if ($_POST) {
    $name = trim($_POST['name']);
    $name = str_replace('!', '', $name);
    $sum = (float) trim($_POST['sum']);
    $date = strtotime($_POST['date']);
    $type = trim($_POST['type']);
    $type = str_replace('!', '', $type);
    $isUpdate = (bool)$_POST['isUpdate'];

    if (empty($name) || mb_strlen($name) < 4) {
        $errors['name'] = 'Името трябва да бъде поне 4 символа!';
    }
    if ($sum <= 0) {
        $errors['name'] = 'Името трябва да бъде поне 4 символа!';
    }
    if ($date == FALSE || $date < strtotime(date('Y-m-d') . ' -1 year') ||
            $date > strtotime(date('Y-m-d') . ' +1 month')) {
        $errors['date'] = 'Дата не трябва да е преди повече от година или след повече от месец!';
    }
    if (!array_key_exists($type, $types)) {
        $errors['type'] = 'Невалиден вид';
    }
    if (count($errors) == 0) {
        $result = $name . '!' . $sum . '!' . $date . '!' . $type . "\n";
        if ($isUpdate === true) {
            $row = (int) trim($_POST['row']);
            $lines = file($fileName);
            $content = '';
            foreach ($lines as $key => $value) {
                if ($row == $key) {
                    $content .= $result;
                } else {
                    $content .= $value;
                }
            }
            if (file_put_contents($fileName, $content)) {
                echo '<p>Записът е променен успешно.</p>';
                $name = '';
                $sum = '';
                $type = '';
                $date = strtotime(date('Y-m-d'));
            } else {
                echo '<p>Проблем при промяна.</p>';
            }            
        } else {
            if (file_put_contents($fileName, $result, FILE_APPEND)) {
                echo '<p>Записът е успешен.</p>';
                $name = '';
                $sum = '';
                $type = '';
                $date = strtotime(date('Y-m-d'));
            } else {
                echo '<p>Проблем при записване.</p>';
            }
        }
    }
} elseif ($_GET) {
    $lines = file($fileName);
    $row = $_GET['row'];
    $data = $lines[$row];
    $columns = explode('!', $data);
    $isUpdate = '1';
    $name = $columns['0'];
    $sum = $columns['1'];
    $date = $columns['2'];
    $type = $columns['3'];
} else {
    $name = '';
    $sum = '';
    $type = '';
    $date = strtotime(date('Y-m-d'));
}
?>
<form action="form.php" method="POST">
    <input type="hidden" name="isUpdate" value="<?= $isUpdate ?>" />
    <input type="hidden" name="row" value="<?= $row ?>" />
    <a href="index.php">Списък</a>
    <p>
        <label for="name">Име:</label>
        <input type="text" name="name" value="<?= $name ?>" />
        <span class="error"><?= $errors['name'] ?></span>
    </p>
    <p>
        <label for="sum">Сума:</label>
        <input type="number" name="sum" value="<?= $sum ?>" step="0.01" min="0.01" />
        <span class="error"><?= $errors['sum'] ?></span>
    </p>
    <p>
        <label for="date">Дата:</label>
        <input type="date" name="date" value="<?= date('Y-m-d', $date) ?>"/>
        <span class="error"><?= $errors['date'] ?></span>
    </p>
    <p>
        <label for="type">Вид:</label>
        <select name="type">
            <?php foreach ($types as $key => $value) { ?>   
                <option value="<?= $key ?>" <?php echo ($type == $key) ? 'selected' : ''; ?>><?= $value ?></option>
            <?php } ?>
        </select>
        <span class="error"><?= $errors['type'] ?></span>
    </p>
    <input type="submit" value="<?= $isUpdate ? 'Промени' : 'Въведи' ?>" />
</form>
<?php
include 'includes/footer.php';
