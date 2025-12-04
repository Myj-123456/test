/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class left : GComponent
    {
        public GImage n0;
        public Transition moveLeft;
        public const string URL = "ui://ekoic0wru0i31yjp7u0";

        public static left CreateInstance()
        {
            return (left)UIPackage.CreateObject("fun_CultivationManual_new", "left");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            moveLeft = GetTransitionAt(0);
        }
    }
}