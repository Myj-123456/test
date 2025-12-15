/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class common_right : GButton
    {
        public GImage n2;
        public const string URL = "ui://mjiw43v9dhbs1yjp85x";

        public static common_right CreateInstance()
        {
            return (common_right)UIPackage.CreateObject("common_New", "common_right");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
        }
    }
}