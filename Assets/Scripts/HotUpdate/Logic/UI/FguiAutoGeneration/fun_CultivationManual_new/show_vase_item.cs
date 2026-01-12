/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class show_vase_item : GComponent
    {
        public Controller status;
        public GImage n6;
        public GLoader rareImg;
        public GLoader img;
        public const string URL = "ui://ekoic0wrq47x1yjp7ww";

        public static show_vase_item CreateInstance()
        {
            return (show_vase_item)UIPackage.CreateObject("fun_CultivationManual_new", "show_vase_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n6 = (GImage)GetChildAt(0);
            rareImg = (GLoader)GetChildAt(1);
            img = (GLoader)GetChildAt(2);
        }
    }
}