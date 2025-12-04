/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerArrangement
{
    public partial class tweenCom : GComponent
    {
        public flowerList flower;
        public GImage n2;
        public Transition left;
        public Transition right;
        public const string URL = "ui://6kofjj39q9bj1yjp7nd";

        public static tweenCom CreateInstance()
        {
            return (tweenCom)UIPackage.CreateObject("fun_FlowerArrangement", "tweenCom");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            flower = (flowerList)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            left = GetTransitionAt(0);
            right = GetTransitionAt(1);
        }
    }
}