/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_donate_pro_cell : GComponent
    {
        public Controller type;
        public GImage n41;
        public GImage n40;
        public GImage n42;
        public GImage n43;
        public GImage n44;
        public GImage n45;
        public GImage n46;
        public GImage n47;
        public GGraph getBtn;
        public const string URL = "ui://qz6135j3s62s1yjp7z0";

        public static guild_donate_pro_cell CreateInstance()
        {
            return (guild_donate_pro_cell)UIPackage.CreateObject("fun_Guild_New", "guild_donate_pro_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n41 = (GImage)GetChildAt(0);
            n40 = (GImage)GetChildAt(1);
            n42 = (GImage)GetChildAt(2);
            n43 = (GImage)GetChildAt(3);
            n44 = (GImage)GetChildAt(4);
            n45 = (GImage)GetChildAt(5);
            n46 = (GImage)GetChildAt(6);
            n47 = (GImage)GetChildAt(7);
            getBtn = (GGraph)GetChildAt(8);
        }
    }
}