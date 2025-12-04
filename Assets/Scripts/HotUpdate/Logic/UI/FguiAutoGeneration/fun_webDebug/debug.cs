/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_webDebug
{
    public partial class debug : GComponent
    {
        public GImage n85;
        public container container;
        public GButton close_btn;
        public const string URL = "ui://658koyris5pajp";

        public static debug CreateInstance()
        {
            return (debug)UIPackage.CreateObject("fun_webDebug", "debug");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n85 = (GImage)GetChildAt(0);
            container = (container)GetChildAt(1);
            close_btn = (GButton)GetChildAt(2);
        }
    }
}