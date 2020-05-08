open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup
open ToastLibrary
open Reminders.ReminderHandler

let random = Random()
 
let hideWindow (window:Window) =
    window.Width <- (float)0
    window.Height <- (float)0
    window.WindowStyle <- WindowStyle.None

let initialize (mainWindow:Window) =
    let max = reminders.Length
    let chosenReminder = getReminderAtIndex(reminders, random.Next(0, max))
    showReminder(chosenReminder, mainWindow)

[<STAThread>]
[<EntryPoint>]
let main(_) =
    let application = Application.LoadComponent(new Uri("App.xaml", UriKind.Relative)) :?> Application

    application.Activated
    |> Event.add (fun _ -> initialize application.MainWindow)

    application.Run()