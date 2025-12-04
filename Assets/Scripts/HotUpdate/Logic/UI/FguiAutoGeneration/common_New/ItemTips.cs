/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class ItemTips : GComponent
    {
        public Controller type;
        public GLoader bg;
        public GImage n51;
        public BtnClose close_btn;
        public GImage n47;
        public GLoader img_icon;
        public GLoader img_quality;
        public GLoader vase_img;
        public GTextField txt_name;
        public GTextField txt_des;
        public GTextField txt_ownNum;
        public const string URL = "ui://mjiw43v9iwn11yjp7ws";

        public static ItemTips CreateInstance()
        {
            return (ItemTips)UIPackage.CreateObject("common_New", "ItemTips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n51 = (GImage)GetChildAt(1);
            close_btn = (BtnClose)GetChildAt(2);
            n47 = (GImage)GetChildAt(3);
            img_icon = (GLoader)GetChildAt(4);
            img_quality = (GLoader)GetChildAt(5);
            vase_img = (GLoader)GetChildAt(6);
            txt_name = (GTextField)GetChildAt(7);
            txt_des = (GTextField)GetChildAt(8);
            txt_ownNum = (GTextField)GetChildAt(9);
        }
    }
}