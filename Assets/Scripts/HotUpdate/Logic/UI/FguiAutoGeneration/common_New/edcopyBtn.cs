/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class edcopyBtn : GButton
    {
        public Controller type;
        public GImage n8;
        public GImage n9;
        public const string URL = "ui://mjiw43v9i64u1yjp7sv";

        public static edcopyBtn CreateInstance()
        {
            return (edcopyBtn)UIPackage.CreateObject("common_New", "edcopyBtn");
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