namespace ZagsDbServerProject.Models
{
    public class SpecificDataFromDetailsTable
    {
        public int ApplicationDetailID { get; set; }
        public int SpecificApplicationDataID { get; set; }
        public string SpecificApplicationDataName { get; set; }
        public int Order { get; set; }
        public bool IsRequired { get; set; }
        public int FieldTypeID { get; set; }
        public string FieldTypeName { get; set; }
        public string FieldsLabel { get; set; }
        public string SourceTable { get; set; }
        public string Value { get; set; }
        public int MistakeStatus { get; set; }
    }
}
