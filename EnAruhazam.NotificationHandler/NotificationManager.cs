using DesktopToast;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace EnAruhazam.NotificationHandler
{


/// <summary>
    /// Can instantiate a notification with the manager.
    /// </summary>
    public class NotificationManager
    {
        
        

      

        [Flags]
        public enum NotifType
        {
            
            UNKNOWN = -1,
            TEST = 0,
            EXPIRED_PROD = 1,
            BAD_HR = 2,
            MACHINE_NOT_CLEANED = 3
            
            
            
        }


        public async void DoNotification(string Title, string BodyText, NotifType type)
        {
            
            await ShowToastAsync(Title,BodyText,type);
        }

        

        private async Task<bool> ShowToastAsync(string Title, string BodyText, NotifType type)
        {
            var request = new ToastRequest
            {
                ToastTitle = Title + ": "+ type,
                ToastBody = BodyText,
       
                ShortcutFileName = "EnAruhazamMaster.lnk",
                ShortcutTargetFilePath = Assembly.GetExecutingAssembly().Location,
                AppId = "EnAruhazam",
            };
           
           
            
            var result = await ToastManager.ShowAsync(request);

            return (result == ToastResult.Activated);
        }

    }
}
