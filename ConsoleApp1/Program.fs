open Library

// =========================================
// Завдання 5. Точка входу (демонстрація)
// =========================================

[<EntryPoint>]
let main _ =

    printfn "бібліотека\n"

    printfn "Усі доступні книги:"
    libraryCatalog
    |> availableBooks
    |> List.iter (fun b -> printfn "- %s (%s)" b.Title b.Author)

    printfn "\nКниги жанру Programming:"
    libraryCatalog
    |> booksByGenre Programming
    |> List.iter (fun b -> printfn "- %s" b.Title)

    printfn "\nКниги автора George Orwell:"
    libraryCatalog
    |> booksByAuthor "George Orwell"
    |> List.iter (fun b -> printfn "- %s" b.Title)

    printfn "\nКниги автора Robert C. Martin:"
    libraryCatalog
    |> booksByAuthor "Robert C. Martin"
    |> List.iter (fun b -> printfn "- %s" b.Title)

    printfn "\nЗагальна кількість сторінок Programming:"
    libraryCatalog
    |> totalPagesByGenre Programming
    |> printfn "%d"

    printfn "\nСередня кількість сторінок у каталозі:"
    match averagePages libraryCatalog with
    | Some avg -> printfn "%.2f" avg
    | None -> printfn "Каталог порожній"

    0
