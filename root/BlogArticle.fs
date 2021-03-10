module root.BlogArticle

open FSharp.Formatting.Markdown
open FSharp.Formatting.Common

let articlesFilePath = "./assets/"

let isArticleMatching (articleFileName : string, iterFileName : string) =
    $"{articleFileName}.md" = iterFileName

let extractTitleFromFilename (fileName : string) = 
    (fileName.Split[|'.'|]).[0]
    // (fileName.Split[|' '|]).[1]
    // |> fun x -> (x.Split[|' '|]).[0]

let getArticleTitle (fileName : string) = 
    System.IO.Directory.GetFiles(articlesFilePath)
    |> Array.map (fun x -> (System.IO.Path.GetFileName(x)))
    |> Array.find (fun x -> isArticleMatching (fileName, x))
    |> extractTitleFromFilename

let getMarkdown (fileName : string) = 
    let title = extractTitleFromFilename fileName
    System.IO.File.ReadAllText $"{articlesFilePath}{title}.md"
    |> Markdown.Parse
    |> Markdown.ToHtml