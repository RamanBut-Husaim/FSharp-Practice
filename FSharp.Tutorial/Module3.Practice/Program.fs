// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

module Main

    open System

    type person = {
        name: string;
        age: int;
        id: int
    }

    let defaultPerson = 
        { name = String.Empty; age = 0; id = 0 }

    let createPerson name age = 
        { name = name; age = age; id = (String.length name) * age }

    let getMainUser = 
        Console.WriteLine("Enter the main user name: ")
        let name = Console.ReadLine()
        Console.WriteLine("Enter the main user age: ")
        let age = Console.ReadLine()

        createPerson name (int age)

    let getUsersCount = 
        Console.WriteLine("Enter the number of users: ")
        let usersCount = Console.ReadLine()

        (int usersCount)

    let getUser index = 
        Console.WriteLine("Enter the user name: ")
        let name = Console.ReadLine()
        Console.WriteLine("Enter ther user age: ")
        let age = Console.ReadLine()

        createPerson name (int age)

    let getUsers numberOfUsers = 
        let users = Array.create numberOfUsers defaultPerson
        for i = 0 to numberOfUsers - 1 do
            let user = getUser i
            Array.set users i user
        
        users

    let findMatchingUsers mainUser users = 
        seq {
            for user in users do
                if mainUser.id = user.id then
                    yield user
        }

    let displayUser user = 
        printfn "%A" user

    let displayMatchingUsers users =
        printfn "Matching users:"
        for user in users do
            displayUser user

        0

    [<EntryPoint>]
    let main argv = 
        let mainUser = getMainUser
        let numberOfUsers = getUsersCount
        let users = getUsers numberOfUsers
        let matchingUsers = findMatchingUsers mainUser users
        ignore (displayMatchingUsers matchingUsers)

        0 // return an integer exit code