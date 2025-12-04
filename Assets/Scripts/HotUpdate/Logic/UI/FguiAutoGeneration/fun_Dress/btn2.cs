/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class btn2 : GButton
    {
        public GImage n94;
        public const string URL = "ui://argzn455hstt1yjp836";

        public static btn2 CreateInstance()
        {
            return (btn2)UIPackage.CreateObject("fun_Dress", "btn2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n94 = (GImage)GetChildAt(0);
        }
    }
}