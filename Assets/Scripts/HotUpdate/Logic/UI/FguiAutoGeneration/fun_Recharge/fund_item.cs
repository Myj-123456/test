/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class fund_item : GComponent
    {
        public Controller textcolor;
        public Controller ctrl;
        public GImage n5;
        public GRichTextField limitLab;
        public GTextField proLab;
        public GTextField proLab1;
        public GButton btn;
        public GList list;
        public GImage n7;
        public const string URL = "ui://w3ox9yltcu3e1yjp887";

        public static fund_item CreateInstance()
        {
            return (fund_item)UIPackage.CreateObject("fun_Recharge", "fund_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            textcolor = GetControllerAt(0);
            ctrl = GetControllerAt(1);
            n5 = (GImage)GetChildAt(0);
            limitLab = (GRichTextField)GetChildAt(1);
            proLab = (GTextField)GetChildAt(2);
            proLab1 = (GTextField)GetChildAt(3);
            btn = (GButton)GetChildAt(4);
            list = (GList)GetChildAt(5);
            n7 = (GImage)GetChildAt(6);
        }
    }
}