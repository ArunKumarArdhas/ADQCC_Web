using ADQCC_New.Models.Masters;

namespace ADQCC_New.Models
{
    public class EmployeeModel
    {
    }
    public class GET_EMPLOYEE_DETAILS
    {
        public string? EMPLOYEE_ID { get; set; }
        public string? EMPLOYEE_NAME { get; set; }
        public string? DESIGNATION { get; set; }
        public string? STATUS { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? EMP_NAME_AR { get; set; }
    }
    public class UPLOAD_DOCUMENT
    {
        public long EMR_DOC_ID { get; set; }
        public string? EMP_EMERG_TYPE_ID { get; set; }
        public string? EMR_FILE_NAME { get; set; }
        public string? EMR_FILE_PATH { get; set; }
        public string? EMR_FILE_SIZE { get; set; }
        public string? EMR_FILE_TYPE { get; set; }
        public string? EMR_FILE_STATUS { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
    }
    public class ADD_EMPLOYEE_DETAILS
    {
        public string? EMP_ID { get; set; }
        public string? EMP_FIRSTNAME { get; set; }
        public string? EMP_LASTNAME { get; set; }
        public string? EMP_GENDER { get; set; }
        public string? EMP_NATIONALITY_ID { get; set; }
        public string? EMP_DESIGNATION_ID { get; set; }
        public string? EMP_LOCATION_ID { get; set; }
        public string? EMP_BUILDING_ID { get; set; }
        public string? EMP_SECTOR_ID { get; set; }
        public string? EMP_DEPARTMENT_ID { get; set; }
        public string? EMP_SECTION_ID { get; set; }
        public string? EMP_EMAIL { get; set; }
        public string? EMP_PHONE_NO { get; set; }
        public string? EMP_TEL_NO { get; set; }
        public string? EMP_PASSWORD { get; set; }
        public string? EMP_STATUS { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? EMP_USERNAME { get; set; }
        public string? EMP_NAME_AR { get; set; }
        public string? STATUS_CODE { get; set; }
        public string? MESSAGE { get; set; }
        public string? DESI_NAME_EN { get; set; }
        public string? OCCUPATION { get; set; }
        public string? DOB { get; set; }
        public string? PASSPORT_NUMBER { get; set; }
        public string? LENGTH_OF_SERVICE { get; set; }
        public string? EMPLOYEE_CATEGORY { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? SECTION_HEAD { get; set; }
        public string? EHS_MANAGER { get; set; }
        public string? HSSE_MANAGER { get; set; }
        public string? OCCUPATION_AR { get; set; }
        public string? EMP_LOCATION_AR { get; set; }
        public string? EMP_BUILDING_AR { get; set; }
        public string? EMP_SECTOR_AR { get; set; }
        public string? EMP_DEPARTMENT_AR { get; set; }
        public string? EMP_SECTION_ID_AR { get; set; }
        public string? IMAGE_PATH { get; set; }
        public string? LOC_NAME { get; set; }
        public string? LOC_NAME_AR { get; set; }
        public string? BUIL_NAME { get; set; }
        public string? BUIL_NAME_AR { get; set; }
        public string? EMP_ENCRYPT_ID { get; set; }



        public List<EMERG_TYPE_SELECT> _EMERG_TYPE_SELECT_LIST { get; set; }

    }
    public class EMERG_TYPE_SELECT
    {
        public string? EMP_EMERG_TYPE_ID { get; set; }
        public string? EMP_ID { get; set; }
        public string? EMERG_TYPE_MAS_ID { get; set; }
        public string? CREATED_BY { get; set; }
        public string? LOC_ID { get; set; }
        public string? BUILD_ID { get; set; }
        public string? LEVEL { get; set; }

    }

    public class EMERG_TYPE_SELECT_LIST
    {
        public List<EMERG_TYPE_SELECT> EMERG_TYPE_SELECT { get; set; }
        public string? EMP_EMERG_TYPE_ID { get; set; }
        public string? EMP_ID { get; set; }
        public string? EMERG_TYPE_MAS_ID { get; set; }
        public string? CREATED_BY { get; set; }
        public string? LOC_ID { get; set; }
        public string? BUILD_ID { get; set; }
        public string? LEVEL { get; set; }

    }

    public class HEALTH_VITAL
    {
        public string? EMP_ID { get; set; }
        public List<HEALTH_VITAL_LIST> HEALTH_VITAL_LIST { get; set; }
    }


    public class HEALTH_VITAL_LIST
    {
        public string? HEALTH_VITAL_NAME { get; set; }
        public string? EMP_ID { get; set; }
        public string? YES_OR_NO { get; set; }
    }

    #region [Employee Filter]
    public class EmpFilterDesignationModel
    {
        public long DESI_ID { get; set; }
        public string? DESI_NAME_EN { get; set; }
        public string? DESI_NAME_ARB { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? STATUS { get; set; }
        public int LANG_ID { get; set; }
        public long DESI_IDENTITY { get; set; }
        public string? MESSAGE { get; set; }
        public string? STATUS_CODE { get; set; }
    }

    public class GET_EMPLOYEE_DETAILS_FILTER
    {
        public string? EMPLOYEE_ID { get; set; }
        public string? EMPLOYEE_NAME { get; set; }
        public string? DESI_ID { get; set; }
        public string? STATUS { get; set; }
        public string? CREATED_DATE { get; set; }
    }
    #endregion



    public class EMPLOYEE_PREVIEW
    {
        public string? EMP_ID { get; set; }
        public string? EMP_FIRSTNAME { get; set; }
        public string? EMP_EMAIL { get; set; }
        public string? EMP_PHONE_NO { get; set; }
        public string? EMP_GENDER { get; set; }
        public string? EMP_DESIGNATION_ID { get; set; }
        public string? EMP_NAME_AR { get; set; }
        public string? EMP_LOCATION_ID { get; set; }
        public string? EMP_BUILDING_ID { get; set; }
        public string? EMP_SECTOR_ID { get; set; }
        public string? EMP_DEPARTMENT_ID { get; set; }
        public string? EMP_SECTION_ID { get; set; }
        public string? OCCUPATION { get; set; }
        public string? OCCUPATION_AR { get; set; }
        public string? REPORTING_MANAGER { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? DOB { get; set; }
        public string? SECTION_HEAD { get; set; }
        public string? LINE_MANAGER { get; set; }


    }

    public class EMPLOYEE_MANAGER_LIST
    {
        public string? EMP_ID { get; set; }
        public string? EMP_FIRSTNAME { get; set; }

    }

    public class GET_EMERGENCY_TYPE_TEAM
    {
        public string? EMERG_TYPE_MAS_ID { get; set; }
        public string? EMERG_TYPE_MAS { get; set; }
        public string? EMERG_TYPE_MAS_AR { get; set; }
        public string? STATUS { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? BOTH { get; set; }
        public List<GET_EMPLOYEE_EMERG_TYPE_TEAM> _EMPLOYEE_EMERG_TYPE_TEAM_LIST { get; set; }
        public List<UPLOAD_DOCUMENT> UPLOAD_DOCUMENT { get; set; }

    }

    public class GET_EMPLOYEE_EMERG_TYPE_TEAM
    {
        public string? EMP_EMERG_TYPE_ID { get; set; }
        public string? EMP_ID { get; set; }
        public string? EMERG_TYPE_MAS_ID { get; set; }
        public string? EMP_STATUS { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? IS_ACTIVE { get; set; }
        public string? EMERG_TYPE_MAS { get; set; }
        public string? EMP_FIRSTNAME { get; set; }
        public string? EMP_NAME_AR { get; set; }
        public string? DESI_NAME_ARB { get; set; }
        public string? EMP_UNIQUEID { get; set; }
        public string? DESI_NAME_EN { get; set; }
        public string? LOC_NAME { get; set; }
        public string? BUIL_NAME { get; set; }
        public string? LEVEL { get; set; }
        public string? EMP_BOTH_NAME { get; set; }
        public string? DESI_BOTH_NAME { get; set; }
        public string? LOC_BOTH_NAME { get; set; }
        public string? BUIL_BOTH_NAME { get; set; }
        public string? LOC_NAME_AR { get; set; }
        public string? BUIL_NAME_AR { get; set; }
    }

    #region [COVID_19_CHECKLIST]
    public class SYMPTOMS_MASTERS
    {
        public string? SYMPTOMS_ID { get; set; }
        public string? SYMPTOMS_NAME_AR { get; set; }
        public string? SYMPTOMS_NAME { get; set; }
        public string? SYMPTOMS_DESCRIPTION { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? STATUS { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? STATUS_CODE { get; set; }
    }


    public class ADD_SYMPTOMS
    {
        public string? VIEW_SYMPTOMS_ID { get; set; }
        public string? SYMPTOMS_ID { get; set; }
        public string? VIEW_EMP_ID { get; set; }
        public string? VIEW_CHECKLIST_ID { get; set; }
        public string? VIEW_SYMPTOMS_ISCHECK { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
    }


    public class COVID_CHECKLIST_DETAILS
    {
        public string? CHECKLIST_ID { get; set; }
        public string? EMPLOYEE_CATEGORY_ID { get; set; }
        public string? EMPLOYEE_ID { get; set; }
        public string? EMP_LOCATION { get; set; }
        public string? EMP_BUILDING { get; set; }
        public string? EMP_SECTOR { get; set; }
        public string? EMP_DESIGNATION { get; set; }
        public string? EMP_DEPARTMENT { get; set; }
        public string? EMP_SECTIONLAB { get; set; }
        public string? EMP_NAME { get; set; }
        public string? EMP_PHONENUMBER { get; set; }
        public string? EMP_EMAIL { get; set; }
        public string? EMP_GENDER { get; set; }
        public string? OTHER_SYMPTOMS { get; set; }
        public string? CLOSE_CONTACT { get; set; }
        public string? TRAVELED_INTERNATIONALLY { get; set; }
        public string? SIGNATURE { get; set; }
        public string? DATE { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? STATUS { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? REMARKS { get; set; }
        public string? TEMPERATURE { get; set; }
        public string? TEMP_F { get; set; }
        public string? TEMP_C { get; set; }
    }

    public class ADD_COVID_CHECKLIST_DETAILS
    {
        public string? CHECKLIST_ID { get; set; }
        public string? EMPLOYEE_CATEGORY_ID { get; set; }
        public string? EMPLOYEE_ID { get; set; }
        public string? EMP_LOCATION { get; set; }
        public string? EMP_BUILDING { get; set; }
        public string? EMP_SECTOR { get; set; }
        public string? EMP_DESIGNATION { get; set; }
        public string? EMP_DEPARTMENT { get; set; }
        public string? EMP_SECTIONLAB { get; set; }
        public string? EMP_NAME { get; set; }
        public string? EMP_PHONENUMBER { get; set; }
        public string? EMP_EMAIL { get; set; }
        public string? EMP_GENDER { get; set; }
        public string? OTHER_SYMPTOMS { get; set; }
        public string? CLOSE_CONTACT { get; set; }
        public string? TRAVELED_INTERNATIONALLY { get; set; }
        public string? SIGNATURE { get; set; }
        public string? DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? TEMPERATURE { get; set; }
        public string? TEMP_F { get; set; }
        public string? TEMP_C { get; set; }

        public List<ADD_SYMPTOMS> _ADD_SYMPTOMS { get; set; }
        public List<EMP_DOSE_DETAILS> _DOSE_DETAILS { get; set; }

    }
    public class EMP_DOSE_DETAILS_ADD
    {
        public string? DOSE_ID { get; set; }
        public string? EMP_ID { get; set; }
        public string? DOSE_ISCHECK { get; set; }
        public string? CERTIFICATE_ISCHECK { get; set; }
        public string? DOSE_DATE { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? DOSE_TYPE { get; set; }
        public string? DOUMENT_URL { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? REMARKS { get; set; }
        public string? IS_NATIONAL { get; set; }
        public string? IS_FAMILY_MEMBER { get; set; }
        public string? IS_VACCINE { get; set; }

    }


    public class EMP_DOSE_DETAILS
    {
        public string? DOSE_ID { get; set; }
        public string? EMP_ID { get; set; }
        public string? DOSE_ISCHECK { get; set; }
        public string? CERTIFICATE_ISCHECK { get; set; }
        public string? DOSE_DATE { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? DOSE_TYPE { get; set; }
        public string? DOUMENT_URL { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? REMARKS { get; set; }
        public string? IS_NATIONAL { get; set; }
        public string? IS_FAMILY_MEMBER { get; set; }
        public string? IS_VACCINE { get; set; }
        public string? VACCINE_NAME_EN { get; set; }
        public string? VACCINE_NAME_AR { get; set; }
        public string? STATUS { get; set; }
    }


    public class ADD_COVID_CASE_CHECKLIST_DETAILS
    {
        public string? CASE_ID { get; set; }
        public string? EMP_ID { get; set; }
        public string? CURRENT_TEMPERATURE { get; set; }
        public string? IS_CHECK_F_C { get; set; }
        public string? IS_CHECK_NEG_POS { get; set; }
        public string? NEG_POS_DATE { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? OTHER_SYMPTOMS { get; set; }
        public string? CLOSE_CONTACT { get; set; }
        public string? TRAVELED_INTERNATIONALLY { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? SIGNATURE { get; set; }
        public string? DATE { get; set; }
        public string? EXPIRED_DATE { get; set; }
        public string? FILE_PATH { get; set; }
        public string? STATUS { get; set; }


        //public List<ADD_CASE_SYMPTOMS> ADD_CASE_SYMPTOMS { get; set; }
        //public List<EMP_DOSE_DETAILS> _DOSE_DETAILS { get; set; }
        //public List<COVID_DIRECT_CONTACT> _COVID_DIRECT_CONTACT { get; set; }
    }

    public class ADD_CASE_SYMPTOMS
    {
        //public string? VIEW_SYMPTOMS_ID { get; set; }
        public string? SYMPTOMS_ID { get; set; }
        public string? VIEW_EMP_ID { get; set; }
        public string? VIEW_CHECKLIST_ID { get; set; }
        public string? VIEW_SYMPTOMS_ISCHECK { get; set; }
        public string? CREATED_BY { get; set; }
        public string? CASE_ID { get; set; }
        public string? REPORT_COVID_CASE_ID { get; set; }
        public string? CURRENT_TEMPERATURE { get; set; }
    }


    public class GET_COVID_EMP_CASE_DETAILS_LIST
    {
        public string? UNIQUE_ID { get; set; }
        public string? CASE_ID { get; set; }
        public string? IS_CHECK_NEG_POS { get; set; }
        public string? NEG_POS_DATE { get; set; }
        public string? EMPLOYEE_ID { get; set; }
        public string? EMPLOYEE_NAME_EN { get; set; }
        public string? EMPLOYEE_NAME_AR { get; set; }
        public string? CURRENT_TEMPERATURE { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY_ID { get; set; }
        public string? CREATED_BY_NAME_EN { get; set; }
        public string? STATUS { get; set; }
        public string? EXPIRED_DATE { get; set; }
    }

    public class ADD_VACCINE_SUBMIT
    {
        public List<EMP_DOSE_DETAILS_ADD> ADD_VACCINE_DETAILS { get; set; }
    }

    public class COVID_DIRECT_CONTACT
    {
        public string? DIRECT_CONTACT_ID { get; set; }
        public string? CASE_ID { get; set; }
        public string? CHECKBOX_STATUS { get; set; }
        public string? CONTACT_WORKPLACE { get; set; }
        public string? NAME { get; set; }
        public string? CONTACT_TIME { get; set; }
        public string? WEARING_MASK { get; set; }
        public string? PHYSICAL_DISTANCE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? OTHERS { get; set; }
        public string? REPORT_COVID_CASE_ID { get; set; }

    }


    public class ADD_COVID_PASTIVE_REGISTER
    {
        public string? CASE_ID { get; set; }
        public string? EMP_ID { get; set; }
        public string? CASE_TYPE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UNIQUE_ID { get; set; }
        public List<ADD_CASE_SYMPTOMS> ADD_CASE_SYMPTOMS { get; set; }
        public List<COVID_DIRECT_CONTACT> _COVID_DIRECT_CONTACT { get; set; }
    }

    public class GET_EMPLOYEE_FILTER_DETAILS_COVID
    {
        public string? LOCATION { get; set; }
        public string? BUILDING { get; set; }
        public string? SECTOR { get; set; }
        public string? DEPARTMENT { get; set; }
        public string? SECTION_LAB { get; set; }
        public string? EMPLOYEE_ID { get; set; }
        public string? EMPLOYEE_NAME { get; set; }
        public string? DESIGNATION { get; set; }
        public string? STATUS { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? EMP_NAME_AR { get; set; }
        public string? EMP_FIRSTNAME { get; set; }

    }


    public class ADD_COVID_REPORT_COVID_CASE
    {
        public string? CASE_ID { get; set; }
        public string? EMP_ID { get; set; }
        public string? CASE_TYPE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? CONTACT_TYPE { get; set; }

        public List<ADD_COVID_INSIDE_OFFICE_PERSION> _INSIDE_OFFICE_PERSION_LIST { get; set; }
    }

    public class ADD_COVID_INSIDE_OFFICE_PERSION
    {
        public string? REPORT_COVID_CASE_ID { get; set; }
        public string? CASE_ID { get; set; }
        public string? EMP_ID { get; set; }
        public string? CASE_TYPE { get; set; }
        public string? CONTACT_TYPE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? CURRENT_TEMPERATURE { get; set; }

    }

    public class ADD_COVID_REPORT_COVID_CASE_OUTSIDE
    {
        public string? REPORT_COVID_CASE_ID { get; set; }
        public string? EMP_ID { get; set; }
        public string? CASE_ID { get; set; }
        public string? CASE_TYPE { get; set; }
        public string? CONTACT_TYPE { get; set; }
        public string? PERSION_NAME { get; set; }
        public string? CONTACT_NUMBER { get; set; }
        public string? DOCUMENT_PATH { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? RELATIONSHIP { get; set; }
        public string? TEST_COVID_RESULT { get; set; }
        public string? COVID_TEST_DATE { get; set; }
        public string? CURRENT_TEMPERATURE { get; set; }

    }


    public class GET_COVID_EXPIRED_DATE_MASTER
    {
        public string? COVID_EXPIRE_ID { get; set; }
        public string? NO_OF_DAYS { get; set; }
        public string? REMARKS { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? EMP_FIRSTNAME { get; set; }
        public string? EMP_NAME_AR { get; set; }
    }

    public class EMP_COVID_DOSE_APPROVE
    {
        public string? EMP_ID { get; set; }
        public string? EMP_NAME { get; set; }
        public string? DOSE_ID { get; set; }
        public string? CERTIFICATE_ISCHECK { get; set; }
        public string? EMP_NAME_AR { get; set; }
    }


    public class ADD_VACCINE_APPROVE_SUBMIT
    {
        public List<EMP_COVID_DOSE_APPROVE> EMP_COVID_DOSE_APPROVE { get; set; }
    }


    #region [VIOLATIONS_MASTERS]
    public class VIOLATIONS_MASTER
    {
        public string? VOI_ID { get; set; }
        public string? VOI_NAME { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? VOI_NAME_AR { get; set; }
        public string? UNIQUE_ID { get; set; }
    }

    #region [INSPECTION_CHECKLIST]
    public class COVID_INSPECTION_CHECKLIST
    {
        public string? INSPECTION_ID { get; set; }
        public string? LOC_ID { get; set; }
        public string? BULID_ID { get; set; }
        public string? SECTOR_ID { get; set; }
        public string? DEPT_ID { get; set; }
        public string? SEC_LAB_ID { get; set; }
        public string? DATETIME { get; set; }
        public string? STATUS { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? LOC_NAME_AR { get; set; }
    }

    public class COVID_VIOLATIONS_CHECKLIST
    {
        public string? CHECKLIST_ID { get; set; }
        public string? INSPECTION_ID { get; set; }
        public string? VIO_ID { get; set; }
        public string? EMP_ID { get; set; }
        public string? NOTES { get; set; }
        public string? STATUS { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? VIO_STATUS { get; set; }
    }

    public class COVID_INSPECTION_FINDINGS
    {
        public string? FINDING_ID { get; set; }
        public string? INSPECTION_ID { get; set; }
        public string? FINDING_DESC { get; set; }
        public string? STATUS { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
    }

    public class ADD_COVID_INSPECTION_CHECKLIST
    {
        public string? INSPECTION_ID { get; set; }
        public string? LOC_ID { get; set; }
        public string? BULID_ID { get; set; }
        public string? SECTOR_ID { get; set; }
        public string? DEPT_ID { get; set; }
        public string? SEC_LAB_ID { get; set; }
        public string? DATETIME { get; set; }
        public string? STATUS { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UNIQUE_ID { get; set; }
        public List<COVID_VIOLATIONS_CHECKLIST> _COVID_VIOLATIONS_CHECKLIST { get; set; }
        public List<COVID_INSPECTION_FINDINGS> _COVID_INSPECTION_FINDINGS { get; set; }
    }



    #endregion

    #endregion

    #endregion

    public class Get_By_ID_Reporting_Case
    {
        public string? CASE_ID { get; set; }
        public string? CASE_TYPE { get; set; }
        public string? CONTACT_TYPE { get; set; }
        public string? CHECKBOX_STATUS { get; set; }
        public string? CURRENT_TEMPERATURE { get; set; }

    }
    public class Get_By_ID_Direct_Contact
    {
        public string? CASE_ID { get; set; }
        public string? CHECKBOX_STATUS { get; set; }
        public string? NAME { get; set; }
        public string? EMP_FIRSTNAME { get; set; }
        public string? EMP_NAME_AR { get; set; }
        public string? CONTACT_TIME { get; set; }
        public string? WEARING_MASK { get; set; }
        public string? PHYSICAL_DISTANCE { get; set; }
        public string? OTHERS { get; set; }
        public string? CONTACT_TIME_AR { get; set; }
        public string? WEARING_MASK_AR { get; set; }
        public string? PHYSICAL_DISTANCE_AR { get; set; }
    }

    public class Get_By_ID_OutsideOffice
    {
        public string? CASE_ID { get; set; }
        public string? PERSION_NAME { get; set; }
        public string? CONTACT_NUMBER { get; set; }
        public string? DOCUMENT_PATH { get; set; }
        public string? RELATIONSHIP { get; set; }
        public string? TEST_COVID_RESULT { get; set; }
        public string? COVID_TEST_DATE { get; set; }
        public string? RELATIONSHIP_AR { get; set; }
        public string? TEST_COVID_RESULT_AR { get; set; }
    }

    public class Get_By_ID_InSideOffice
    {
        public string? CASE_ID { get; set; }
        public string? EMP_ID { get; set; }
        public string? EMP_FIRSTNAME { get; set; }
        public string? EMP_NAME_AR { get; set; }
        public string? SEC_NAME_EN { get; set; }
        public string? SEC_NAME_ARB { get; set; }
        public string? LOC_ID { get; set; }
        public string? BUIL_ID { get; set; }
        public string? SEC_ID { get; set; }
        public string? DEP_ID { get; set; }
        public string? SEC_LAB_ID { get; set; }
    }

    public class Get_By_ID_Symptoms_List
    {
        public string? CASE_ID { get; set; }
        public string? SYMPTOMS_ID { get; set; }
        public string? VIEW_SYMPTOMS_ISCHECK { get; set; }
    }

    public class ADD_REJECT_RESION_COVID
    {
        public string? COVID_REJECT_ID { get; set; }
        public string? CASE_ID { get; set; }
        public string? REJECT_DESCRIPTION { get; set; }
        public string? CREATED_BY { get; set; }
        public string? HSSE_STATUS { get; set; }
        public string? UNIQUE_ID { get; set; }
    }
    public class GetCovidRejectList
    {
        public string? COVID_REJECT_ID { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? CASE_ID { get; set; }
        public string? REJECT_DESCRIPTION { get; set; }
        public string? CREATED_BY { get; set; }
        public string? CREATED_BY_NAME { get; set; }
        public string? CREATED_DATE { get; set; }

    }



    #region [COVID_VACCINE_MASTER]
    public class Get_Vaccine
    {
        public string? VACCINE_MAS_ID { get; set; }
        public string? NAME_EN { get; set; }
        public string? NAME_AR { get; set; }
        public string? EMP_FIRSTNAME { get; set; }
        public string? EMP_NAME_AR { get; set; }
        public string? CREATED_BY { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? STATUS { get; set; }
    }
    public class Add_Vaccine
    {
        public string? VACCINE_MAS_ID { get; set; }
        public string? NAME_EN { get; set; }
        public string? NAME_AR { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UNIQUE_ID { get; set; }
    }
    public class Get_By_ID_Vaccine
    {
        public string? VACCINE_MAS_ID { get; set; }
        public string? NAME_EN { get; set; }
        public string? NAME_AR { get; set; }
        public string? EMP_FIRSTNAME { get; set; }
        public string? EMP_NAME_AR { get; set; }
        public string? CREATED_BY { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? UNIQUE_ID { get; set; }
    }

    #endregion



    public class VIEW_EMPLOYEE_DETAILS
    {
        public string? EMP_ID { get; set; }
        public string? EMP_FIRSTNAME { get; set; }
        public string? EMP_LASTNAME { get; set; }
        public string? EMP_GENDER { get; set; }
        public string? EMP_EMAIL { get; set; }
        public string? EMP_PHONE_NO { get; set; }
        public string? EMP_TEL_NO { get; set; }
        public string? EMP_PASSWORD { get; set; }
        public string? EMP_USERNAME { get; set; }
        public string? EMP_NAME_AR { get; set; }
        public string? OCCUPATION { get; set; }
        public string? DOB { get; set; }
        public string? EMPLOYEE_CATEGORY { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? IMAGE_PATH { get; set; }
        public string? DESI_NAME_EN { get; set; }
        public string? DESI_NAME_ARB { get; set; }
        public string? BUIL_NAME { get; set; }
        public string? BUIL_NAME_AR { get; set; }
        public string? LOC_NAME { get; set; }
        public string? LOC_NAME_AR { get; set; }
        public string? SEC_NAME_EN { get; set; }
        public string? SEC_NAME_ARB { get; set; }
        public string? DEP_NAME { get; set; }
        public string? DEP_NAME_AR { get; set; }
        public string? SEC_LAB_NAME { get; set; }
        public string? SEC_LAB_NAME_AR { get; set; }
    }

    #region [TEST_RESULT_DETAILS]
    public class GET_TEST_RESULT_DETAILS
    {
        public string? CASE_ID { get; set; }
        public string? EMP_ID { get; set; }
        public string? IS_CHECK_F_C { get; set; }
        public string? IS_CHECK_NEG_POS { get; set; }
        public string? NEG_POS_DATE { get; set; }
        public string? EXPIRED_DATE { get; set; }
        public string? FILE_PATH { get; set; }

    }
    #endregion
}
