/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class dress_detail_view : GComponent
    {
        public Controller type;
        public GLoader bg;
        public GImage n50;
        public GImage n57;
        public GImage n58;
        public GImage n48;
        public GButton close_btn;
        public GLoader quality_bg;
        public GLoader img_icon;
        public GLoader img_quality;
        public GTextField txt_name;
        public GTextField txt_des;
        public GTextField txt_ownNum;
        public GTextField charmNum;
        public GImage n52;
        public GTextField sub_title;
        public GList list_gainway;
        public GGroup n60;
        public greenPicBtn buy_btn;
        public const string URL = "ui://argzn455hstt1yjp83i";

        public static dress_detail_view CreateInstance()
        {
            return (dress_detail_view)UIPackage.CreateObject("fun_Dress", "dress_detail_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n50 = (GImage)GetChildAt(1);
            n57 = (GImage)GetChildAt(2);
            n58 = (GImage)GetChildAt(3);
            n48 = (GImage)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
            quality_bg = (GLoader)GetChildAt(6);
            img_icon = (GLoader)GetChildAt(7);
            img_quality = (GLoader)GetChildAt(8);
            txt_name = (GTextField)GetChildAt(9);
            txt_des = (GTextField)GetChildAt(10);
            txt_ownNum = (GTextField)GetChildAt(11);
            charmNum = (GTextField)GetChildAt(12);
            n52 = (GImage)GetChildAt(13);
            sub_title = (GTextField)GetChildAt(14);
            list_gainway = (GList)GetChildAt(15);
            n60 = (GGroup)GetChildAt(16);
            buy_btn = (greenPicBtn)GetChildAt(17);
        }
    }
}