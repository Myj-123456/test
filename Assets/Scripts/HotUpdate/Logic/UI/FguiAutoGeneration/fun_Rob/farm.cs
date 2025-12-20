/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class farm : GComponent
    {
        public Controller status;
        public GImage btn_itemList;
        public GLoader pic;
        public blueCostBtn n5;
        public blueCostBtn n8;
        public GTextField n10;
        public GTextField Count_text;
        public const string URL = "ui://z1on8kwddh2tpja";

        public static farm CreateInstance()
        {
            return (farm)UIPackage.CreateObject("fun_Rob", "farm");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            btn_itemList = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            n5 = (blueCostBtn)GetChildAt(2);
            n8 = (blueCostBtn)GetChildAt(3);
            n10 = (GTextField)GetChildAt(4);
            Count_text = (GTextField)GetChildAt(5);
        }
    }
}