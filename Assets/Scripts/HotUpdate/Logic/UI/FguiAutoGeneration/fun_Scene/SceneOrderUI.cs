/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class SceneOrderUI : GComponent
    {
        public SceneOrderItem n0;
        public SceneOrderItem n1;
        public SceneOrderItem n2;
        public SceneOrderItem n3;
        public SceneOrderItem n4;
        public SceneOrderItem n5;
        public const string URL = "ui://dpcxz2fildq98";

        public static SceneOrderUI CreateInstance()
        {
            return (SceneOrderUI)UIPackage.CreateObject("fun_Scene", "SceneOrderUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (SceneOrderItem)GetChildAt(0);
            n1 = (SceneOrderItem)GetChildAt(1);
            n2 = (SceneOrderItem)GetChildAt(2);
            n3 = (SceneOrderItem)GetChildAt(3);
            n4 = (SceneOrderItem)GetChildAt(4);
            n5 = (SceneOrderItem)GetChildAt(5);
        }
    }
}