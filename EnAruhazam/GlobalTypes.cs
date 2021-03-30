using System.Data;
using System.Windows.Controls;
using EnAruhazam.NotificationHandler;
namespace EnAruhazam
{
    public static class GlobalTypes
    {
        public static LoadConfig lc = new LoadConfig();
        public static Button[] mainParentButtons = new Button[3];
        public static Button[] mainChildButtons = new Button[2];
        public static MenuTabLogic mawl = new MenuTabLogic(null,null,null,null);
        public static DataSet notifdata = new DataSet();
        public static NotificationManager nh = new NotificationManager();
    }
}
