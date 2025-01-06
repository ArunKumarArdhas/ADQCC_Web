using static ADQCC_New.Models.EmergencyModel;

namespace ADQCC_New.Models
{
    public class IncidentMasterModel
    {
    }

    #region[Incident Cause Analysis]
    public class GET_EMR_INCDT_CA_DETAILS
    {
        public string? INCDT_CAS_ID { get; set; }
        public string? INCDT_CAS_NAME { get; set; }
        public string? INCDT_CAS_NAME_AR { get; set; }

        public string? STATUS { get; set; }



    }
    public class ADD_EMR_INCDT_CA_MASTER
    {
        public string? INCDT_CAS_ID { get; set; }
        public string? INCDT_CAS_NAME { get; set; }
        public string? INCDT_CAS_NAME_AR { get; set; }

        public string? STATUS { get; set; }


    }
    #endregion

    #region[Incident Category]
    public class IncidentCategoryModel
    {
        public long INC_CAT_ID { get; set; }
        public string? INC_CAT_NAME { get; set; }
        public string? INC_CAT_NAME_AR { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public DateTime UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public bool STATUS { get; set; }
        public string? MESSAGE { get; set; }
        public string? STATUS_CODE { get; set; }
        public string? UNIQUE_ID { get; set; }

    }

    public class GET_INCIDENT_CATEGORY_DETAILS
    {
        public string? INC_ID { get; set; }
        public long? INC_CAT_ID { get; set; }
        public string? INC_CAT_NAME { get; set; }
        public string? INC_CAT_NAME_AR { get; set; }

    }

    public class GET_INCIDENT_DETAILS
    {
        public string INC_ID { get; set; }
        public string LOC_NAME { get; set; }
        public string LOC_NAME_AR { get; set; }
        public string INC_CAT_NAME { get; set; }
        public string INC_CAT_NAME_AR { get; set; }
        public string INC_STATUS_NAME { get; set; }
        public string INC_STATUS { get; set; }
        public string INC_DATE { get; set; }
        public string UNIQUE_ID { get; set; }
        public string NON_INVEST_STATUS { get; set; }
    }

    public class GET_EMPLOYEE_DETAILS_REPORTABLE
    {
        public string? REPORTER_BY { get; set; }
        public string? EMPLOYEE_NAME { get; set; }
        public string? DESIGNATION { get; set; }
        public string? STATUS { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? EMP_NAME_AR { get; set; }
    }

    public class GET_DESIGNATION_EMPID
    {
        public string EMP_ID { get; set; }
        public string EMP_DESIGNATION_ID { get; set; }
        public string DESI_NAME_EN { get; set; }
        public string DESI_NAME_ARB { get; set; }
    }

    #endregion

    #region [INCIDENTDETAILS]
    public class IncidentModel
    {
        public string? INC_ID { get; set; }
        public string? INC_CATEGORY { get; set; }
        public string? INC_DATE_TIME { get; set; }
        public string? INC_NOTIFY_BY { get; set; }
        public string? INC_DEPART_ID { get; set; }
        public string? INC_LOC_ID { get; set; }
        public string? INC_SEC_ID { get; set; }
        public string? INC_SEC_LAB_ID { get; set; }
        public string? INC_BUIL_ID { get; set; }
        public string? IS_PERSON_INVOLVED { get; set; }
        public string? IS_FATALITY { get; set; }
        public string? DESCRIPTION { get; set; }
        public string? INC_TYPE { get; set; }
        public string? REPORTED_BY { get; set; }
        public string? CREATED_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public string? UPDATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public string? INC_STATUS { get; set; }
        public string? OTHER_NAME { get; set; }
        public List<ADQ_INCIDENT_TYPE_DETAILS> INCIDENT_TYPE_DETAILS { get; set; }
    }

    public class ADQ_INCIDENT_TYPE_DETAILS
    {
        //public long INC_TYPE_ID { get; set; }
        public string? INC_ID { get; set; }
        public string? INCIDENT_TYPE_ID { get; set; }
        public string? SAFETY_EQUIPMENT_ID { get; set; }
        public string? EN_EQUIPMENT_ID { get; set; }
    }

    public class GET_INVE_CORRECTIVE_ACTION
    {
        public string INC_ID { get; set; }
        public string LOC_NAME { get; set; }
        public string LOC_NAME_AR { get; set; }
        public string INC_CAT_NAME { get; set; }
        public string INC_CAT_NAME_AR { get; set; }
        public string INC_STATUS { get; set; }
        public string INC_DATE { get; set; }
        public string UNIQUE_ID { get; set; }
        public string NON_INVEST_STATUS { get; set; }
        public string ACTION { get; set; }
        public string TARGET_DATE { get; set; }
        public string PERSON_RESPONSIBLE { get; set; }
        public string EMP_FIRSTNAME { get; set; }
        public string EMP_NAME_AR { get; set; }
        public string CORRECTION_STATUS { get; set; }
        public string DUE_DATE { get; set; }
        public string DUE_DATE_AR { get; set; }

    }

    public class UPLOAD_PHOTO_LIST
    {
        public long INC_PHOTO_ID { get; set; }
        public string INC_ID { get; set; }
        public string INC_PHOTO_NAME { get; set; }
        public string INC_PHOTO_PATH { get; set; }
        public string INC_PHOTO_FILE_SIZE { get; set; }
        public string INC_PHOTO_FILE_TYPE { get; set; }
        public string INC_PHOTO_STATUS { get; set; }

    }

    public class UPLOAD_INC_VIDEO_LIST
    {
        public string INC_VIDEO_ID { get; set; }
        public string INC_ID { get; set; }
        public string INC_VIDEO_NAME { get; set; }
        public string INC_VIDEO_PATH { get; set; }
        public int? INC_VIDEO_FILE_SIZE { get; set; }
        public string INC_VIDEO_FILE_TYPE { get; set; }
        public string INC_VIDEO_STATUS { get; set; }
        public string INC_VIDEO_EXT { get; set; }
    }

    public class VIEW_INCIDENT_DETAILS
    {
        public string INC_ID { get; set; }
        public string INC_CAT_NAME { get; set; }
        public string INC_DATE_TIME { get; set; }
        public string EMP_FIRSTNAME { get; set; }
        public string DEP_NAME { get; set; }
        public string LOC_NAME { get; set; }
        public string SEC_NAME_EN { get; set; }
        public string SEC_LAB_NAME { get; set; }
        public string BUIL_NAME { get; set; }
        public string UNIQUE_ID { get; set; }
        public string DESCRIPTION { get; set; }
        public string INC_CAT_NAME_AR { get; set; }
        public string EMP_NAME_AR { get; set; }
        public string DEP_NAME_AR { get; set; }
        public string LOC_NAME_AR { get; set; }
        public string SEC_NAME_ARB { get; set; }
        public string SEC_LAB_NAME_AR { get; set; }
        public string BUIL_NAME_AR { get; set; }
        public string INC_STATUS { get; set; }
        public string REPORTER_BY { get; set; }
        public string REPORTED_BY { get; set; }

    }

    public class VIEW_INCIDENT_DETAILS_LIST
    {
        public List<VIEW_INCIDENT_DETAILS> VIEW_INCIDENT_DETAILS { get; set; }
        public List<ADQ_INCIDENT_TYPE_DETAILS> INCIDENT_TYPE_DETAILS { get; set; }
        public List<UPLOAD_PHOTO_LIST> UPLOAD_PHOTO_LIST { get; set; }

        public List<UPLOAD_INC_VIDEO_LIST> UPLOAD_INC_VIDEO_LIST { get; set; }
        public bool STATUS { get; set; }
        public string MESSAGE { get; set; }
    }


    #endregion

    #region [INVESTIGATION FORM]
    public class INVESTCATION_DETAILS
    {
        public List<INVE_IM_CASUE_ACT> INVE_IM_CASUE_ACT { get; set; }
        public List<INVE_IM_CASUE_UNC> INVE_IM_CASUE_UNC { get; set; }
        public List<INVE_IM_ROOT_PF> INVE_IM_ROOT_PF { get; set; }
        public List<INVE_IM_ROOT_SF> INVE_IM_ROOT_SF { get; set; }
        public List<INVE_IM_ROOT_METHOD> INVE_IM_ROOT_METHOD { get; set; }
        public List<INVE_IM_ROOT_ENVI> INVE_IM_ROOT_ENIV { get; set; }
        public List<INVE_IM_ROOT_MATERIAL> INVE_IM_ROOT_MATERIAL { get; set; }
        public List<INVE_NATURE_OF_INJURY> INVE_NATURE_OF_INJURY { get; set; }
        public List<INVE_MECHANISM_OF_INJURY> INVE_MECHANISM_OF_INJURY { get; set; }
        public List<INVE_SOURCE_OF_INJURY> INVE_SOURCE_OF_INJURY { get; set; }
        public List<INVE_BODY_LOC_CASUE> INVE_BODY_LOC_CASUE { get; set; }
        public List<ACTION_TAKEN_IMMEDIATELY> ACTION_TAKEN_IMMEDIATELY { get; set; }
        public List<INCIDENT_ROOT_CAUSE> INCIDENT_ROOT_CAUSE { get; set; }
        public List<CORRECTIVE_ACTION> CORRECTIVE_ACTION { get; set; }
        public List<INCIDENT_COST_ANALYSIS> INCIDENT_COST_ANALYSIS { get; set; }
        public List<INJURED_PERSONAL_DETAILS> INJURED_PERSONAL_DETAILS { get; set; }
        public List<RISK_ASSESSMENT_DETAILS> RISK_ASSESSMENT_DETAILS { get; set; }
        public List<DECLARATION_INJURED_PERSON> DECLARATION_INJURED_PERSON { get; set; }
        public List<MEDICAL_REPORT> MEDICAL_REPORT { get; set; }
        public List<ADD_INVE_SEQUENCE_EVENT> INVE_SEQUENCE_EVENT { get; set; }
        public List<GET_INTERVIEW_DETAILS> INTERVIEW_DETAILS { get; set; }
        public List<GET_SITE_INSPECTION> SITE_INSPECTION { get; set; }
        public List<GET_NEW_SITE_INSPECTION> NEW_SITE_INSPECTION { get; set; }
        public List<UPDATE_INCIDENT_STATUS> UPDATE_INCIDENT_STATUS { get; set; }
    }

    public class GET_INTERVIEW_DETAILS
    {
        public string? INTERVIEW_ID { get; set; }
        public string? INC_ID { get; set; }
        public string? INTERVIEWER { get; set; }
        public string? INTERVIEWE { get; set; }
        public string? FEED_BACK { get; set; }
        public string? CREATED_BY { get; set; }

    }

    public class GET_SITE_INSPECTION
    {
        public string? INC_ID { get; set; }
        public string? SITE_INSP_ID { get; set; }
        public string? DOCUMENT_REVIEWER { get; set; }
        public string? DOCUMENT_NAME { get; set; }
        public string? IMAGE_UPLOAD { get; set; }
        public string? DOCUMENT_UPLOAD { get; set; }
        public string? CREATED_BY { get; set; }
    }

    public class GET_NEW_SITE_INSPECTION
    {
        public string? INC_ID { get; set; }
        public string? NEW_SITE_INSP_ID { get; set; }
        public string? NEW_SITE_DESCRIPTION { get; set; }
        public string? NEW_SITE_LOCATION { get; set; }
        public string? IMAGE_UPLOAD { get; set; }
        public string? CREATED_BY { get; set; }
    }

    public class UPDATE_INCIDENT_STATUS
    {
        public string? INC_ID { get; set; }
        public string? INC_STATUS { get; set; }
        public string? REPORTER_BY { get; set; }
    }

    public class ADD_INVE_SEQUENCE_EVENT
    {
        public string? SEQUENCE_ID { get; set; }
        public string? INC_ID { get; set; }
        public string? SEQUENCE_DATE { get; set; }
        public string? SEQUENCE_TIME { get; set; }
        public string? SEQUENCE_EVENT { get; set; }
        public string? CREATED_BY { get; set; }
    }
    public class INVE_IM_CASUE_ACT
    {
        public string? INC_ID { get; set; }
        public string? INVE_IM_CAUSE_ID { get; set; }
        public string? INVE_OTHER_NAME { get; set; }
    }

    public class INVE_IM_CASUE_UNC
    {
        public string? INC_ID { get; set; }
        public string? INVE_IM_CAUSE_UNC_ID { get; set; }
        public string? INVE_OTHER_NAME { get; set; }
    }

    public class INVE_IM_ROOT_PF
    {
        public string? INC_ID { get; set; }
        public string? INVE_IM_ROOT_PF_ID { get; set; }
        public string? INVE_OTHER_NAME { get; set; }
    }

    public class INVE_IM_ROOT_SF
    {
        public string? INC_ID { get; set; }
        public string? INVE_IM_ROOT_SF_ID { get; set; }
        public string? INVE_OTHER_NAME { get; set; }
    }

    public class INVE_IM_ROOT_METHOD
    {
        public string? INC_ID { get; set; }
        public string? INVE_IM_METHOD_ID { get; set; }
        public string? INVE_OTHER_NAME { get; set; }
    }

    public class INVE_IM_ROOT_ENVI
    {
        public string? INC_ID { get; set; }
        public string? INVE_IM_ENVI_ID { get; set; }
        public string? INVE_OTHER_NAME { get; set; }
    }

    public class INVE_IM_ROOT_MATERIAL
    {
        public string? INC_ID { get; set; }
        public string? INVE_IM_MATERIAL_ID { get; set; }
        public string? INVE_OTHER_NAME { get; set; }
    }

    public class INVE_NATURE_OF_INJURY
    {
        public string? INC_ID { get; set; }
        public string? NATURE_INJURY_NAME_ID { get; set; }
        public string? INVE_OTHER_NAME { get; set; }
    }

    public class INVE_MECHANISM_OF_INJURY
    {
        public string? INC_ID { get; set; }
        public string? MECH_INJURY_NAME_ID { get; set; }
        public string? INVE_OTHER_NAME { get; set; }
    }

    public class INVE_SOURCE_OF_INJURY
    {
        public string? INC_ID { get; set; }
        public string? SOURCE_INJURY_NAME_ID { get; set; }
        public string? INVE_OTHER_NAME { get; set; }
    }

    public class INVE_BODY_LOC_CASUE
    {
        public string? INC_ID { get; set; }
        public string? INVE_IM_BODY_CAT_ID { get; set; }
        public string? INVE_IM_SUB_CAT_ID { get; set; }
        public string? INVE_OTHER_NAME { get; set; }
        public string? IMAGE_PATH { get; set; }
    }

    public class ACTION_TAKEN_IMMEDIATELY
    {
        public string? INC_ID { get; set; }
        public string? ACTION_NAME { get; set; }
        public string? RESPONSIBILITY_ID { get; set; }
        public string? DATE { get; set; }
        public string? EMP_ID { get; set; }
        public string? RESPONSIBILITY_NAME_AR { get; set; }
    }

    public class INCIDENT_ROOT_CAUSE
    {
        public string? INC_ID { get; set; }
        public string? ROOT_NAME { get; set; }
        public string? IMAGE_NAME { get; set; }
        public string? IMAGE_PATH { get; set; }
    }

    public class CORRECTIVE_ACTION
    {
        public string? INC_ID { get; set; }
        public string? S_NO { get; set; }
        public string? ACTION { get; set; }
        public string? PERSON_RESPONSIBLE { get; set; }
        public string? TARGET_DATE { get; set; }
        public string? EMP_ID { get; set; }
        public string? PERSON_RESPONSIBLE_AR { get; set; }

    }

    public class INCIDENT_COST_ANALYSIS
    {
        public string? INC_ID { get; set; }
        public string? INC_COST_ID { get; set; }
        public string? INC_COST_AMT { get; set; }
    }

    public class INJURED_PERSONAL_DETAILS
    {
        public string? INC_ID { get; set; }
        public string? RELATIONSHIP_ID { get; set; }
        public string? EMPLOYEE_ID { get; set; }
        public string? OCCUPATION { get; set; }
        public string? NATIONALITY { get; set; }
        public string? DOB { get; set; }
        public string? PASSPORT_NUMBER { get; set; }
        public string? LENGTH_OF_SERVICE { get; set; }
        public string? CONTACT_PHONE_NUMBER { get; set; }
        public string? GENDER { get; set; }
        public string? EMP_ID { get; set; }
        public string? OCCUPATION_AR { get; set; }
        public string? EMP_NAME_AR { get; set; }
    }

    public class RISK_ASSESSMENT_DETAILS
    {
        public string? INC_ID { get; set; }
        public string? RISK_ASSESSMENT_ID { get; set; }

    }

    public class DECLARATION_INJURED_PERSON
    {
        public string? INC_ID { get; set; }
        public string? NAME_INJURED_PERSON { get; set; }
        public string? DATE { get; set; }
    }
    public class MEDICAL_REPORT
    {
        public string? INC_ID { get; set; }
        public string? INJURY_NAME { get; set; }
        public string? NO_DAYS_NC { get; set; }
        public string? DOCUMENT_UPLOAD { get; set; }
    }
    #endregion

    public class GET_EMR_INCDT_COST_ANALYSIS
    {
        public string INVE_INCIDENT_COST_ID { get; set; }
        public string INC_ID { get; set; }
        public string INC_COST_ID { get; set; }
        public string INC_COST_AMT { get; set; }
        public string INCDT_CAS_NAME { get; set; }
        public string INCDT_CAS_NAME_AR { get; set; }
        public string UNIQUE_ID { get; set; }

    }


}
