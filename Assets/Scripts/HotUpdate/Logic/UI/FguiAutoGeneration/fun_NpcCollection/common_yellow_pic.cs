/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_NpcCollection
{
    public partial class common_yellow_pic : GButton
    {
        public GImage n9;
        public GLoader pic;
        public GTextField titleLab;
        public const string URL = "ui://ydpeia1vfbvs1t";

        public static common_yellow_pic CreateInstance()
        {
            return (common_yellow_pic)UIPackage.CreateObject("fun_NpcCollection", "common_yellow_pic");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n9 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}