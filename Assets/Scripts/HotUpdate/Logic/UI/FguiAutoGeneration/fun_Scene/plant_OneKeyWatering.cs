/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class plant_OneKeyWatering : GComponent
    {
        public btn_oneKeyWatering btn_oneKeyWatering;
        public btn_watering btn_watering;
        public const string URL = "ui://dpcxz2fip4ts2e";

        public static plant_OneKeyWatering CreateInstance()
        {
            return (plant_OneKeyWatering)UIPackage.CreateObject("fun_Scene", "plant_OneKeyWatering");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            btn_oneKeyWatering = (btn_oneKeyWatering)GetChildAt(0);
            btn_watering = (btn_watering)GetChildAt(1);
        }
    }
}