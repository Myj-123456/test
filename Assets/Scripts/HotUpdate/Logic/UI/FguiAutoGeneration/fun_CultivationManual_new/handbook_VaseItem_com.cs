/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class handbook_VaseItem_com : GComponent
    {
        public Controller status;
        public handbook_VaseItem item;
        public const string URL = "ui://ekoic0wruou61yjp892";

        public static handbook_VaseItem_com CreateInstance()
        {
            return (handbook_VaseItem_com)UIPackage.CreateObject("fun_CultivationManual_new", "handbook_VaseItem_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            item = (handbook_VaseItem)GetChildAt(0);
        }
    }
}