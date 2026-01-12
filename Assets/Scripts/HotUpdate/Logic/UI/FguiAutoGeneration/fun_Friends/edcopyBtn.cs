/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class edcopyBtn : GButton
    {
        public Controller type;
        public GImage n8;
        public GImage n9;
        public const string URL = "ui://fteyf9nzfbvs1yjp7vu";

        public static edcopyBtn CreateInstance()
        {
            return (edcopyBtn)UIPackage.CreateObject("fun_Friends", "edcopyBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n8 = (GImage)GetChildAt(0);
            n9 = (GImage)GetChildAt(1);
        }
    }
}