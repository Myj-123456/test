/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class greenPicBtn : GButton
    {
        public GImage n6;
        public GLoader pic;
        public GTextField titleLab;
        public const string URL = "ui://argzn455hstt1yjp83v";

        public static greenPicBtn CreateInstance()
        {
            return (greenPicBtn)UIPackage.CreateObject("fun_Dress", "greenPicBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}