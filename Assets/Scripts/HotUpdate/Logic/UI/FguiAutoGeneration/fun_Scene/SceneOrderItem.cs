/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class SceneOrderItem : GComponent
    {
        public Controller c1;
        public GImage n0;
        public GImage n1;
        public GImage n2;
        public const string URL = "ui://dpcxz2fildq99";

        public static SceneOrderItem CreateInstance()
        {
            return (SceneOrderItem)UIPackage.CreateObject("fun_Scene", "SceneOrderItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
        }
    }
}