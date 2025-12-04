/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Florist
{
    public partial class reward_item : GComponent
    {
        public Controller status;
        public GLoader bg;
        public GLoader pic;
        public GTextField numLab;
        public GTextField nameLab;
        public const string URL = "ui://nj16dzxym3gh4";

        public static reward_item CreateInstance()
        {
            return (reward_item)UIPackage.CreateObject("fun_Florist", "reward_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            numLab = (GTextField)GetChildAt(2);
            nameLab = (GTextField)GetChildAt(3);
        }
    }
}