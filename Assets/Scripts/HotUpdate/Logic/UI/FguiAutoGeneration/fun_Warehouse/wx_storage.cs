/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Warehouse
{
    public partial class wx_storage : GComponent
    {
        public Controller status;
        public Controller type;
        public GLoader bg;
        public GImage n83;
        public GImage n77;
        public GImage n72;
        public GImage n73;
        public GImage n74;
        public GImage n75;
        public GImage n78;
        public GImage n84;
        public GImage n61;
        public GList list;
        public GGroup show;
        public GImage n70;
        public GImage n71;
        public GImage n65;
        public GImage n66;
        public GImage n62;
        public GImage n63;
        public GButton btn_flower;
        public GButton btn_item;
        public GButton btn_flowerArt;
        public GGroup n68;
        public GTextField titleLab;
        public GTextField pageTxt;
        public GButton close_btn;
        public const string URL = "ui://6soq1zhgcebdnyw";

        public static wx_storage CreateInstance()
        {
            return (wx_storage)UIPackage.CreateObject("fun_Warehouse", "wx_storage");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            type = GetControllerAt(1);
            bg = (GLoader)GetChildAt(0);
            n83 = (GImage)GetChildAt(1);
            n77 = (GImage)GetChildAt(2);
            n72 = (GImage)GetChildAt(3);
            n73 = (GImage)GetChildAt(4);
            n74 = (GImage)GetChildAt(5);
            n75 = (GImage)GetChildAt(6);
            n78 = (GImage)GetChildAt(7);
            n84 = (GImage)GetChildAt(8);
            n61 = (GImage)GetChildAt(9);
            list = (GList)GetChildAt(10);
            show = (GGroup)GetChildAt(11);
            n70 = (GImage)GetChildAt(12);
            n71 = (GImage)GetChildAt(13);
            n65 = (GImage)GetChildAt(14);
            n66 = (GImage)GetChildAt(15);
            n62 = (GImage)GetChildAt(16);
            n63 = (GImage)GetChildAt(17);
            btn_flower = (GButton)GetChildAt(18);
            btn_item = (GButton)GetChildAt(19);
            btn_flowerArt = (GButton)GetChildAt(20);
            n68 = (GGroup)GetChildAt(21);
            titleLab = (GTextField)GetChildAt(22);
            pageTxt = (GTextField)GetChildAt(23);
            close_btn = (GButton)GetChildAt(24);
        }
    }
}