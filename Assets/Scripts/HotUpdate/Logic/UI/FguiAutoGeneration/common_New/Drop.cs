/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class Drop : GComponent
    {
        public GLoader res;
        public GTextField num;
        public const string URL = "ui://mjiw43v9u0i31yjp7s4";

        public static Drop CreateInstance()
        {
            return (Drop)UIPackage.CreateObject("common_New", "Drop");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            res = (GLoader)GetChildAt(0);
            num = (GTextField)GetChildAt(1);
        }
    }
}