module Library

// =========================================
// Завдання 1. Моделювання предметної області
// =========================================

//Алгебраїчний тип для жанру книги
type Genre =
    | Fiction
    | NonFiction
    | Science
    | History
    | Programming
    | Other
//Алгебраїчний тип для статусу книги
type BookStatus =
    | Available
    | Issued
    | Archived
//Тип Книги
type Book =
    { Id: int
      Title: string
      Author: string
      Year: int
      Genre: Genre
      Pages: int
      Status: BookStatus }

// =========================================
// Завдання 2. Тестовий набір даних
// =========================================

let libraryCatalog : Book list =
    [ { Id = 1
        Title = "Кобзар"
        Author = "Тарас Шевченко"
        Year = 1840
        Genre = Fiction
        Pages = 320
        Status = Available }

      { Id = 2
        Title = "Мистецтво програмування"
        Author = "Donald Knuth"
        Year = 1968
        Genre = Programming
        Pages = 650
        Status = Issued }

      { Id = 3
        Title = "Чистий код"
        Author = "Robert C. Martin"
        Year = 2008
        Genre = Programming
        Pages = 450
        Status = Available }

      { Id = 4
        Title = "1984"
        Author = "George Orwell"
        Year = 1949
        Genre = Fiction
        Pages = 328
        Status = Available }

      { Id = 5
        Title = "Sapiens: Людина розумна"
        Author = "Yuval Noah Harari"
        Year = 2011
        Genre = NonFiction
        Pages = 512
        Status = Issued }

      { Id = 6
        Title = "Домашнє кондитерство"
        Author = "Умовний автор"
        Year = 2015
        Genre = NonFiction
        Pages = 220
        Status = Available }

      { Id = 7
        Title = "Історія України"
        Author = "Умовний автор"
        Year = 2003
        Genre = History
        Pages = 300
        Status = Archived }

      { Id = 8
        Title = "Алгоритми. Побудова та аналіз"
        Author = "Cormen et al."
        Year = 1990
        Genre = Programming
        Pages = 1312
        Status = Available } ]

// =========================================
// Завдання 3. Фільтрація та пошук
// =========================================

//Усі доступні книги
let availableBooks (books: Book list) =
    books |> List.filter (fun b -> b.Status = Available)
//Пошук - жанром
let booksByGenre (genre: Genre) (books: Book list) =
    books |> List.filter (fun b -> b.Genre = genre)

//Пошук книг за автором 
let booksByAuthor (authorName: string) (books: Book list) =
    let normalize (s: string) = s.ToLower()
    books
    |> List.filter (fun b -> normalize b.Author = normalize authorName)

// =========================================
// Завдання 4. Трансформації та агрегація
// =========================================

//Список назв усіх книг
let bookTitles (books: Book list) =
    books |> List.map (fun b -> b.Title)
//Загальна кількість сторінок для певного жанру
let totalPagesByGenre (genre: Genre) (books: Book list) =
    books
    |> booksByGenre genre
    |> List.map (fun b -> b.Pages)
    |> List.sum
//Середня кількість сторінок
let averagePages (books: Book list) =
    match books with
    | [] -> None
    | _ ->
        let total = books |> List.sumBy (fun b -> b.Pages)
        let count = books.Length
        Some (float total / float count)
