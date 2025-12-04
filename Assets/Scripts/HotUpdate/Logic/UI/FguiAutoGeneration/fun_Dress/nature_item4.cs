/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class nature_item4 : GComponent
    {
        public Controller unlock;
        public GImage n13;
        public GTextField decLab;
        public const string URL = "ui://argzn455hstt1yjp83s";

        public static nature_item4 CreateInstance()
        {
            return (nature_item4)UIPackage.CreateObject("fun_Dress", "nature_item4");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            unlock = GetControllerAt(0);
            n13 = (GImage)GetChildAt(0);
            decLab = (GTextField)GetChildAt(1);
        }
    }
}