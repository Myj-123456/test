/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class info_change_view : GComponent
    {
        public Controller tab;
        public GImage n2;
        public GLoader bg;
        public GImage n3;
        public GImage n4;
        public GImage n16;
        public GImage n17;
        public GImage n12;
        public GImage n13;
        public title_view title_view;
        public head_view head_view;
        public frame_view frame_view;
        public pageBtn2 head_btn;
        public pageBtn2 head_frame_btn;
        public pageBtn2 title_btn;
        public GButton close_btn;
        public const string URL = "ui://ehkqmfbpj9p61yjp7yb";

        public static info_change_view CreateInstance()
        {
            return (info_change_view)UIPackage.CreateObject("fun_MyInfo", "info_change_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            n4 = (GImage)GetChildAt(3);
            n16 = (GImage)GetChildAt(4);
            n17 = (GImage)GetChildAt(5);
            n12 = (GImage)GetChildAt(6);
            n13 = (GImage)GetChildAt(7);
            title_view = (title_view)GetChildAt(8);
            head_view = (head_view)GetChildAt(9);
            frame_view = (frame_view)GetChildAt(10);
            head_btn = (pageBtn2)GetChildAt(11);
            head_frame_btn = (pageBtn2)GetChildAt(12);
            title_btn = (pageBtn2)GetChildAt(13);
            close_btn = (GButton)GetChildAt(14);
        }
    }
}