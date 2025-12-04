/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class confirmTips : GComponent
    {
        public GImage n32;
        public GLoader bg;
        public GImage n31;
        public clickBtn1 btn_confirm;
        public clickBtn4 btn_cancel;
        public GRichTextField content;
        public GImage n34;
        public GRichTextField lab_antiAddiction;
        public const string URL = "ui://mjiw43v9tosm1yjp7sm";

        public static confirmTips CreateInstance()
        {
            return (confirmTips)UIPackage.CreateObject("common_New", "confirmTips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n32 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n31 = (GImage)GetChildAt(2);
            btn_confirm = (clickBtn1)GetChildAt(3);
            btn_cancel = (clickBtn4)GetChildAt(4);
            content = (GRichTextField)GetChildAt(5);
            n34 = (GImage)GetChildAt(6);
            lab_antiAddiction = (GRichTextField)GetChildAt(7);
        }
    }
}