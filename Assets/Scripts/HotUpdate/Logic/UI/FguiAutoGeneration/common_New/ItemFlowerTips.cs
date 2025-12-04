/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class ItemFlowerTips : GComponent
    {
        public GLoader bg;
        public GImage n51;
        public GImage n54;
        public GImage n47;
        public BtnClose close_btn;
        public GLoader img_icon;
        public GLoader img_quality;
        public GLoader vase_img;
        public GTextField txt_name;
        public GTextField txt_des;
        public GTextField txt_ownNum;
        public GTextField sub_title;
        public Item_flower_need item1;
        public Item_flower_need item2;
        public Item_flower_need item3;
        public Item_flower_need item4;
        public clickBtn1 goto_btn;
        public const string URL = "ui://mjiw43v9didl1yjp836";

        public static ItemFlowerTips CreateInstance()
        {
            return (ItemFlowerTips)UIPackage.CreateObject("common_New", "ItemFlowerTips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n51 = (GImage)GetChildAt(1);
            n54 = (GImage)GetChildAt(2);
            n47 = (GImage)GetChildAt(3);
            close_btn = (BtnClose)GetChildAt(4);
            img_icon = (GLoader)GetChildAt(5);
            img_quality = (GLoader)GetChildAt(6);
            vase_img = (GLoader)GetChildAt(7);
            txt_name = (GTextField)GetChildAt(8);
            txt_des = (GTextField)GetChildAt(9);
            txt_ownNum = (GTextField)GetChildAt(10);
            sub_title = (GTextField)GetChildAt(11);
            item1 = (Item_flower_need)GetChildAt(12);
            item2 = (Item_flower_need)GetChildAt(13);
            item3 = (Item_flower_need)GetChildAt(14);
            item4 = (Item_flower_need)GetChildAt(15);
            goto_btn = (clickBtn1)GetChildAt(16);
        }
    }
}