/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_ResearchPlanting
{
    public partial class ScientStar : GComponent
    {
        public Controller status;
        public GImage n0;
        public GImage n1;
        public GImage n2;
        public const string URL = "ui://vhii0yjunqrs1yjp7ve";

        public static ScientStar CreateInstance()
        {
            return (ScientStar)UIPackage.CreateObject("fun_ResearchPlanting", "ScientStar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
        }
    }
}