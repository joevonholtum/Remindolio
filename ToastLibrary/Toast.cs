using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using System.Windows;
using System.Windows.Threading;

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
                    offsetX: 10,
                    offsetY: 10
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
