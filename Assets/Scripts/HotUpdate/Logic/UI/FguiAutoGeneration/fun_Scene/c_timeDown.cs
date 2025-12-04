/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class c_timeDown : GComponent
    {
        public GImage n0;
        public GImage n3;
        public handle_pgs pgs;
        public const string URL = "ui://dpcxz2finwd51j";

        public static c_timeDown CreateInstance()
        {
            return (c_timeDown)UIPackage.CreateObject("fun_Scene", "c_timeDown");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            n3 = (GImage)GetChildAt(1);
            pgs = (handle_pgs)GetChildAt(2);
        }
    }
}