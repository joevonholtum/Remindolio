open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup
open ToastNotifications.Messages
open ToastLibrary


type Reminder = { 
    Name: string
    Text: string
}

let random = Random()

let getReminderAtIndex (reminderList:List<Reminder>, index:int) = 
    reminderList.Item(index)

let testReminder = { Name = "first"; Text = "This is the first reminder"; }
let breathe = { Name = "breathe"; Text = "Take a deep breath. Fill your lungs!" }
let posture = { Name = "posture"; Text = "Are you hunched over and carrying tension?" }

let reminders = [testReminder; breathe; posture;]
 
let hideWindow (window:Window) =
    window.Width <- (float)0
    window.Height <- (float)0
    window.WindowStyle <- WindowStyle.None

let showReminder (rem:Reminder, window:Window) =
    let toastman = Toast()
    let theNotifier = toastman.GetANotifier(window, Application.Current.Dispatcher)
    theNotifier.ShowSuccess(rem.Text)

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