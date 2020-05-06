using System;
using System.Windows;
using System.Windows.Threading;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;

namespace ToastLibrary
{
    public class Toast
    {
        public Notifier GetANotifier(Window targetWindow, Dispatcher dis)
        {
            var notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider(
                    parentWindow: targetWindow,
                    corner: Corner.TopRight,
                    offsetX: 0,
                    offsetY: 0
                );

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(3),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5)
                );

                cfg.Dispatcher = dis;
            });
            return notifier;
        }
    }
}
