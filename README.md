# Timer with question in C#

This snippet of code is for a question in C#, with a live timer running at the same time.


First, we create some static variables
```csharp
static int CountDown = 60;

static List<char> AllCharacters = new();

static bool HasAnsweredPrompt = false;

static ConsoleKeyInfo CurrentCharacter;
```

+ The ```CountDown``` variable stores how long the timer has left. To start, it is set to 60 seconds.
+ The ```AllCharacters``` variable will store what the user types.
+ The ```HasAnsweredPrompt``` will become true when the user types ENTER
+ The ```CurrentCharacter``` stores the current character that the user has typed.


Next is our Main method

```csharp
System.Timers.Timer timer = new (1000);
```
+ This code may look scary, but it is just creating a new ```Timer```, which will update every second.
+ The 1000 stands for 1000 milliseconds

<br>

```csharp
timer.Elapsed += UpdateTimer;
timer.Enabled = true;
```
+ This piece of code tells the ```Timer``` that every second, it should call the ```UpdateTimer``` method.
+ Next is just starts the timer!

<br>

```csharp
Console.WriteLine("What is Heisenberg's real name?");
```
+ This will be your question, and it could be anything you want.

<br>

```csharp
while(!HasAnsweredPrompt) {
}
```
+ This ```while``` loop will keep repeating until the users pressed enter.

**_These next pieces of code are inside the ```while``` loop._**

```csharp
CurrentCharacter = Console.ReadKey(true);
```
+ This reads in **_one_** char from the user, and stores it in the ```CurrentChar``` variable
+ Note that the ```true``` means that the ReadKey will not output to the console.

```csharp
if(CurrentCharacter.Key == Console.Enter) {
    HasAnsweredPrompt = true;
    break;
}
```
+ This checks if the key that the user entered is ENTER
+ If it is, then it sets ```HasAnsweredPrompt``` to ```true```
+ It then _breaks_ out of the loop


```csharp
Console.SetCursorPos(0, 2);
AllCharacters.Add(CurrentCharacter.KeyChar);
```
+ This sets the position of the cursor to the **_second line_**
+ It then adds the ```CurrentCharacter``` to the list of them.

```csharp
for(int i = 0; i < AllCharacters.Count; i++) {
    Console.Write(AllCharacters[i]);
}
```
+ Here, we use a ```for``` loop to print out the characters in order, creating a string. 
+ Because the chars are in order, it recreated what the user entered.

**_The for loop ends here_**

```csharp
static void UpdateTimer(object source, ElapsedEventArgs e) {
    if(HasAnsweredPrompt) return;
    if(CountDown-- <= 0) return;

    Console.SetCursorPos(0, 1);
    Console.WriteLine(CountDown + " Seconds Left!");
}
```

+ Here we check if the user has finished typing ( by pressing enter )
+ If they haven't, then we continue on
+ We also check if the timer has finished
+ We set the cursor's position to the **_first line_**
+ We print out how many seconds are left

