using System;
using System.Collections.Generic;

namespace Medicside.UriMeasure.Data.Chemistry
{
    /// <summary>
    /// 干化学测试项目
    /// </summary>

    public class ChemistryTestItem
    {


        public ChemistryTestItem(String itemId, String itemName, ChemistryTestType testType)
        {
            this.ItemID = itemId;
            this.ItemName = itemName;
            this.TestType = testType;
        }
        public ChemistryTestItem(String itemId, String itemName, ChemistryTestType testType, string commonUnit, string internalUnit)
        {
            this.ItemID = itemId;
            this.ItemName = itemName;
            this.TestType = testType;
            this.CommonUnit = commonUnit;
            this.InternalUnit = internalUnit;

        }

        public ChemistryTestItem(String itemId, String itemName,
           String scalerband, String scalerValue, String internationalValue, String internationUnit,
           String commonValue, String commonUnit, String symbol, ChemistryTestType testType)
        {
            this.ItemID = itemId;
            this.ItemName = itemName;
            this.TestType = testType;

            ChemistryTestItemSubItem item = new Chemistry.ChemistryTestItemSubItem();

            item.ScalerBand = scalerband;
            item.ScalerValue = scalerValue;
            item.InternationalValue = internationalValue;
            item.InternationUnit = internationUnit;
            item.CommonValue = commonValue;
            item.CommonUnit = commonUnit;
            item.Symbol = symbol;

            this.SubItems = new List<Chemistry.ChemistryTestItemSubItem>();
            this.SubItems.Add(item);
        }
        /// <summary>
        /// 项目编号
        /// </summary>
        public String ItemID { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public String ItemName { get; set; }
        /// <summary>
        /// 测试类型
        /// </summary>
        public ChemistryTestType TestType { get; set; }

        public List<ChemistryTestItemSubItem> SubItems { get; set; }

        /// <summary>
        /// 参考范围
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// 常规单位
        /// </summary>
        public String CommonUnit { get; set; }


        /// <summary>
        /// 国际单位
        /// </summary>
        public String InternalUnit { get; set; }

        /// <summary>
        /// 设置的单位类型
        /// </summary>
        private string UItemUnit;
        //单位标准
        private ChemistryTestUnitType ChemistryTestUnit=0;

        public string ItemUnit
        {

            get
            {

                if (ChemistryTestUnit == ChemistryTestUnitType.Common ||
                    ChemistryTestUnit == ChemistryTestUnitType.CommonSymbol)
                {
                    return CommonUnit;
                }
                else
                {
                    return InternalUnit;
                }
            }


        }





    }

    /// <summary>
    /// 
    /// </summary>
    [Obsolete("This class is obsolete; use class ChemistryTestItem instead")]
    public class ChemistryTestcItem
    {

        //public ChemistryTestItem(String itemId, String itemName,
        //    String scalerband, String scalerValue, String internationalValue, String internationUnit,
        //    String commonValue, String commonUnit, String symbol)
        //{
        //    this.ItemID = itemId;
        //    this.ItemName = itemName;

        //    ChemistryTestItemSubItem item = new Chemistry.ChemistryTestItemSubItem();

        //    item.ScalerBand = scalerband;
        //    item.ScalerValue = scalerValue;
        //    item.InternationalValue = internationalValue;
        //    item.InternationUnit = internationUnit;
        //    item.CommonValue = commonValue;
        //    item.CommonUnit = commonUnit;
        //    item.Symbol = symbol;

        //    this.SubItems = new List<Chemistry.ChemistryTestItemSubItem>();
        //    this.SubItems.Add(item);

        //}
        public ChemistryTestcItem(String itemId, String itemName,
           String scalerband, String scalerValue, String internationalValue, String internationUnit,
           String commonValue, String commonUnit, String symbol, ChemistryTestType testType)
        {
            this.ItemID = itemId;
            this.ItemName = itemName;
            this.TestType = testType;

            //ChemistryTestItemSubItem item = new Chemistry.ChemistryTestItemSubItem();

            this.ScalerBand = scalerband;
            this.ScalerValue = scalerValue;
            this.InternationalValue = internationalValue;
            this.InternationUnit = internationUnit;
            this.CommonValue = commonValue;
            this.CommonUnit = commonUnit;
            this.Symbol = symbol;

            //this.SubItems = new List<Chemistry.ChemistryTestItemSubItem>();
            //this.SubItems.Add(item);
        }
        /// <summary>
        /// 项目编号
        /// </summary>
        public String ItemID { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public String ItemName { get; set; }
        /// <summary>
        /// 测试类型
        /// </summary>
        public ChemistryTestType TestType { get; set; }
        public String ScalerValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String ScalerBand { get; set; }
        /// <summary>
        /// 国际单位数值
        /// </summary>
        public String InternationalValue { get; set; }
        /// <summary>
        /// 国际单位
        /// </summary>
        public String InternationUnit { get; set; }

        /// <summary>
        /// 常规数值
        /// </summary>
        public String CommonValue { get; set; }
        /// <summary>
        /// 常规单位
        /// </summary>
        public String CommonUnit { get; set; }
        /// <summary>
        /// 符号系统
        /// </summary>
        public String Symbol { get; set; }
        //public List<ChemistryTestItemSubItem> SubItems { get; set; }
    }

    public enum ChemistryTestType
    {
        Chemistry = 1, Biomer
    }

    public class ChemistryTestItemSubItem
    {
        public ChemistryTestItemSubItem(String scalerband, String scalerValue, String internationalValue, String internationUnit,
           String commonValue, String commonUnit, String symbol)
        {
            this.ScalerBand = scalerband;
            this.ScalerValue = scalerValue;
            this.InternationalValue = internationalValue;
            this.InternationUnit = internationUnit;
            this.CommonValue = commonValue;
            this.CommonUnit = commonUnit;
            this.Symbol = symbol;
        }
        public ChemistryTestItemSubItem()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public String ScalerValue { get; set; }
        /// <summary>
        /// 标尺序号
        /// </summary>
        public String ScalerBand { get; set; }
        /// <summary>
        /// 国际单位数值
        /// </summary>
        public String InternationalValue { get; set; }
        /// <summary>
        /// 国际单位
        /// </summary>
        public String InternationUnit { get; set; }

        /// <summary>
        /// 常规数值
        /// </summary>
        public String CommonValue { get; set; }
        /// <summary>
        /// 常规单位
        /// </summary>
        public String CommonUnit { get; set; }
        /// <summary>
        /// 符号系统
        /// </summary>
        public String Symbol { get; set; }

    }
    public enum ChemistryTestUnitType
    {
        International, Common, InternationalSymbol, CommonSymbol, Symbol
    }
}