/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class one_key_btn : GButton
    {
        public Controller button;
        public GImage n2;
        public const string URL = "ui://fteyf9nzybxr1yjp7uf";

        public static one_key_btn CreateInstance()
        {
            return (one_key_btn)UIPackage.CreateObject("fun_Friends", "one_key_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
        }
    }
}