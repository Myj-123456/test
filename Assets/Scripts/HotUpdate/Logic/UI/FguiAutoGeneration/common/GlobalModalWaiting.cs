/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class GlobalModalWaiting : GComponent
    {
        public GImage n6;
        public Transition t0;
        public const string URL = "ui://6bdpq80kqkbj1yjp7m5";

        public static GlobalModalWaiting CreateInstance()
        {
            return (GlobalModalWaiting)UIPackage.CreateObject("common", "GlobalModalWaiting");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            t0 = GetTransitionAt(0);
        }
    }
}