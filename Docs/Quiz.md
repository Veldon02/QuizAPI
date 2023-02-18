# Domain Aggregate

## Quiz

```csharp
class Quiz
{
    Quiz Create(); 
    void AddQuestion(Question question);
    void RemoveQuestion(Question question);
}

```

```json
{
    "quiz" : {
        "quizId" : "00000000-0000-0000-0000-000000000000" ,
        "name" : "00000000-0000-0000-0000-000000000000",
        "description" : "Some description",
        "difficulty" : 5,
        "authorId" : "00000000-0000-0000-0000-000000000000",
        "questions" : [
            {   
                "questionId" : "00000000-0000-0000-0000-000000000000" ,
                "title" : "Question",
                "answers" : [
                    {
                        "answerId" : "00000000-0000-0000-0000-000000000000" ,
                        "title" :"Some answer"
                    }
                ]  
            } 
        ],
        "updatedDateTime" : "2020-01-01T00:00:00.0000000Z",
        "createdDateTime" : "2020-01-01T00:00:00.0000000Z"
    }
}

```