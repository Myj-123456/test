/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class change_btn : GComponent
    {
        public GImage n0;
        public const string URL = "ui://ekoic0wrjfk51yjp7xx";

        public static change_btn CreateInstance()
        {
            return (change_btn)UIPackage.CreateObject("fun_CultivationManual_new", "change_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
        }
    }
}