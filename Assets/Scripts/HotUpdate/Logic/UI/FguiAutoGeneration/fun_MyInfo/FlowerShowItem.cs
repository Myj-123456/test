/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class FlowerShowItem : GComponent
    {
        public Controller status;
        public GImage n4;
        public GLoader bg;
        public GLoader flowerImg;
        public GImage n2;
        public GImage n3;
        public const string URL = "ui://ehkqmfbpiust15";

        public static FlowerShowItem CreateInstance()
        {
            return (FlowerShowItem)UIPackage.CreateObject("fun_MyInfo", "FlowerShowItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            flowerImg = (GLoader)GetChildAt(2);
            n2 = (GImage)GetChildAt(3);
            n3 = (GImage)GetChildAt(4);
        }
    }
}