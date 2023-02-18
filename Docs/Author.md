# Domein Aggregate

## Author

```csharp
    class Author
    {
        Author Create();
        void AddQuiz(Quiz quiz);
        void RemoveQuiz(Quiz quiz);
    }
```

```json
    {
        "authorId" : "00000000-0000-0000-0000-000000000000",
        "userId" : "00000000-0000-0000-0000-000000000000",
        "quizIds" : [
            "00000000-0000-0000-0000-000000000000"
        ]
    }
```