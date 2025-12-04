/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class MoonFestivalHead : GComponent
    {
        public GGraph n8;
        public GLoader pic;
        public const string URL = "ui://mjiw43v9e5f51yjp7rw";

        public static MoonFestivalHead CreateInstance()
        {
            return (MoonFestivalHead)UIPackage.CreateObject("common_New", "MoonFestivalHead");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n8 = (GGraph)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
        }
    }
}