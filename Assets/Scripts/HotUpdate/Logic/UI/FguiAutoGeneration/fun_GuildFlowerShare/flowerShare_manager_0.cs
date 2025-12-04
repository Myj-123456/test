/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_GuildFlowerShare
{
    public partial class flowerShare_manager_0 : GComponent
    {
        public GImage n9;
        public GButton btn_edit;
        public GList flowerList;
        public GTextField title;
        public GRichTextField lb_tip;
        public const string URL = "ui://zuzhxc13misapoc";

        public static flowerShare_manager_0 CreateInstance()
        {
            return (flowerShare_manager_0)UIPackage.CreateObject("fun_GuildFlowerShare", "flowerShare_manager_0");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n9 = (GImage)GetChildAt(0);
            btn_edit = (GButton)GetChildAt(1);
            flowerList = (GList)GetChildAt(2);
            title = (GTextField)GetChildAt(3);
            lb_tip = (GRichTextField)GetChildAt(4);
        }
    }
}