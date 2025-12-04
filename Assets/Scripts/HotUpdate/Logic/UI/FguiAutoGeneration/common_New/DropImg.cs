/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class DropImg : GComponent
    {
        public GLoader res;
        public const string URL = "ui://mjiw43v9q9bj1yjp7s7";

        public static DropImg CreateInstance()
        {
            return (DropImg)UIPackage.CreateObject("common_New", "DropImg");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            res = (GLoader)GetChildAt(0);
        }
    }
}