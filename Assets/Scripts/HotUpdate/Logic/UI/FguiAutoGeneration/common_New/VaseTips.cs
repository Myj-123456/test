/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class VaseTips : GComponent
    {
        public GImage n36;
        public BtnClose close_btn;
        public GTextField txt_tile;
        public GLoader img_quality;
        public GLoader img_icon;
        public GTextField txt_gain;
        public GTextField txt_des;
        public GTextField txt_name;
        public const string URL = "ui://mjiw43v9jbpk1yjp7wz";

        public static VaseTips CreateInstance()
        {
            return (VaseTips)UIPackage.CreateObject("common_New", "VaseTips");
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
        }
    }
}