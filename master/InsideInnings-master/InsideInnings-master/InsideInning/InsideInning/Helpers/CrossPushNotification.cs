using System;
using System.Collections.Generic;
using System.Text;

namespace InsideInning.Helpers
{
    public class CrossPushNotification
    {
        public static string NotificationContentTitleKey { get; set; }

        //The sets the key associated with the value will used to show the text for the notification
        public static string NotificationContentTextKey { get; set; }

        //The sets the resource id for the icon will be used for the notification
        public static int IconResource { get; set; }

        //The sets the sound  uri will be used for the notification
        public static Android.Net.Uri SoundUri { get; set; }

    }
}
