/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class contractPreviewRootBtn : GButton
    {
        public Controller button;
        public GImage n0;
        public const string URL = "ui://w3ox9yltin5z1yjp883";

        public static contractPreviewRootBtn CreateInstance()
        {
            return (contractPreviewRootBtn)UIPackage.CreateObject("fun_Recharge", "contractPreviewRootBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
        }
    }
}