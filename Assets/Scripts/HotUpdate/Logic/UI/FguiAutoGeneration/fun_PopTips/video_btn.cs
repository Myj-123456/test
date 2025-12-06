/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_PopTips
{
    public partial class video_btn : GButton
    {
        public GImage n10;
        public GTextField titleLab;
        public GImage n7;
        public const string URL = "ui://vhcdvi5tu25n1yjp84m";

        public static video_btn CreateInstance()
        {
            return (video_btn)UIPackage.CreateObject("fun_PopTips", "video_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n10 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            n7 = (GImage)GetChildAt(2);
        }
    }
}