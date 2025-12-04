/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Battle
{
    public partial class BgView : GComponent
    {
        public GImage map;
        public GGraph n1;
        public const string URL = "ui://z1b78orpohj62x";

        public static BgView CreateInstance()
        {
            return (BgView)UIPackage.CreateObject("fun_Battle", "BgView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            map = (GImage)GetChildAt(0);
            n1 = (GGraph)GetChildAt(1);
        }
    }
}