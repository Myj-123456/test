/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_GuildFlowerShare
{
    public partial class flowerShare_manager_1 : GComponent
    {
        public GImage n19;
        public GTextField title;
        public GRichTextField lb_info;
        public const string URL = "ui://zuzhxc13misapod";

        public static flowerShare_manager_1 CreateInstance()
        {
            return (flowerShare_manager_1)UIPackage.CreateObject("fun_GuildFlowerShare", "flowerShare_manager_1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n19 = (GImage)GetChildAt(0);
            title = (GTextField)GetChildAt(1);
            lb_info = (GRichTextField)GetChildAt(2);
        }
    }
}