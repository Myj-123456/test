/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class pet_content : GComponent
    {
        public pet_main_view content;
        public const string URL = "ui://o7kmyysdm3gh1yjp810";

        public static pet_content CreateInstance()
        {
            return (pet_content)UIPackage.CreateObject("fun_Pet", "pet_content");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            content = (pet_main_view)GetChildAt(0);
        }
    }
}