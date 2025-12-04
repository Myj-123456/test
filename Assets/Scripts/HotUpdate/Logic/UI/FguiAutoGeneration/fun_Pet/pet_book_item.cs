/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class pet_book_item : GComponent
    {
        public Controller status;
        public GLoader bg;
        public GLoader pic;
        public GImage show_lv;
        public GTextField nameLab;
        public GImage n3;
        public GTextField levelLab;
        public GList stars;
        public GGroup n9;
        public GTextField tipLab;
        public GLoader shard_img;
        public probar pro;
        public GRichTextField proLab;
        public GGroup n14;
        public GImage n16;
        public const string URL = "ui://o7kmyysdx92mr";

        public static pet_book_item CreateInstance()
        {
            return (pet_book_item)UIPackage.CreateObject("fun_Pet", "pet_book_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            show_lv = (GImage)GetChildAt(2);
            nameLab = (GTextField)GetChildAt(3);
            n3 = (GImage)GetChildAt(4);
            levelLab = (GTextField)GetChildAt(5);
            stars = (GList)GetChildAt(6);
            n9 = (GGroup)GetChildAt(7);
            tipLab = (GTextField)GetChildAt(8);
            shard_img = (GLoader)GetChildAt(9);
            pro = (probar)GetChildAt(10);
            proLab = (GRichTextField)GetChildAt(11);
            n14 = (GGroup)GetChildAt(12);
            n16 = (GImage)GetChildAt(13);
        }
    }
}