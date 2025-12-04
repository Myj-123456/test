/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class robbedHead_big : GComponent
    {
        public GLoader img_head;
        public GComponent picFrame;
        public GImage n12;
        public GTextField txt_lv;
        public GGroup g_evel;
        public const string URL = "ui://6bdpq80kzt55plf";

        public static robbedHead_big CreateInstance()
        {
            return (robbedHead_big)UIPackage.CreateObject("common", "robbedHead_big");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            img_head = (GLoader)GetChildAt(0);
            picFrame = (GComponent)GetChildAt(1);
            n12 = (GImage)GetChildAt(2);
            txt_lv = (GTextField)GetChildAt(3);
            g_evel = (GGroup)GetChildAt(4);
        }
    }
}