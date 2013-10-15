<?php
include 'includes/connection.php';
$sql = 'SELECT books.book_id, books.book_title, authors.author_name, authors.author_id FROM books 
            LEFT JOIN books_authors ON books_authors.book_id = books.book_id
            LEFT JOIN authors ON books_authors.author_id = authors.author_id';
$query = mysqli_query($connection, $sql);
if (!$query) {
    echo 'Connection problem';
    echo mysqli_error($connection);
    exit;
}
$countBooks = mysqli_num_rows($query);
$books = array();
while ($row = mysqli_fetch_assoc($query)) {
    $books[$row['book_id']]['title'] = $row['book_title'];
        $books[$row['book_id']]['authors'][$row['author_id']] = $row['author_name'];
}
$countBooks = count($books);
include 'includes/header.php';
?>
 
<h2>Всички книги</h2>
<?php if ($countBooks > 0) { ?>
    <table>
        <tr>
            <th>Книга</th>
            <th>Автори</th>
        </tr>
        <?php foreach ($books as $book) { ?>
            <tr>
                <td><?= $book['title'] ?></td>
                <td>
                    <?php foreach ($book['authors'] as $authorId => $authorName) { ?>
                    <a href="allAuthorBooks.php?author_id=<?= $authorId ?>"><?= $authorName ?></a> 
                    <?php } ?>
                </td>
            </tr>
        <?php } ?>
    </table>
<?php } 
include 'includes/footer.php';
