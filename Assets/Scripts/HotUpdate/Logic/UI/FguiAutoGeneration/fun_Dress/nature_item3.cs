/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class nature_item3 : GComponent
    {
        public Controller unlock;
        public probar1 pro;
        public GLoader rare_img;
        public GTextField proLab;
        public const string URL = "ui://argzn455hstt1yjp83n";

        public static nature_item3 CreateInstance()
        {
            return (nature_item3)UIPackage.CreateObject("fun_Dress", "nature_item3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            unlock = GetControllerAt(0);
            pro = (probar1)GetChildAt(0);
            rare_img = (GLoader)GetChildAt(1);
            proLab = (GTextField)GetChildAt(2);
        }
    }
}