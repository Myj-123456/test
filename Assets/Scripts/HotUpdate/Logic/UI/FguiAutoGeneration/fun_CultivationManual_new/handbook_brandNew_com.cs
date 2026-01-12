/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class handbook_brandNew_com : GComponent
    {
        public Controller status;
        public handbook_brandNew_item item;
        public const string URL = "ui://ekoic0wruou61yjp890";

        public static handbook_brandNew_com CreateInstance()
        {
            return (handbook_brandNew_com)UIPackage.CreateObject("fun_CultivationManual_new", "handbook_brandNew_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            item = (handbook_brandNew_item)GetChildAt(0);
        }
    }
}