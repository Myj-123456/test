/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class DressFilterBtn : GButton
    {
        public Controller button;
        public GImage n85;
        public GLoader img_icon;
        public GImage n93;
        public const string URL = "ui://argzn455ojbq12";

        public static DressFilterBtn CreateInstance()
        {
            return (DressFilterBtn)UIPackage.CreateObject("fun_Dress", "DressFilterBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n85 = (GImage)GetChildAt(0);
            img_icon = (GLoader)GetChildAt(1);
            n93 = (GImage)GetChildAt(2);
        }
    }
}