/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_plant
{
    public partial class guild_plant_item : GComponent
    {
        public Controller status;
        public guild_plant_cell item;
        public const string URL = "ui://qfpad3q0tewh5";

        public static guild_plant_item CreateInstance()
        {
            return (guild_plant_item)UIPackage.CreateObject("fun_Guild_plant", "guild_plant_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            item = (guild_plant_cell)GetChildAt(0);
        }
    }
}