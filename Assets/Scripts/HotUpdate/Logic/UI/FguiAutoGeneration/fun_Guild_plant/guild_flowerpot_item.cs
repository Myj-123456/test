/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_plant
{
    public partial class guild_flowerpot_item : GComponent
    {
        public Controller status;
        public GImage n64;
        public GImage n65;
        public GImage n66;
        public GLoader img;
        public const string URL = "ui://qfpad3q0tewh1yjp7zl";

        public static guild_flowerpot_item CreateInstance()
        {
            return (guild_flowerpot_item)UIPackage.CreateObject("fun_Guild_plant", "guild_flowerpot_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n64 = (GImage)GetChildAt(0);
            n65 = (GImage)GetChildAt(1);
            n66 = (GImage)GetChildAt(2);
            img = (GLoader)GetChildAt(3);
        }
    }
}