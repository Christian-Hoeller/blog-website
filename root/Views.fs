module root.Views

open Giraffe.ViewEngine

let navbar () = 
    nav[] [
        h1 [] [ encodedText "navbar" ]
    ]

let masterLayout (pageTitle : string) (content: XmlNode list) = 
    html [] [
        head [] [
            title []  [ encodedText pageTitle ]
            link [ _rel  "stylesheet"
                   _type "text/css"
                   _href "/main.css" ]
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

let blogPage () = 
    [
        h1 [] [encodedText "show all articles here"]
    ]
    |> masterLayout "Blog"