using System.ComponentModel.DataAnnotations;

namespace ADQCC_New.Models
{
    public class LoginModel
    {
        public long EMP_ID { get; set; }
        public string? EMP_FIRSTNAME { get; set; }
        public string? EMP_LASTNAME { get; set; }
        public string? EMP_GENDER { get; set; }
        public int EMP_NATIONALITY_ID { get; set; }
        public int EMP_DESIGNATION_ID { get; set; }
        public int EMP_LOCATION_ID { get; set; }
        public int EMP_BUILDING_ID { get; set; }
        public int EMP_SECTOR_ID { get; set; }
        public int EMP_DEPARTMENT_ID { get; set; }
        public int EMP_SECTION_ID { get; set; }
        public string? EMP_EMAIL { get; set; }
        public string? EMP_PHONE_NO { get; set; }
        public string? EMP_TEL_NO { get; set; }
        public string? EMP_PASSWORD { get; set; }
        public bool EMP_STATUS { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public long CREATED_BY { get; set; }
        public DateTime UPDATED_DATE { get; set; }
        public long UPDATED_BY { get; set; }
        public string? EMP_USERNAME { get; set; }
        public int EMP_LANGUAGE { get; set; }
    }
    public class GET_USER_DETAILS
    {
        public int EMP_ID { get; set; }
        public string? MESSAGE { get; set; }
        public string? LANG_ID { get; set; }
        public string? DISPLAY_NAME { get; set; }
        public string? DISPLAY_NAME_AR { get; set; }
        public string? DESI_NAME { get; set; }
        public string? EMP_USERNAME { get; set; }
        public string? EMP_PASSWORD { get; set; }
        public string? EMP_STATUS { get; set; }
        public string? STATUS { get; set; }
        public string? DESI_NAME_AR { get; set; }
        public string? GENDER { get; set; }
        public string? EXPIRED_DATE { get; set; }
        public string? EMP_ENCRYPT_ID { get; set; }
        public string? JWT_Token { get; set; }
        public Employee_Common_Model? Employee_Common_List { get; set; }
    }


    public class LOGIN
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string? Desi_Id { get; set; }
        public string? LANG_ID { get; set; }
        public string? OTP { get; set; }
        public Employee_Common_Model? Employee_Common_List { get; set; }
    }

    public class Employee_Common_Model
    {
        public List<Employee_Sub_Model>? Employee_Role_List { get; set; }
    }

    public class Employee_Sub_Model
    {
        public string? Identity_Id { set; get; }
        public string? Common_Id { set; get; }
        public string? Common_Name { set; get; }
        public string? Employee_Id { set; get; }
        public string? Employee_Identity_Id { set; get; }
        public string? Remarks { set; get; }
    }

    public class GET_USER_DETAILS_RETURN
    {
        public string? STATUS_CODE { get; set; }
        public bool STATUS { get; set; }
        public string? MESSAGE { get; set; }
        public GET_USER_DETAILS? USER_DETAILS { get; set; }
    }
    public class GET_TOKEN
    {
        public string? ACCESS_TOKEN { get; set; }
    }

    public class UPDATE_CHANGE_PASSWORD
    {
        public string? EMP_USERNAME { get; set; }
    }

    public class RETURN_MESSAGE_NEW
    {
        public string? STATUS_CODE { get; set; }
        //public bool STATUS { get; set; }
        public string? MESSAGE { get; set; }
        public string? EMP_ID { get; set; }
        public string? EMP_NAME { get; set; }
        public string? EMP_EMAIL { get; set; }
        public string? EMP_NEW_PASSWORD { get; set; }
    }
    public class CHANGE_PASSWORD
    {
        public string? EMP_ID { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d\s]).{8,}$",
        ErrorMessage = "Password must contain at least 1 uppercase letter, 1 lowercase letter, 1 digit, and 1 special character")]
        [DataType(DataType.Password)]
        public string? PASSWORD { get; set; }
    }


    public class LOGIN_RETURN_MESSAGE
    {
        public string? STATUS_CODE { get; set; }
        public string? MESSAGE { get; set; }
        public string? LANG_ID { get; set; }
        public string? DESI_NAME { get; set; }
    }
}
