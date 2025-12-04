/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_BoonFlower
{
    public partial class boonNewFlowerItem : GComponent
    {
        public Controller states;
        public GImage faceBg;
        public GTextField nameTxt;
        public GLoader flowerImg;
        public GImage n6;
        public const string URL = "ui://fsc3a856e0lm8";

        public static boonNewFlowerItem CreateInstance()
        {
            return (boonNewFlowerItem)UIPackage.CreateObject("fun_BoonFlower", "boonNewFlowerItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            states = GetControllerAt(0);
            faceBg = (GImage)GetChildAt(0);
            nameTxt = (GTextField)GetChildAt(1);
            flowerImg = (GLoader)GetChildAt(2);
            n6 = (GImage)GetChildAt(3);
        }
    }
}