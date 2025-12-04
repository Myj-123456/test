/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Plot
{
    public partial class reward_item : GComponent
    {
        public GLoader bg;
        public GLoader pic;
        public GTextField numLab;
        public GTextField nameLab;
        public const string URL = "ui://vucpfjl811rnu1yjp83m";

        public static reward_item CreateInstance()
        {
            return (reward_item)UIPackage.CreateObject("fun_Plot", "reward_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            numLab = (GTextField)GetChildAt(2);
            nameLab = (GTextField)GetChildAt(3);
        }
    }
}