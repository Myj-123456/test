/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Contract
{
    public partial class reward_item1 : GComponent
    {
        public GLoader bg;
        public GLoader pic;
        public GTextField countLab;
        public const string URL = "ui://ju8ssus8kkb11ayr82r";

        public static reward_item1 CreateInstance()
        {
            return (reward_item1)UIPackage.CreateObject("fun_Contract", "reward_item1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            countLab = (GTextField)GetChildAt(2);
        }
    }
}