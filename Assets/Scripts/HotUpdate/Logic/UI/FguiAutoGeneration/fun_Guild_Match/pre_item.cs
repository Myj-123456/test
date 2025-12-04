/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class pre_item : GComponent
    {
        public GLoader pic;
        public GImage n2;
        public GTextField numLab;
        public const string URL = "ui://qefze8qir0nz2w";

        public static pre_item CreateInstance()
        {
            return (pre_item)UIPackage.CreateObject("fun_Guild_Match", "pre_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            pic = (GLoader)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            numLab = (GTextField)GetChildAt(2);
        }
    }
}