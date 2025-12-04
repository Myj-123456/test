/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual
{
    public partial class ScientStar : GComponent
    {
        public Controller status;
        public GImage n0;
        public GImage n1;
        public GImage n2;
        public const string URL = "ui://6q8q1ai6r7kk1yjp7mq";

        public static ScientStar CreateInstance()
        {
            return (ScientStar)UIPackage.CreateObject("fun_CultivationManual", "ScientStar");
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