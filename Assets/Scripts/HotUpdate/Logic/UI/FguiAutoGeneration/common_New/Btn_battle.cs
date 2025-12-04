/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class Btn_battle : GButton
    {
        public Controller button;
        public GImage n4;
        public GTextField titleLab;
        public const string URL = "ui://mjiw43v9phda1yjp7va";

        public static Btn_battle CreateInstance()
        {
            return (Btn_battle)UIPackage.CreateObject("common_New", "Btn_battle");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}