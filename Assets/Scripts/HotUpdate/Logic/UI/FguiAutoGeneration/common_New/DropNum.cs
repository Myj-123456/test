/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class DropNum : GComponent
    {
        public GTextField num;
        public const string URL = "ui://mjiw43v9q9bj1yjp7u6";

        public static DropNum CreateInstance()
        {
            return (DropNum)UIPackage.CreateObject("common_New", "DropNum");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            num = (GTextField)GetChildAt(0);
        }
    }
}