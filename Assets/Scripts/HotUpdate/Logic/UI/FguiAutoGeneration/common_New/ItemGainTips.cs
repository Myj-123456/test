/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class ItemGainTips : GComponent
    {
        public Controller type;
        public GLoader bg;
        public GImage n50;
        public GImage n52;
        public GImage n48;
        public BtnClose close_btn;
        public GLoader img_icon;
        public GLoader img_quality;
        public GLoader img_vase;
        public GTextField txt_name;
        public GTextField txt_des;
        public GTextField txt_ownNum;
        public GTextField sub_title;
        public GList list_gainway;
        public const string URL = "ui://mjiw43v9iwn11yjp7wt";

        public static ItemGainTips CreateInstance()
        {
            return (ItemGainTips)UIPackage.CreateObject("common_New", "ItemGainTips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n50 = (GImage)GetChildAt(1);
            n52 = (GImage)GetChildAt(2);
            n48 = (GImage)GetChildAt(3);
            close_btn = (BtnClose)GetChildAt(4);
            img_icon = (GLoader)GetChildAt(5);
            img_quality = (GLoader)GetChildAt(6);
            img_vase = (GLoader)GetChildAt(7);
            txt_name = (GTextField)GetChildAt(8);
            txt_des = (GTextField)GetChildAt(9);
            txt_ownNum = (GTextField)GetChildAt(10);
            sub_title = (GTextField)GetChildAt(11);
            list_gainway = (GList)GetChildAt(12);
        }
    }
}