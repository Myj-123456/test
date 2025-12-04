/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class FlowerTips : GComponent
    {
        public GImage n36;
        public BtnClose close_btn;
        public GTextField txt_tile;
        public GLoader img_quality;
        public GLoader img_icon;
        public GTextField txt_gain;
        public GTextField txt_des;
        public GTextField txt_name;
        public GList list_1;
        public GList list_gainway;
        public const string URL = "ui://mjiw43v9jbpk1yjp7x0";

        public static FlowerTips CreateInstance()
        {
            return (FlowerTips)UIPackage.CreateObject("common_New", "FlowerTips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n36 = (GImage)GetChildAt(0);
            close_btn = (BtnClose)GetChildAt(1);
            txt_tile = (GTextField)GetChildAt(2);
            img_quality = (GLoader)GetChildAt(3);
            img_icon = (GLoader)GetChildAt(4);
            txt_gain = (GTextField)GetChildAt(5);
            txt_des = (GTextField)GetChildAt(6);
            txt_name = (GTextField)GetChildAt(7);
            list_1 = (GList)GetChildAt(8);
            list_gainway = (GList)GetChildAt(9);
        }
    }
}