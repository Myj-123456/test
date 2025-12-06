/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class common_add : GButton
    {
        public GImage n1;
        public const string URL = "ui://mjiw43v9kelj1yjp84u";

        public static common_add CreateInstance()
        {
            return (common_add)UIPackage.CreateObject("common_New", "common_add");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
        }
    }
}