/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class love_list_item : GComponent
    {
        public GLoader bg;
        public GLoader pic;
        public GTextField nameLab;
        public const string URL = "ui://44kfvb3rm3gh45";

        public static love_list_item CreateInstance()
        {
            return (love_list_item)UIPackage.CreateObject("fun_FlowerGold", "love_list_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            nameLab = (GTextField)GetChildAt(2);
        }
    }
}