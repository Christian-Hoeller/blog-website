module root.Views

open Giraffe.ViewEngine


let navbar () = 
    nav[] [
        h1 [] [ encodedText "navbar" ]
        ul[][
            li [] [ a [ _href "/" ] [ encodedText "home" ] ]
            li [] [ a [ _href "/blog" ] [ encodedText "blog" ] ]
        ]
    ]

let masterLayout (pageTitle : string) (content: XmlNode list) = 
    html [] [
        head [] [
            title []  [ encodedText pageTitle ]
            link [ _rel  "stylesheet"
                   _type "text/css"
                   _href "https://unpkg.com/tailwindcss@^2/dist/tailwind.min.css" ]
        ]
        body [] [
            navbar ()
            div [] content
        ]
    ]

let articleNotExisting () = 
    [
        p [] [encodedText "This article doesn't exist"]
    ]
    |> masterLayout "<ArticleNotFound/>"

let index () = 
    [
        h1 [] [ encodedText "This is the index page" ]
    ] 
    |> masterLayout "Index"

let blogArticle (articleTitle : string) = 
    [
        div [] [rawText (BlogArticle.getMarkdown articleTitle)]
    ]
    |> masterLayout articleTitle
        
let articles () = 
    div [] [
        ul [] (BlogArticle.getAllArticleTitles () 
            |> Array.map (fun title -> li [] [ a [ _href $"/blog/{fst title}" ] [ encodedText (snd title) ] ]) 
            |> Array.toList)
    ]

let blogPage () = 
    [
        h1 [] [encodedText "show all articles here"]
        articles ()
    ]
    |> masterLayout "Blog"