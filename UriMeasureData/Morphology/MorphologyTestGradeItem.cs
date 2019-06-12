namespace Medicside.UriMeasure.Data.Morphology
{
    public class MorphologyTestGradeItem
    {
        public string GradeName { get; set; }

        public string Value { get; set; }


        public override string ToString()
        {
            return GradeName + "  " + Value;
        }
    }
}