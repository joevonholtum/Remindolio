open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup

type Reminder = { 
    Name: string
    Text: string
}

let firstReminder = { Name = "first"; Text = "This is the first reminder"; }

let initialize (mainWindow:Window) =
    let thisTest = mainWindow.FindName("test") :?> TextBlock
    thisTest.Text <- firstReminder.Text
    

[<STAThread>]
[<EntryPoint>]
let main(_) =
    let application = Application.LoadComponent(new Uri("App.xaml", UriKind.Relative)) :?> Application

    application.Activated
    |> Event.add (fun _ -> initialize application.MainWindow)

    application.Run()