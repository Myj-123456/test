/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_LevelUp
{
    public partial class newly_get_flower : GComponent
    {
        public Controller avoidSeedBreed;
        public Controller c1;
        public GLoader3D spine;
        public GImage n70;
        public GLoader pic;
        public GLoader flowerLoader;
        public GTextField flowerNameTxt;
        public GTextField flowerSayText;
        public GButton goBreedBtn;
        public const string URL = "ui://zxpmd1qwbuzno6p";

        public static newly_get_flower CreateInstance()
        {
            return (newly_get_flower)UIPackage.CreateObject("fun_LevelUp", "newly_get_flower");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            avoidSeedBreed = GetControllerAt(0);
            c1 = GetControllerAt(1);
            spine = (GLoader3D)GetChildAt(0);
            n70 = (GImage)GetChildAt(1);
            pic = (GLoader)GetChildAt(2);
            flowerLoader = (GLoader)GetChildAt(3);
            flowerNameTxt = (GTextField)GetChildAt(4);
            flowerSayText = (GTextField)GetChildAt(5);
            goBreedBtn = (GButton)GetChildAt(6);
        }
    }
}