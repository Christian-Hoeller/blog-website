module root.BlogArticle

open FSharp.Formatting.Markdown
open FSharp.Formatting.Common

let articlesFilePath = "./assets/"

let getMarkdown (fileName : string) = 
    System.IO.File.ReadAllText $"{articlesFilePath}{fileName}.md"
    |> Markdown.Parse
    |> Markdown.ToHtml

