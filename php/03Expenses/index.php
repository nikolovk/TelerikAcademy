<?php
$pageTitle = "Начало";
include 'includes/header.php';
if ($_GET && strlen($_GET['delete']) > 0) {
    $deleteRow = (int) $_GET['delete'];
    if (file_exists($fileName)) {
        $rows = file($fileName);
        $rowCount = count($rows);
        $content = '';
        for ($index = 0; $index < $rowCount; $index++) {
            if ($index != $deleteRow) {
                $content .= $rows[$index];
            }
        }
        if (file_put_contents($fileName, $content)) {
            echo '<p>Записът е изтрит!</p>';
        }
    }
}
if ($_GET && $_GET['filter'] == '1') {
    $date = strtotime($_GET['date']);
    $type = trim($_GET['type']);
}
?>
<form action="index.php" method="GET">
    <input type="hidden" name="filter" value="1" />
    <a href="form.php">Добави нов разход</a>
    <select name="type">
        <option value="">Всички</option>
        <?php
        foreach ($types as $key => $value) {
            echo '<option value="' . $key . '" '. ($type==$key ? 'selected': '') .'>' . $value . '</option>';
        }
        ?>
    </select>
    <label for="date">Дата:</label>
    <input type="date" name="date" value="<?php echo ($date ? date('Y-m-d', $date) : ''); ?>"/>
    <input type="submit" value="Филтрирай" />
</form>
<table>
    <thead>
        <tr>
            <th>Име</th>
            <th>Сума</th>
            <th>Дата</th>
            <th>Вид</th>
            <th>Операция</th>
        </tr>
    </thead>
    <tbody>
        <?php
        if (file_exists($fileName)) {
            $result = file($fileName);
            $sum = 0;
            foreach ($result as $key => $value) {
                $columns = explode('!', $value);
                if (($date ? $columns[2] == $date : true) &&
                        ($type ? trim($columns[3]) == $type : true)) {
                    echo '<tr>
                    <td>' . $columns[0] . '</td>
                     <td>' . $columns[1] . '</td>
                    <td>' . date('Y-m-d', $columns[2]) . '</td>
                    <td>' . $types[trim($columns[3])] . '</td>
                    <td>
                        <a href="form.php?row=' . $key . '">Промени</a>
                        <a href="index.php?delete=' . $key . '">Изтрии</a>
                     </td>
                </tr>';
                    $sum += (float) $columns[1];
                }
            }
            ?>
            <tr>
                <td>---</td>
                <td><?= round($sum, 2) ?></td>
                <td>---</td>
                <td>---</td>
                <td>---</td>
            </tr>
        <?php } ?>
    </tbody>
</table>
<?php
include 'includes/footer.php';





