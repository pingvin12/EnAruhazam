using System.Data;
using System.Windows.Controls;
using EnAruhazam.NotificationHandler;
using EnAruhazam.MailLogic;
namespace EnAruhazam
{
    public static class GlobalTypes
    {
        //config loader
        
        
        //main tab buttons
        public static Button[] mainParentButtons = new Button[3];
        public static Button[] mainChildButtons = new Button[2];
        //our menu tab
        public static MenuTabLogic mawl = new MenuTabLogic(null,null,null,null);
        //Notifications

        public static NotificationManager nh = new NotificationManager();


        //options tab
        public static MenuTabLogic OptionsMenu = new MenuTabLogic(null, null, null, null);
        public static Button[] OptionsButtons = new Button[2];
        public static Button[] ChildOptionButtons = new Button[1];

    }
}
