/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class blueBtn : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://6bdpq80kjpt91yjp7m9";

        public static blueBtn CreateInstance()
        {
            return (blueBtn)UIPackage.CreateObject("common", "blueBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}