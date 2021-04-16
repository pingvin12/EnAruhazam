using DesktopToast;
using System.Runtime.InteropServices;

namespace EnAruhazam.NotificationHandler
{
/// <summary>
    /// Mainly provides a key for notifications to identify with from DesktopToast
    /// </summary>
	[Guid("f5b13fa4-8472-4f82-8a47-515b879006ba"), ComVisible(true), ClassInterface(ClassInterfaceType.None)]
	[ComSourceInterfaces(typeof(INotificationActivationCallback))]
	public class NotificationActivator : NotificationActivatorBase
	{ }
}