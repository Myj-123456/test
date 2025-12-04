/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class langImg : GComponent
    {
        public GLoader titleLoader;
        public GTextField n288;
        public const string URL = "ui://6bdpq80knwgi1yjp7qo";

        public static langImg CreateInstance()
        {
            return (langImg)UIPackage.CreateObject("common", "langImg");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            titleLoader = (GLoader)GetChildAt(0);
            n288 = (GTextField)GetChildAt(1);
        }
    }
}