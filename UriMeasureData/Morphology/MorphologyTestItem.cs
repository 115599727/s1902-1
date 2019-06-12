using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Data.Morphology
{
    /// <summary>
    /// 形态学检测项目
    /// </summary>
    public class MorphologyTestItem
    {

        public MorphologyTestItem(string shortName, string itemName, Unit itemUnit, bool isGrade, string reference, MorphologyTestType testType)
        {
            this.ShortName = shortName;
            this.ItemName = itemName;
            this.ItemUnit = itemUnit;
            this.IsGrade = IsGrade;
            this.Reference = reference;
            this.TestType = testType;
        }

        /// <summary>
        /// 简称
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public Unit ItemUnit { get; set; }

        /// <summary>
        /// 是否划分等级
        /// </summary>
        public bool IsGrade { get; set; }
        /// <summary>
        /// 引用范围 ，参考值的范围
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// 等级列表
        /// </summary>
        public List<MorphologyTestGradeItem> GradeItems { get; set; }
        /// <summary>
        /// 形态学检测类型
        /// </summary>
        public MorphologyTestType TestType { get; set; }

        /// <summary>
        /// 半定量等级范围 选择“半定量等级范围”的等级，当测试结果等于或高于选取的等级，会有异常值 标识H、↑或*号，如果选择“无阈值”，测试结果没有异常值标识。 
        /// </summary>
        public int HalfResult { get; set; }

        /// <summary>
        /// 包含子项 如果是大类别项，则包含子项，数值是子项求和
        /// </summary>
        public bool HasSubItem { get; set; }

        /// <summary>
        /// 子项集合
        /// </summary>
        public List<MorphologyTestItem> SubTestItems { get; set; }

        /// <summary>
        /// 如果选择 false “无阈值”，测试结果没有异常值标识。
        /// </summary>
        public bool ShowTag { get; set; }

    }
    /// <summary>
    /// 形态学检测类型
    /// </summary>
    public class MorphologyTestType
    {
        public MorphologyTestType(string shortName, string name)
        {
            this.ShortName = shortName;
            this.Name = name;
        }

        public string ShortName { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name + " " + this.ShortName;
        }



    }

    public enum Unit
    {
        μL = 1, HPF, LPF
    }
}
