
using Medicside.UriMeasure.Data.Morphology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Data.DataHelper
{
    class MorphologyDataHelper
    {
        public static List<MorphologyTestItem> GetMorphologyTestItems()
        {
            MorphologyTestType rbcType = new MorphologyTestType("RBC", "红细胞");
            var wbcType = new MorphologyTestType("WBC", "白细胞");
            var ecType = new MorphologyTestType("EC", "上皮细胞");
            var hyalType = new MorphologyTestType("HYAL", "透明管型");
            var unccType = new MorphologyTestType("UNCC", "病理管型");
            var bactType = new MorphologyTestType("BACT", "细菌");
            var bystType = new MorphologyTestType("BYST", "酵母菌");
            var xtacType = new MorphologyTestType("X'TAC", "结晶");

            MorphologyTestGradeItem gradeItem1 = new MorphologyTestGradeItem();
            gradeItem1.GradeName = "NEG";
            gradeItem1.Value = "";

            MorphologyTestGradeItem gradeItem2 = new MorphologyTestGradeItem();
            gradeItem2.GradeName = "+";
            gradeItem2.Value = "20";

            MorphologyTestGradeItem gradeItem3 = new MorphologyTestGradeItem();
            gradeItem3.GradeName = "++";
            gradeItem3.Value = "40";

            MorphologyTestGradeItem gradeItem4 = new MorphologyTestGradeItem();
            gradeItem4.GradeName = "+++";
            gradeItem4.Value = "60";

            MorphologyTestGradeItem gradeItem5 = new MorphologyTestGradeItem();
            gradeItem5.GradeName = "++++";
            gradeItem5.Value = "80";

            List<MorphologyTestGradeItem> gradelist = new List<MorphologyTestGradeItem>();
            gradelist.Add(gradeItem1);
            gradelist.Add(gradeItem2);
            gradelist.Add(gradeItem3);
            gradelist.Add(gradeItem4);
            gradelist.Add(gradeItem5);

            List<MorphologyTestItem> list = new List<MorphologyTestItem>();

            MorphologyTestItem nrbc = new Morphology.MorphologyTestItem("NRBC", "正常细胞", Unit.μL, false, "0-17", rbcType);
            MorphologyTestItem mrbc = new Morphology.MorphologyTestItem("MRBC", "小红细胞", Unit.μL, false, "0-17", rbcType);
            MorphologyTestItem arbc = new Morphology.MorphologyTestItem("ARBC", "棘形红细胞", Unit.μL, false, "0-17", rbcType);
            MorphologyTestItem srbc = new Morphology.MorphologyTestItem("SRBC", "影红细胞", Unit.μL, false, "0-17", rbcType);
            MorphologyTestItem qtbc = new Morphology.MorphologyTestItem("", "其他异形红细胞", Unit.μL, false, "0-17", rbcType);
            MorphologyTestItem rbc = new Morphology.MorphologyTestItem("NRBC", "红细胞", Unit.μL, true, "0-17", rbcType);
            rbc.HasSubItem = true;
            rbc.SubTestItems = new List<MorphologyTestItem>(5);
            rbc.SubTestItems.Add(nrbc);
            rbc.SubTestItems.Add(mrbc);
            rbc.SubTestItems.Add(arbc);
            rbc.SubTestItems.Add(srbc);
            rbc.SubTestItems.Add(qtbc);

            list.Add(rbc);
            rbc.GradeItems = gradelist;
            rbc.IsGrade = true;
            //list.Add(nrbc);
            //list.Add(mrbc);
            //list.Add(arbc);
            //list.Add(srbc);
            //list.Add(qtbc);

            MorphologyTestItem wbc = new Morphology.MorphologyTestItem("WBC", "白细胞", Unit.μL, false, "0-28", wbcType);
            MorphologyTestItem wbcc = new Morphology.MorphologyTestItem("WBCC", "白细胞团", Unit.μL, false, "0-2", wbcType);
            list.Add(wbc);
            list.Add(wbcc);

            MorphologyTestItem rtep = new Morphology.MorphologyTestItem("RTEP", "肾小管上皮细胞", Unit.μL, false, "0-6", ecType);
            MorphologyTestItem trep = new Morphology.MorphologyTestItem("TREP", "移行上皮细胞", Unit.μL, false, "0-6", ecType);
            MorphologyTestItem sqep = new Morphology.MorphologyTestItem("SQEP", "鳞状上皮细胞", Unit.μL, false, "0-28", ecType);
            list.Add(rtep);
            list.Add(trep);
            list.Add(sqep);

            MorphologyTestItem hyal = new Morphology.MorphologyTestItem("HYAL", "透明管型", Unit.LPF, false, "0-1", hyalType);
            list.Add(hyal);

            MorphologyTestItem uncc = new Morphology.MorphologyTestItem("UNCC", "病理管型", Unit.LPF, false, "0-1", unccType);
            MorphologyTestItem gran = new Morphology.MorphologyTestItem("GRAN", "颗粒管型", Unit.LPF, false, "0-1", unccType);
            MorphologyTestItem waxy = new Morphology.MorphologyTestItem("WAXY", "腊样管型", Unit.LPF, false, "0-1", unccType);
            MorphologyTestItem broad = new Morphology.MorphologyTestItem("BROAD", "宽大管型", Unit.LPF, false, "0-1", unccType);
            MorphologyTestItem ocas = new Morphology.MorphologyTestItem("OCAS", "其他管型", Unit.LPF, false, "0-1", unccType);

            uncc.HasSubItem = true;
            uncc.SubTestItems = new List<MorphologyTestItem>();
            uncc.SubTestItems.Add(gran);
            uncc.SubTestItems.Add(waxy);
            uncc.SubTestItems.Add(broad);
            uncc.SubTestItems.Add(ocas);

            list.Add(uncc);
            //list.Add(gran);
            //list.Add(waxy);
            //list.Add(broad);
            //list.Add(ocas);

            MorphologyTestItem baci = new Morphology.MorphologyTestItem("BACI", "杆菌", Unit.μL, false, "0-7", bactType);
            MorphologyTestItem suco = new Morphology.MorphologyTestItem("SUCO", "疑似球菌", Unit.μL, false, "/", bactType);
            list.Add(baci);
            list.Add(suco);

            MorphologyTestItem hyst = new Morphology.MorphologyTestItem("HYST", "假菌丝酵母", Unit.μL, false, "0-1", bactType);
            MorphologyTestItem byst = new Morphology.MorphologyTestItem("BYST", "酵母菌", Unit.μL, false, "0-1", bactType);
            list.Add(hyst);
            list.Add(byst);

            MorphologyTestItem caox = new Morphology.MorphologyTestItem("CAOX", "草酸钙结晶", Unit.μL, false, "0-28", xtacType);
            MorphologyTestItem uric = new Morphology.MorphologyTestItem("URIC", "尿酸结晶", Unit.μL, false, "0-28", xtacType);
            MorphologyTestItem maph = new Morphology.MorphologyTestItem("MAPH", "磷酸铵镁结晶", Unit.μL, false, "0-28", xtacType);
            MorphologyTestItem ocry = new Morphology.MorphologyTestItem("OCRY", "其他结晶", Unit.μL, false, "0-28", xtacType);

            MorphologyTestItem xtac = new Morphology.MorphologyTestItem("X'TAC", "结晶", Unit.μL, false, "0-28", xtacType);
            xtac.HasSubItem = true;
            xtac.SubTestItems = new List<MorphologyTestItem>(4);
            xtac.SubTestItems.Add(caox);
            xtac.SubTestItems.Add(uric);
            xtac.SubTestItems.Add(maph);
            xtac.SubTestItems.Add(ocry);

            list.Add(xtac);
            //list.Add(caox);
            //list.Add(uric);
            //list.Add(maph);
            //list.Add(ocry);

            MorphologyTestItem sprm = new Morphology.MorphologyTestItem("CAOX", "精子", Unit.μL, false, "0-6", null);
            MorphologyTestItem mucs = new Morphology.MorphologyTestItem("MUCS", "粘液丝", Unit.μL, false, "0-28", null);
            list.Add(sprm);
            list.Add(mucs);

            return list;

        }


        public static List<DilutionItem> GetDilutionItems()
        {
            List<DilutionItem> list = new List<Morphology.DilutionItem>();
            list.Add(new Morphology.DilutionItem("D1", new decimal(1)));
            list.Add(new Morphology.DilutionItem("D2", new decimal(2)));
            list.Add(new Morphology.DilutionItem("D4", new decimal(4)));
            list.Add(new Morphology.DilutionItem("D8", new decimal(8)));
            return list;
        }
    }
}
