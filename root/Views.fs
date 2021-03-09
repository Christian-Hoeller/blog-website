module root.Views

open Giraffe.ViewEngine


let masterLayout (pageTitle : string) (content: XmlNode list) = 
    html [] [
        head [] [
            title []  [ encodedText pageTitle ]
            link [ _rel  "stylesheet"
                   _type "text/css"
                   _href "/main.css" ]
        ]
        h1[] [ encodedText "this is the master layout" ]
        body [] content
    ]

let index () = 
    [
        h1 [] [ encodedText "This is the index page" ]
    ] 
    |> masterLayout "Index"

let blog (article : string) = 
    [
        div [] [rawText (BlogArticle.getMarkdown article)]
    ]
    |> masterLayout "Blog"

let layout (content: XmlNode list) =
    html [] [
        head [] [
            title []  [ encodedText "Blog" ]
            link [ _rel  "stylesheet"
                   _type "text/css"
                   _href "/main.css" ]
        ]
        body [] content
    ]

let customLayout (content: XmlNode list) = 
    html [] [
        head [] [
            title []  [ encodedText "Christians Page" ]
            link [ _rel  "stylesheet"
                   _type "text/css"
                   _href "/main.css" ]
        ]
        body [] content
    ]

let partial () =
    h1 [] [ encodedText "My personal blog website" ]

let helloWorld (message : string) = 
    [
        h1 [] [ encodedText message ]
        p[] [encodedText "this is my first paragraph content"]
    ]
    |> customLayout