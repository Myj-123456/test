/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class handbookFlowerExhibit : GComponent
    {
        public GLoader potImg;
        public GLoader flowerImg;
        public GLoader flowerImg1;
        public GLoader3D spine;
        public const string URL = "ui://ekoic0wri64u1yjp7ms";

        public static handbookFlowerExhibit CreateInstance()
        {
            return (handbookFlowerExhibit)UIPackage.CreateObject("fun_CultivationManual_new", "handbookFlowerExhibit");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            potImg = (GLoader)GetChildAt(0);
            flowerImg = (GLoader)GetChildAt(1);
            flowerImg1 = (GLoader)GetChildAt(2);
            spine = (GLoader3D)GetChildAt(3);
        }
    }
}