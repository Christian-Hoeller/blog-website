module root.BlogArticle

open FSharp.Formatting.Markdown

let articlesFilePath = "./assets/"


let fullArticleFilePath (fileName : string) = 
    $"{articlesFilePath}{fileName}"

// let getArticleTitleByFileName (fileName : string) = 
//     new System.IO.StreamReader (fullArticleFilePath fileName)
//     |> fun sr -> sr.ReadLine()
//     |> fun markdownTitle -> (markdownTitle.Split "# ").[1]

// filename is only title
// get the right file path from file 



//file-format: day_month_year_title_category.md
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


//TODO
//figure out a way to handle file not found exception 