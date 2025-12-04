/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Adventure
{
    public partial class BubbleItem : GComponent
    {
        public Controller c1;
        public GImage n0;
        public GTextField txt_costNum;
        public GLoader img_itemIcon;
        public GImage n2;
        public const string URL = "ui://3yqg0b4es31r0";

        public static BubbleItem CreateInstance()
        {
            return (BubbleItem)UIPackage.CreateObject("fun_Adventure", "BubbleItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            txt_costNum = (GTextField)GetChildAt(1);
            img_itemIcon = (GLoader)GetChildAt(2);
            n2 = (GImage)GetChildAt(3);
        }
    }
}