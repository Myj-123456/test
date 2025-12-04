/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guide
{
    public partial class GuideHand : GComponent
    {
        public GImage quan;
        public GImage hand;
        public Transition t1;
        public const string URL = "ui://miytzucx1003pq";

        public static GuideHand CreateInstance()
        {
            return (GuideHand)UIPackage.CreateObject("fun_Guide", "GuideHand");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            quan = (GImage)GetChildAt(0);
            hand = (GImage)GetChildAt(1);
            t1 = GetTransitionAt(0);
        }
    }
}