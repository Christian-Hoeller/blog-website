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

let index () = 
    [
        h1 [] [ encodedText "This is the index page" ]
    ] 
    |> masterLayout "Index"

let blogArticle (article : string) = 
    [
        h1 [] [encodedText (BlogArticle.getArticleTitle article)]
        div [] [rawText (BlogArticle.getMarkdown article)]
    ]
    |> masterLayout "Blog Article: xxx"

let blogPage () = 
    [
        h1 [] [encodedText "show all articles here"]
    ]
    |> masterLayout "Blog"