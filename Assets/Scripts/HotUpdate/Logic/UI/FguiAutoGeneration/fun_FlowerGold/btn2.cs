/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class btn2 : GButton
    {
        public GImage n7;
        public const string URL = "ui://44kfvb3rm3gh4n";

        public static btn2 CreateInstance()
        {
            return (btn2)UIPackage.CreateObject("fun_FlowerGold", "btn2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n7 = (GImage)GetChildAt(0);
        }
    }
}