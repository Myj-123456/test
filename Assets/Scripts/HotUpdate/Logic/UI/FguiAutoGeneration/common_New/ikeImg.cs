/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class ikeImg : GComponent
    {
        public Controller type;
        public GLoader loader_vase;
        public GLoader loader_succulent;
        public GLoader loader_3;
        public GLoader loader_2;
        public GLoader loader_1;
        public GTextField n5;
        public GGroup n6;
        public const string URL = "ui://mjiw43v9nd7j1yjp7rv";

        public static ikeImg CreateInstance()
        {
            return (ikeImg)UIPackage.CreateObject("common_New", "ikeImg");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            loader_vase = (GLoader)GetChildAt(0);
            loader_succulent = (GLoader)GetChildAt(1);
            loader_3 = (GLoader)GetChildAt(2);
            loader_2 = (GLoader)GetChildAt(3);
            loader_1 = (GLoader)GetChildAt(4);
            n5 = (GTextField)GetChildAt(5);
            n6 = (GGroup)GetChildAt(6);
        }
    }
}