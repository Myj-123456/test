/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class cloth_view : GComponent
    {
        public GLoader bg;
        public GLoader3D loader_heroAvatar;
        public GLoader3D spine;
        public GButton btn_confirm;
        public GImage n5;
        public GImage n8;
        public GList list_part;
        public GList list_filter;
        public GTextField txt_noDress;
        public btn photo_btn;
        public btn back_btn;
        public btn1 last_btn;
        public btn1 init_btn;
        public GGroup n17;
        public const string URL = "ui://argzn455v5lj1yjp81q";

        public static cloth_view CreateInstance()
        {
            return (cloth_view)UIPackage.CreateObject("fun_Dress", "cloth_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            loader_heroAvatar = (GLoader3D)GetChildAt(1);
            spine = (GLoader3D)GetChildAt(2);
            btn_confirm = (GButton)GetChildAt(3);
            n5 = (GImage)GetChildAt(4);
            n8 = (GImage)GetChildAt(5);
            list_part = (GList)GetChildAt(6);
            list_filter = (GList)GetChildAt(7);
            txt_noDress = (GTextField)GetChildAt(8);
            photo_btn = (btn)GetChildAt(9);
            back_btn = (btn)GetChildAt(10);
            last_btn = (btn1)GetChildAt(11);
            init_btn = (btn1)GetChildAt(12);
            n17 = (GGroup)GetChildAt(13);
        }
    }
}