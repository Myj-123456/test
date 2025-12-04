/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class ItemGainRender : GComponent
    {
        public GImage n4;
        public GTextField txt_gainWay;
        public clickBtn3 btnGo;
        public const string URL = "ui://mjiw43v9iwn11yjp7wu";

        public static ItemGainRender CreateInstance()
        {
            return (ItemGainRender)UIPackage.CreateObject("common_New", "ItemGainRender");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
            txt_gainWay = (GTextField)GetChildAt(1);
            btnGo = (clickBtn3)GetChildAt(2);
        }
    }
}