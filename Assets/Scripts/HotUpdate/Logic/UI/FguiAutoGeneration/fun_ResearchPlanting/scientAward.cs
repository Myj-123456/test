/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_ResearchPlanting
{
    public partial class scientAward : GComponent
    {
        public GLoader img_icon;
        public GTextField lb_count;
        public const string URL = "ui://vhii0yjunqrs4";

        public static scientAward CreateInstance()
        {
            return (scientAward)UIPackage.CreateObject("fun_ResearchPlanting", "scientAward");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            img_icon = (GLoader)GetChildAt(0);
            lb_count = (GTextField)GetChildAt(1);
        }
    }
}