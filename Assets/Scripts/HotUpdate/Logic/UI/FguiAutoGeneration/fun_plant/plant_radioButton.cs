/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_plant
{
    public partial class plant_radioButton : GComponent
    {
        public Controller selStatus;
        public GImage n2;
        public GImage selImg;
        public const string URL = "ui://4905g7p7owcx15";

        public static plant_radioButton CreateInstance()
        {
            return (plant_radioButton)UIPackage.CreateObject("fun_plant", "plant_radioButton");
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