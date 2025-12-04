/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class nullBtn : GButton
    {
        public Controller button;
        public GGraph n5;
        public const string URL = "ui://6bdpq80knwgi1yjp7qp";

        public static nullBtn CreateInstance()
        {
            return (nullBtn)UIPackage.CreateObject("common", "nullBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n5 = (GGraph)GetChildAt(0);
        }
    }
}