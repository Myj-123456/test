/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class fetters_cell : GComponent
    {
        public Controller unlock;
        public GLoader bg;
        public GLoader pic;
        public GImage n1;
        public const string URL = "ui://44kfvb3rv5lj1yjp81n";

        public static fetters_cell CreateInstance()
        {
            return (fetters_cell)UIPackage.CreateObject("fun_FlowerGold", "fetters_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            unlock = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            n1 = (GImage)GetChildAt(2);
        }
    }
}