/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class blue_video_btn : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public GImage n7;
        public const string URL = "ui://mjiw43v9u25n1yjp84j";

        public static blue_video_btn CreateInstance()
        {
            return (blue_video_btn)UIPackage.CreateObject("common_New", "blue_video_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            n7 = (GImage)GetChildAt(2);
        }
    }
}