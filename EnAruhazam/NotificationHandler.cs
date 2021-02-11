using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DesktopToast;
using NotificationsExtensions;
using NotificationsExtensions.Toasts;

namespace EnAruhazam
{
    
    

   public class NotificationHandler
    {
        
        

      

        [Flags]
        public enum NotifType
        {
            //placeholders for now
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
