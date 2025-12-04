/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual
{
    public partial class handbookFlowerExhibit : GComponent
    {
        public GLoader potImg;
        public GLoader flowerImg;
        public GLoader flowerImg1;
        public const string URL = "ui://6q8q1ai6ez0gjtwqcc";

        public static handbookFlowerExhibit CreateInstance()
        {
            return (handbookFlowerExhibit)UIPackage.CreateObject("fun_CultivationManual", "handbookFlowerExhibit");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            potImg = (GLoader)GetChildAt(0);
            flowerImg = (GLoader)GetChildAt(1);
            flowerImg1 = (GLoader)GetChildAt(2);
        }
    }
}