/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class watering : GProgressBar
    {
        public GImage n0;
        public GImage bar;
        public GImage n2;
        public GTextField lable_txt;
        public const string URL = "ui://dpcxz2fikb8v16";

        public static watering CreateInstance()
        {
            return (watering)UIPackage.CreateObject("fun_Scene", "watering");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
            lable_txt = (GTextField)GetChildAt(3);
        }
    }
}