/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class btn1 : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://44kfvb3rm3gh4l";

        public static btn1 CreateInstance()
        {
            return (btn1)UIPackage.CreateObject("fun_FlowerGold", "btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}