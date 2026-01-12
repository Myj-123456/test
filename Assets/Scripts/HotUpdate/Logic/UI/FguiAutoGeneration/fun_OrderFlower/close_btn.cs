/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_OrderFlower
{
    public partial class close_btn : GButton
    {
        public GImage n3;
        public const string URL = "ui://ypcg4u8810vyr1yjp7sl";

        public static close_btn CreateInstance()
        {
            return (close_btn)UIPackage.CreateObject("fun_OrderFlower", "close_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
        }
    }
}