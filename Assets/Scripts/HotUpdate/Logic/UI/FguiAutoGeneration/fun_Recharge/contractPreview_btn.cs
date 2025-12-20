/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class contractPreview_btn : GButton
    {
        public Controller type;
        public Controller button;
        public GImage n5;
        public GImage n6;
        public GImage n7;
        public GTextField titleLab1;
        public GTextField titleLab2;
        public const string URL = "ui://w3ox9yltin5z1yjp87z";

        public static contractPreview_btn CreateInstance()
        {
            return (contractPreview_btn)UIPackage.CreateObject("fun_Recharge", "contractPreview_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            button = GetControllerAt(1);
            n5 = (GImage)GetChildAt(0);
            n6 = (GImage)GetChildAt(1);
            n7 = (GImage)GetChildAt(2);
            titleLab1 = (GTextField)GetChildAt(3);
            titleLab2 = (GTextField)GetChildAt(4);
        }
    }
}