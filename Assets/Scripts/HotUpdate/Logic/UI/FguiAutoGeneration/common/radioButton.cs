/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class radioButton : GComponent
    {
        public Controller selStatus;
        public GImage n2;
        public GImage selImg;
        public const string URL = "ui://6bdpq80ktosm1yjp7s1";

        public static radioButton CreateInstance()
        {
            return (radioButton)UIPackage.CreateObject("common", "radioButton");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            selStatus = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
            selImg = (GImage)GetChildAt(1);
        }
    }
}