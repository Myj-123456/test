/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class bargin_btn : GComponent
    {
        public GLoader3D spine;
        public const string URL = "ui://qz6135j3oi771yjp809";

        public static bargin_btn CreateInstance()
        {
            return (bargin_btn)UIPackage.CreateObject("fun_Guild_New", "bargin_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            spine = (GLoader3D)GetChildAt(0);
        }
    }
}