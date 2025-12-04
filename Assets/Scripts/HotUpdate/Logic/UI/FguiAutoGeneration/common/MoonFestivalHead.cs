/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class MoonFestivalHead : GComponent
    {
        public GGraph n8;
        public GLoader pic;
        public const string URL = "ui://6bdpq80knwgi1yjp7qt";

        public static MoonFestivalHead CreateInstance()
        {
            return (MoonFestivalHead)UIPackage.CreateObject("common", "MoonFestivalHead");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n8 = (GGraph)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
        }
    }
}