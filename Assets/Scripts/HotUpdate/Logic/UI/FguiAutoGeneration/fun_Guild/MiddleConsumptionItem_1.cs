/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class MiddleConsumptionItem_1 : GComponent
    {
        public GLoader iconLoader;
        public GTextField numTxt;
        public const string URL = "ui://6wv667gugtac1ayr89a";

        public static MiddleConsumptionItem_1 CreateInstance()
        {
            return (MiddleConsumptionItem_1)UIPackage.CreateObject("fun_Guild", "MiddleConsumptionItem_1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            iconLoader = (GLoader)GetChildAt(0);
            numTxt = (GTextField)GetChildAt(1);
        }
    }
}