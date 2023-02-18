# Domain Aggregate

## User

```csharp
class User
{
    User Create();
    void UpdateEmail(string email);
    void UpdatePassword(string password);
    void UpdateFirstName(string firstName);
    void UpdateLastName(string lastName);
    void UpdateUsername(string username);
}
```


```json
    "User" : {
        "userId" : { "value" : "00000000-0000-0000-0000-000000000000" },
        "firstName" : "John",
        "lastName" : "Doe",
        "username" : "johndoe",
        "email" : "example@gmail.com",
        "password" : "password",  //hash
        "updatedDateTime" : "2020-01-01T00:00:00.0000000Z",
        "createdDateTime" : "2020-01-01T00:00:00.0000000Z"
    }
```


