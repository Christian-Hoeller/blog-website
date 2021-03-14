module root.BlogArticle

open FSharp.Formatting.Markdown

//file-format: day_month_year_title_category.md
let articlesFilePath = "./assets/"

let fullArticleFilePath (fileName : string) = 
    $"{articlesFilePath}{fileName}"

//reads the title from within a file
let readTitleFromFile (fileName : string) = 
    new System.IO.StreamReader (fullArticleFilePath fileName) 
    |> fun reader -> reader.ReadLine()
    |> fun line -> (line.Split "# ").[1]

let isArticleMatching (title : string, fileName : string) =
    //check if fileName includes title
    (fileName.Split "_").[3].ToLower() = title.ToLower()

//finds the title by itering over all blogArticles
let getFullFilePathByTitle (title : string) = 
    System.IO.Directory.GetFiles(articlesFilePath)
    |> Array.map (fun x -> (System.IO.Path.GetFileName(x)))
    |> Array.find (fun fileName -> isArticleMatching (title, fileName))
    |> fullArticleFilePath

let getMarkdown (fileName : string) = 
    System.IO.File.ReadAllText (getFullFilePathByTitle fileName)
    |> Markdown.Parse
    |> Markdown.ToHtml

let getArticleCategory = "category"

let getAllArticleTitles () = 
    System.IO.Directory.GetFiles(articlesFilePath)
    |> Array.map (fun x -> (System.IO.Path.GetFileName(x)))
    |> Array.map (fun fileName -> readTitleFromFile fileName)

//TODO
//figure out a way to handle file not found exception 