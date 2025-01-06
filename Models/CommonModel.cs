namespace ADQCC_New.Models
{
    public class M_COMMON_FIELDS
    {
        public string? LANG_ID { get; set; }
        public string? ACTION { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? STATUS_CODE { get; set; }
        public string? DESCRIPTION { get; set; }
        public string? STATUS { get; set; }
        public string? IS_ACTIVE { get; set; }
        public string? REMARKS { get; set; }
    }
    public class RETURN_MESSAGE
    {
        public string? STATUS_CODE { get; set; }
        public bool STATUS { get; set; }
        public string? MESSAGE { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? Return_1 { get; set; }
        public string? Return_2 { get; set; }
        public string? Return_3 { get; set; }
    }
}
