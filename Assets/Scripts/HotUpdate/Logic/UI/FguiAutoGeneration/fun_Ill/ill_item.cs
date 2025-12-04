/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Ill
{
    public partial class ill_item : GComponent
    {
        public Controller type;
        public GLoader bg;
        public GLoader flower_img;
        public GLoader vase_img;
        public GLoader dress_img;
        public GLoader florist_img;
        public GLoader pet_img;
        public GLoader fairy_img;
        public GImage redPoint;
        public GTextField nameLab;
        public const string URL = "ui://p737delgcs1m1";

        public static ill_item CreateInstance()
        {
            return (ill_item)UIPackage.CreateObject("fun_Ill", "ill_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            flower_img = (GLoader)GetChildAt(1);
            vase_img = (GLoader)GetChildAt(2);
            dress_img = (GLoader)GetChildAt(3);
            florist_img = (GLoader)GetChildAt(4);
            pet_img = (GLoader)GetChildAt(5);
            fairy_img = (GLoader)GetChildAt(6);
            redPoint = (GImage)GetChildAt(7);
            nameLab = (GTextField)GetChildAt(8);
        }
    }
}