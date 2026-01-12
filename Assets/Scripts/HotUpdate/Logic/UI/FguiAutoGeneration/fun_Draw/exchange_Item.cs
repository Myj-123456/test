/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Draw
{
    public partial class exchange_Item : GButton
    {
        public Controller button;
        public GImage n10;
        public GLoader bg;
        public GLoader pic;
        public GTextField titleLab;
        public GTextField Text_limit;
        public btn_exchange btn_exchange;
        public GImage n16;
        public const string URL = "ui://97nah3khj68sw1";

        public static exchange_Item CreateInstance()
        {
            return (exchange_Item)UIPackage.CreateObject("fun_Draw", "exchange_Item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n10 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            pic = (GLoader)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
            Text_limit = (GTextField)GetChildAt(4);
            btn_exchange = (btn_exchange)GetChildAt(5);
            n16 = (GImage)GetChildAt(6);
        }
    }
}