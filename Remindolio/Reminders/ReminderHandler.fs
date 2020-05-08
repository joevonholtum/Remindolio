namespace Reminders

    open System.Windows
    open ToastLibrary
    open ToastNotifications.Messages

    module ReminderHandler =
        
        type Reminder = {
            Name: string
            Text: string
        }

        //Sample reminders
        let water = { Name = "water"; Text = "Had enough water?"; }
        let breathe = { Name = "breathe"; Text = "Take a deep breath. Fill your lungs!" }
        let posture = { Name = "posture"; Text = "Are you hunched over and carrying tension?" }
        let walk = { Name = "walk"; Text = "Hey! Walk! Do stretches!"}
        
        let reminders = [water; breathe; posture; walk;]

        let showReminder (reminder:Reminder, window:Window) =
            let toastman = Toast()
            let theNotifier = toastman.GetNotifier(window, Application.Current.Dispatcher)
            theNotifier.ShowSuccess(reminder.Text)

        let getReminderAtIndex (reminderList:List<Reminder>, index:int) =
            reminderList.Item(index)