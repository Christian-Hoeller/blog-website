module Models

type Message = 
    {
        value: string
    }

type Article =
    {
        id : int
        name : string
        topic : string
    }

let topics = [ 
    "coding" 
    "training"
    "productivity"
    ]

