using Medicside.UriMeasure.Data.Chemistry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Medicside.UriMeasure.DataAccess.DataHelper
{
  public  class ChemistryDataHelper
    {

        public static Dictionary<string, string> GetChemistryReference()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("UBG", "3.4μmol/L");
            dic.Add("BIL", "17μmol/L");
            dic.Add("KET", "0.5mmol/L");
            dic.Add("BLD", "10Cells/μL");
            dic.Add("PRO", "0.15g/L");
            dic.Add("NIT", "0.125 mg/dL");
            dic.Add("LEU", "15Cells/μL");
            dic.Add("GLU", "2.8mmol/L");
            dic.Add("PH", "——");
            dic.Add("SG", "——");
            dic.Add("VC", "0.6mmol/L");
            dic.Add("MALB", "10mg/L");
            dic.Add("CRE", "0.9mmol/L");
            dic.Add("Ca", "1.0mmol/L");

            return dic;
        }

        /// <summary>
        /// 获取 干化学测试项目
        /// </summary>
        /// <returns></returns>
        public static List<ChemistryTestItem> GetChemistryTestChmTypeItems()
        {
            var REF = GetChemistryReference();
            List<ChemistryTestItem> list = new List<ChemistryTestItem>();

            var item1 = new ChemistryTestItem("UBG", "尿胆原UBG", ChemistryTestType.Chemistry, "μmol/L", "mg/dL");

            ChemistryTestItemSubItem sub0 = new ChemistryTestItemSubItem("1", "700", "3.4", "μmol/L", "0.2", "mg/dL", "Normal");
            ChemistryTestItemSubItem sub1 = new ChemistryTestItemSubItem("2", "465", "17", "μmol/L", "1", "mg/dL", "Normal");
            ChemistryTestItemSubItem sub2 = new ChemistryTestItemSubItem("3", "310", "34", "μmol/L", "2", "mg/dL", "1+");
            ChemistryTestItemSubItem sub3 = new ChemistryTestItemSubItem("4", "190", "68", "μmol/L", "4", "mg/dL", "2+");
            ChemistryTestItemSubItem sub4 = new ChemistryTestItemSubItem("5", "0", ">=135", "μmol/L", ">=8", "mg/dL", "3+");
            item1.SubItems = new List<ChemistryTestItemSubItem>();
            item1.SubItems.Add(sub0);
            item1.SubItems.Add(sub1);
            item1.SubItems.Add(sub2);
            item1.SubItems.Add(sub3);
            item1.SubItems.Add(sub4);
            item1.Reference = REF["UBG"];
            list.Add(item1);

            var item2 = new ChemistryTestItem("BIL", "胆红素BIL", ChemistryTestType.Chemistry, "μmol/L", "mg/dL");
            ChemistryTestItemSubItem bil0 = new ChemistryTestItemSubItem("1", "930", "", "", "", "", "Neg");
            ChemistryTestItemSubItem bil1 = new ChemistryTestItemSubItem("2", "848", "17", "μmol/L", "1", "mg/dL", "1+");
            ChemistryTestItemSubItem bilsub2 = new ChemistryTestItemSubItem("3", "759", "51", "μmol/L", "3", "mg/dL", "2+");
            ChemistryTestItemSubItem bilsub3 = new ChemistryTestItemSubItem("4", "0", ">=103", "μmol/L", ">=6", "mg/dL", "3+");
            item2.SubItems = new List<ChemistryTestItemSubItem>();
            item2.SubItems.Add(bil0);
            item2.SubItems.Add(bil1);
            item2.SubItems.Add(bilsub2);
            item2.SubItems.Add(bilsub3);
            item2.Reference = REF["BIL"];

            var item3 = new ChemistryTestItem("KET", "酮体KET", ChemistryTestType.Chemistry, "μmol/L", "mg/dL");
            ChemistryTestItemSubItem KETsub0 = new ChemistryTestItemSubItem("1", "3625", "", "", "", "", "Neg");
            ChemistryTestItemSubItem KETsub1 = new ChemistryTestItemSubItem("2", "3459", "0.5", "μmol/L", "5", "mg/dL", "Normal");
            ChemistryTestItemSubItem KETsub2 = new ChemistryTestItemSubItem("3", "3183", "1.5", "μmol/L", "15", "mg/dL", "1+");
            ChemistryTestItemSubItem KETsub3 = new ChemistryTestItemSubItem("4", "2824", "3.9", "μmol/L", "40", "mg/dL", "2+");
            ChemistryTestItemSubItem KETsub4 = new ChemistryTestItemSubItem("5", "2196", "7.8", "μmol/L", "80", "mg/dL", "3+");
            ChemistryTestItemSubItem KETsub5 = new ChemistryTestItemSubItem("6", "0", ">=16.0", "μmol/L", ">=160", "mg/dL", "3+");
            item3.SubItems = new List<ChemistryTestItemSubItem>();
            item3.SubItems.Add(KETsub0);
            item3.SubItems.Add(KETsub1);
            item3.SubItems.Add(KETsub2);
            item3.SubItems.Add(KETsub3);
            item3.SubItems.Add(KETsub4);
            item3.Reference = REF["KET"];

            var item4 = new ChemistryTestItem("BLD", "潜血BLD", ChemistryTestType.Chemistry, "μmol/L", "mg/dL");

            var BLDsub1 = new ChemistryTestItemSubItem("1", "6300", "", "", "", "", "Neg");
            var BLDsub2 = new ChemistryTestItemSubItem("2", "4684", "10", "Cells/μL", "10", "Cells/μL", "+-");
            var BLDsub3 = new ChemistryTestItemSubItem("3", "3011", "25", "Cells/μL", "25", "Cells/μL", "1+");
            var BLDsub4 = new ChemistryTestItemSubItem("4", "1462", "80", "Cells/μL", "80", "Cells/μL", "2+");
            var BLDsub5 = new ChemistryTestItemSubItem("5", "0", ">=200", "Cells/μL", ">=200", "Cells/μL", "3+");
            item4.SubItems = new List<ChemistryTestItemSubItem>();
            item4.SubItems.Add(BLDsub1);
            item4.SubItems.Add(BLDsub2);
            item4.SubItems.Add(BLDsub3);
            item4.SubItems.Add(BLDsub4);
            item4.SubItems.Add(BLDsub5);
            item4.Reference = REF["BLD"];
            var item5 = new ChemistryTestItem("PRO", "蛋白质PRO", ChemistryTestType.Chemistry, "μmol/L", "mg/dL");
            item5.SubItems = new List<ChemistryTestItemSubItem>();
            var PROsub1 = new ChemistryTestItemSubItem("1", "650", "", "", "", "", "Neg");
            var PROsub2 = new ChemistryTestItemSubItem("2", "565", "", "", "", "", "Trace");
            var PROsub3 = new ChemistryTestItemSubItem("3", "465", "0.3", "g/L", "30", "mg/dL", "1+");
            var PROsub4 = new ChemistryTestItemSubItem("4", "390", "1", "g/L", "100", "mg/dL", "2+");
            var PROsub5 = new ChemistryTestItemSubItem("5", "301", "3", "g/L", "300", "mg/dL", "3+");
            var PROsub6 = new ChemistryTestItemSubItem("6", "0", ">=20.0", "g/L", ">=2000", "mg/dL", "4+");
            item5.SubItems.Add(PROsub1);
            item5.SubItems.Add(PROsub2);
            item5.SubItems.Add(PROsub3);
            item5.SubItems.Add(PROsub4);
            item5.SubItems.Add(PROsub5);
            item5.SubItems.Add(PROsub6);
            item5.Reference = REF["PRO"];
            var item6 = new ChemistryTestItem("NIT", "亚硝酸盐NIT", ChemistryTestType.Chemistry, "μmol/L", "mg/dL");
            item6.SubItems = new List<ChemistryTestItemSubItem>();
            var NITsub1 = new ChemistryTestItemSubItem("1", "850", "", "", "", "", "Neg");
            var NITsub2 = new ChemistryTestItemSubItem("2", "714", "0.125", "mg/dL", "0.125", "mg/dL", "1+");
            var NITsub3 = new ChemistryTestItemSubItem("3", "0", "0.25", "mg/dL", "0.25", "mg/dL", "2+");
            item6.SubItems.Add(NITsub1);
            item6.SubItems.Add(NITsub2);
            item6.SubItems.Add(NITsub3);
            item6.Reference = REF["NIT"];

            var item7 = new ChemistryTestItem("LEU", "白细胞LEU", ChemistryTestType.Chemistry, "μmol/L", "mg/dL");
            item7.SubItems = new List<ChemistryTestItemSubItem>();
            var LEUsub1 = new  ChemistryTestItemSubItem("1", "5778", "", "", "", "", "Neg");
            var LEUsub2 = new  ChemistryTestItemSubItem("2", "5286", "15", "Cells/μL", "15", "Cells/μL", "+-");
            var LEUsub3 = new  ChemistryTestItemSubItem("3", "4238", "70", "Cells/μL", "70", "Cells/μL", "1+");
            var LEUsub4 = new  ChemistryTestItemSubItem("4", "3059", "125", "Cells/μL", "125", "Cells/μL", "2+");
            var LEUsub5 = new  ChemistryTestItemSubItem("5", "0", ">=500", "Cells/μL", ">=500", "Cells/μL", "3+");
            item7.SubItems.Add(LEUsub1);
            item7.SubItems.Add(LEUsub2);
            item7.SubItems.Add(LEUsub3);
            item7.SubItems.Add(LEUsub4);
            item7.SubItems.Add(LEUsub5);
            item7.Reference = REF["LEU"];

            var item8 = new ChemistryTestItem("GLU", "葡萄糖GLU", ChemistryTestType.Chemistry, "μmol/L", "mg/dL");
            item8.SubItems = new List<ChemistryTestItemSubItem>();
            var GLUsub1 = new  ChemistryTestItemSubItem("1", "1798", "", "", "", "", "Neg");
            var GLUsub2 = new  ChemistryTestItemSubItem("2", "1377", "2.8", "mmol/L", "50", "mg/dL", "+-");
            var GLUsub3 = new  ChemistryTestItemSubItem("3", "907", "5.6", "mmol/L", "100", "mg/dL", "1+");
            var GLUsub4 = new  ChemistryTestItemSubItem("4", "410", "14", "mmol/L", "250", "mg/dL", "2+");
            var GLUsub5 = new  ChemistryTestItemSubItem("5", "55", "28", "mmol/L", "500", "mg/dL", "3+");
            var GLUsub6 = new  ChemistryTestItemSubItem("6", "0", ">=56", "mmol/L", ">=1000", "mg/dL", "4+");
            item8.SubItems.Add(GLUsub1);
            item8.SubItems.Add(GLUsub2);
            item8.SubItems.Add(GLUsub3);
            item8.SubItems.Add(GLUsub4);
            item8.SubItems.Add(GLUsub5);
            item8.SubItems.Add(GLUsub6);
            item8.Reference = REF["GLU"];
            var item9 = new ChemistryTestItem("PH", "酸碱度pH", ChemistryTestType.Chemistry, "μmol/L", "mg/dL");
            item9.SubItems = new List<ChemistryTestItemSubItem>();
            var PHsub1 = new  ChemistryTestItemSubItem("1", "4150", "5.0", "", "5.0", "", "5.0");
            var PHsub2 = new  ChemistryTestItemSubItem("2", "3500", "5.5", "", "5.5", "", "5.5");
            var PHsub3 = new  ChemistryTestItemSubItem("3", "2900", "6.0", "", "6.0", "", "6.0");
            var PHsub4 = new  ChemistryTestItemSubItem("4", "2500", "6.5", "", "6.5", "", "6.5");
            var PHsub5 = new  ChemistryTestItemSubItem("5", "2200", "7.0", "", "7.0", "", "7.0");
            var PHsub6 = new  ChemistryTestItemSubItem("6", "1800", "7.5", "", "7.5", "", "7.5");
            var PHsub7 = new  ChemistryTestItemSubItem("7", "1100", "8.0", "", "8.0", "", "8.0");
            var PHsub8 = new  ChemistryTestItemSubItem("8", "800", "8.5", "", "8.5", "", "8.5");
            var PHsub9 = new  ChemistryTestItemSubItem("9", "0", "9.0", "", "9.0", "", "9.0");
            item9.SubItems.Add(PHsub1);
            item9.SubItems.Add(PHsub2);
            item9.SubItems.Add(PHsub3);
            item9.SubItems.Add(PHsub4);
            item9.SubItems.Add(PHsub5);
            item9.SubItems.Add(PHsub6);
            item9.SubItems.Add(PHsub7);
            item9.SubItems.Add(PHsub8);
            item9.SubItems.Add(PHsub9);
            item9.Reference = REF["PH"];





            var item10 = new ChemistryTestItem("VC", "维生素C VC", ChemistryTestType.Chemistry, "μmol/L", "mg/dL");
            item10.SubItems = new List<ChemistryTestItemSubItem>();
            var VCsub1 = new  ChemistryTestItemSubItem("1", "1065", "", "", "", "", "5.7");
            var VCsub2 = new  ChemistryTestItemSubItem("2", "950", "", "", "", "", "2.8");
            var VCsub3 = new  ChemistryTestItemSubItem("3", "600", "", "", "", "", "1.4");
            var VCsub4 = new  ChemistryTestItemSubItem("4", "200", "", "", "", "", "0.6");
            var VCsub5 = new  ChemistryTestItemSubItem("5", "0", "", "", "", "", "0");
            item10.SubItems.Add(VCsub1);
            item10.SubItems.Add(VCsub2);
            item10.SubItems.Add(VCsub3);
            item10.SubItems.Add(VCsub4);
            item10.SubItems.Add(VCsub5);
            item10.Reference = REF["VC"];




            var item11 = new ChemistryTestItem("MALB", "微白蛋白MALB", ChemistryTestType.Chemistry, "μmol/L", "mg/dL");
            item11.SubItems = new List<ChemistryTestItemSubItem>();
            var MALBsub1 = new  ChemistryTestItemSubItem("", "1150", "", "", "", "", "10");
            var MALBsub2 = new  ChemistryTestItemSubItem("", "910", "", "", "", "", "30");
            var MALBsub3 = new  ChemistryTestItemSubItem("", "700", "", "", "", "", "80");
            var MALBsub4 = new  ChemistryTestItemSubItem("", "0", "", "", "", "", "150");
            item11.SubItems.Add(MALBsub1);
            item11.SubItems.Add(MALBsub2);
            item11.SubItems.Add(MALBsub3);
            item11.SubItems.Add(MALBsub4);
            item11.Reference = REF["MALB"];


            var item12 = new ChemistryTestItem("CRE", "肌酐CRE", ChemistryTestType.Chemistry, "μmol/L", "mg/dL");
            item12.SubItems = new List<ChemistryTestItemSubItem>();
            var CREsub1 = new  ChemistryTestItemSubItem("", "5815", "", "", "", "", "0.9");
            var CREsub2 = new  ChemistryTestItemSubItem("", "5229", "", "", "", "", "4.4");
            var CREsub3 = new  ChemistryTestItemSubItem("", "4741", "", "", "", "", "8.8");
            var CREsub4 = new  ChemistryTestItemSubItem("", "4187", "", "", "", "", "17.7");
            var CREsub5 = new  ChemistryTestItemSubItem("", "0", "", "", "", "", "26.5");
            item12.SubItems.Add(CREsub1);
            item12.SubItems.Add(CREsub2);
            item12.SubItems.Add(CREsub3);
            item12.SubItems.Add(CREsub4);
            item12.SubItems.Add(CREsub5);
            item12.Reference = REF["CRE"];


            var item13 = new ChemistryTestItem("Ca", "尿钙Ca", ChemistryTestType.Chemistry, "", "");
            item13.SubItems = new List<ChemistryTestItemSubItem>();
            var CAsub1 = new  ChemistryTestItemSubItem("", "3725", "", "", "", "", "1");
            var CAsub2 = new  ChemistryTestItemSubItem("", "3441", "", "", "", "", "2.5");
            var CAsub3 = new  ChemistryTestItemSubItem("", "3200", "", "", "", "", "5");
            var CAsub4 = new  ChemistryTestItemSubItem("", "3067", "", "", "", "", "7.5");
            var CAsub5 = new  ChemistryTestItemSubItem("", "0", "", "", "", "", "10");
            item13.SubItems.Add(CAsub1);
            item13.SubItems.Add(CAsub2);
            item13.SubItems.Add(CAsub3);
            item13.SubItems.Add(CAsub4);
            item13.SubItems.Add(CAsub5);
            item13.Reference = REF["Ca"];

            var item14 = new ChemistryTestItem("SG", "比重SG", ChemistryTestType.Biomer);
            item14.SubItems = new List<ChemistryTestItemSubItem>();
            var SGsub1 = new  ChemistryTestItemSubItem("1", "2300", "", "", "", "", "1.030");
            var SGsub2 = new  ChemistryTestItemSubItem("2", "1950", "", "", "", "", "1.025");
            var SGsub3 = new  ChemistryTestItemSubItem("3", "1100", "", "", "", "", "1.020");
            var SGsub4 = new  ChemistryTestItemSubItem("4", "800", "", "", "", "", "1.010");
            var SGsub5 = new  ChemistryTestItemSubItem("5", "0", "", "", "", "", "1.005");
            item14.SubItems.Add(SGsub1);
            item14.SubItems.Add(SGsub2);
            item14.SubItems.Add(SGsub3);
            item14.SubItems.Add(SGsub4);
            item14.SubItems.Add(SGsub5);
            item14.Reference = REF["SG"];

            var item15 = new ChemistryTestItem("COLOR", "颜色COLOR", ChemistryTestType.Biomer);
            var item16 = new ChemistryTestItem("TURB", "浊度TURB", ChemistryTestType.Biomer);
            var item17 = new ChemistryTestItem("COND", "电导率COND", ChemistryTestType.Biomer);

            list.Add(item2);
            list.Add(item3);
            list.Add(item4);
            list.Add(item5);
            list.Add(item6);
            list.Add(item7);
            list.Add(item8);
            list.Add(item9);
            list.Add(item10);
            list.Add(item11);
            list.Add(item12);
            list.Add(item13);
            list.Add(item14);
            list.Add(item15);
            list.Add(item16);
            list.Add(item17);

            return list;



        }

        /// <summary>
        /// 尿胆原临界值
        /// </summary>
        /// <returns></returns>
        public static ChemistryThresholdSet GetChemistryUBGThreshold()
        {
            ChemistryThresholdSet cts = new ChemistryThresholdSet();
            cts.Name = "尿胆原(UBG)";
            cts.Unit = "umol/L";
            cts.Values = new List<string> { "3.4", "17", "34", "68", ">=135" };
            return cts;

        }

        /// <summary>
        /// 胆红素临界值
        /// </summary>
        /// <returns></returns>
        public static ChemistryThresholdSet GetChemistryBILThreshold()
        {
            ChemistryThresholdSet cts = new ChemistryThresholdSet();
            cts.Name = "胆红素(BIL)";
            cts.Unit = "umol/L";
            cts.Values = new List<string> { "Neg", "17", "51", ">=103" };
            return cts;
        }

        /// <summary>
        /// 酮体临界值
        /// </summary>
        /// <returns></returns>
        public static ChemistryThresholdSet GetChemistryKETThreshold()
        {
            ChemistryThresholdSet cts = new ChemistryThresholdSet();
            cts.Name = "酮体(KET)";
            cts.Unit = "mmol/L";
            cts.Values = new List<string> { "Neg", "0.5", "1.5", "3.9", "7.8", "16" };
            return cts;
        }

        /// <summary>
        /// 潜血临界值
        /// </summary>
        /// <returns></returns>
        public static ChemistryThresholdSet GetChemistryBLDThreshold()
        {
            ChemistryThresholdSet cts = new ChemistryThresholdSet();
            cts.Name = "潜血(BLD)";
            cts.Unit = "Cells/uL";
            cts.Values = new List<string> { "Neg", "10", "25", "80", ">=200" };
            return cts;
        }
        /// <summary>
        /// 蛋白质临界值
        /// </summary>
        /// <returns></returns>
        public static ChemistryThresholdSet GetChemistryPROThreshold()
        {
            ChemistryThresholdSet cts = new ChemistryThresholdSet();
            cts.Name = "蛋白质(PRO)";
            cts.Unit = "g/L";
            cts.Values = new List<string> { "Neg", "Trace+-", "0.3", "1.0", "3.0", ">=20.0" };
            return cts;
        }
        /// <summary>
        /// 亚硝酸盐临界值
        /// </summary>
        /// <returns></returns>
        public static ChemistryThresholdSet GetChemistryNITThreshold()
        {
            ChemistryThresholdSet cts = new ChemistryThresholdSet();
            cts.Name = "亚硝酸盐(NIT)";
            cts.Unit = "mg/dL";
            cts.Values = new List<string> { "Neg", "0.125", "0.25" };
            return cts;
        }
        /// <summary>
        /// 白细胞临界值
        /// </summary>
        /// <returns></returns>
        public static ChemistryThresholdSet GetChemistryLEUThreshold()
        {
            ChemistryThresholdSet cts = new ChemistryThresholdSet();
            cts.Name = "白细胞(LEU)";
            cts.Unit = "Cells/uL";
            cts.Values = new List<string> { "Neg", "15", "70", "125", ">=500" };
            return cts;
        }
        /// <summary>
        /// 葡萄糖临界值
        /// </summary>
        /// <returns></returns>
        public static ChemistryThresholdSet GetChemistryGLUThreshold()
        {
            ChemistryThresholdSet cts = new ChemistryThresholdSet();
            cts.Name = "葡萄糖体(GLU)";
            cts.Unit = "mmol/L";
            cts.Values = new List<string> { "Neg", "5.6", "14", "28", ">=56" };
            return cts;
        }


    }
}
