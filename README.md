# Dily Progress Bar

This application provides a progress bar which tracks how much work you have still left in a day and how much overtime you have collected.
Note that it uses the time of when it was **started up** first as a reference for this.
If the application is restarted, the timer resets.
> Yes, that is easy to fix, but I got enough to do already.

In order to configure how long your workday is, set the time you have to spend in the office through 
the `workingMinutes` variable in the `DailyProgressForm.Designer.cs` file.
The default value is 8 hours.

## How to run

In the project directory, run this command:

```bash
dotnet run
```

Alternatively, in order to only build the project, run:

```bash
dotnet build
```

You can add the program to the Autostart menu of your computer.
This way, the bar will track progress as soon as you begin work.

## How to exit

I removed the toolbar because it looks silly.
You can close the app through the task bar, 'ALT+F4', the task manager or any terminal.

## How to move

You can drag the window around by holding down the left mouse button on the progress bar itself and moving the mouse.
