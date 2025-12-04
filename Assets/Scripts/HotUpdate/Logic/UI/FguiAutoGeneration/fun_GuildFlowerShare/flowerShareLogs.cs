/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_GuildFlowerShare
{
    public partial class flowerShareLogs : GComponent
    {
        public GImage n13;
        public GImage n14;
        public GRichTextField lb_tip;
        public GList list;
        public GButton close_btn;
        public GTextField lb_title;
        public const string URL = "ui://zuzhxc13s3bkpnt";

        public static flowerShareLogs CreateInstance()
        {
            return (flowerShareLogs)UIPackage.CreateObject("fun_GuildFlowerShare", "flowerShareLogs");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n13 = (GImage)GetChildAt(0);
            n14 = (GImage)GetChildAt(1);
            lb_tip = (GRichTextField)GetChildAt(2);
            list = (GList)GetChildAt(3);
            close_btn = (GButton)GetChildAt(4);
            lb_title = (GTextField)GetChildAt(5);
        }
    }
}