/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class water_video_view : GComponent
    {
        public GLoader bg;
        public GLoader bg1;
        public GImage n3;
        public GImage n4;
        public GImage n5;
        public GImage n6;
        public GImage n7;
        public GImage n8;
        public GButton close_btn;
        public GButton video_btn;
        public GButton get_btn;
        public GTextField videoLab;
        public GTextField numLab;
        public const string URL = "ui://dpcxz2fiv01m33";

        public static water_video_view CreateInstance()
        {
            return (water_video_view)UIPackage.CreateObject("fun_Scene", "water_video_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            bg1 = (GLoader)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            n4 = (GImage)GetChildAt(3);
            n5 = (GImage)GetChildAt(4);
            n6 = (GImage)GetChildAt(5);
            n7 = (GImage)GetChildAt(6);
            n8 = (GImage)GetChildAt(7);
            close_btn = (GButton)GetChildAt(8);
            video_btn = (GButton)GetChildAt(9);
            get_btn = (GButton)GetChildAt(10);
            videoLab = (GTextField)GetChildAt(11);
            numLab = (GTextField)GetChildAt(12);
        }
    }
}