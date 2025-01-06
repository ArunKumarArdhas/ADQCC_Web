namespace ADQCC_New.Models
{
    public class EmergencyModel
    {
        #region [ImmediateCause_UnsafeAct]
        public class GET_EMR_IC_ACT_DETAILS
        {
            public string? CAUSE_ID { get; set; }
            public string? CAUSENAME { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? CAUSE_NAME_AR { get; set; }
            public string? STATUS { get; set; }
            public string? UNIQUE_ID { get; set; }
            public string? INVE_OTHER_NAME { get; set; }
        }

        public class GET_VIEW_INVE_IM_METHOD
        {
            public string? INVE_IM_ID { get; set; }
            public string? INC_ID { get; set; }
            public string? METHOD_ID { get; set; }
            public string? INVE_OTHER_NAME { get; set; }
            public string? METHOD_NAME { get; set; }
            public string? RC_METHOD_NAME_AR { get; set; }

        }

        public class GET_VIEW_INVE_IM_ENVIRONMENT
        {
            public string? INVE_IM_ID { get; set; }
            public string? INC_ID { get; set; }
            public string? ENIV_ID { get; set; }
            public string? INVE_OTHER_NAME { get; set; }
            public string? ENVIRONMENT_NAME { get; set; }
            public string? RC_ENVIRONMENT_NAME_AR { get; set; }

        }

        public class GET_VIEW_INVE_IM_MATERIAL
        {
            public string? INVE_IM_ID { get; set; }
            public string? INC_ID { get; set; }
            public string? MATERIAL_ID { get; set; }
            public string? INVE_OTHER_NAME { get; set; }
            public string? MATERIAL_NAME { get; set; }
            public string? RC_MATERIAL_NAME_AR { get; set; }

        }
        public class ADD_EMRICAct_MASTER
        {
            public string? CAUSE_ID { get; set; }
            public string? CAUSENAME { get; set; }
            public string? CAUSE_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? UNIQUE_ID { get; set; }
        }

        #endregion

        #region [ImmediateCause_UnsafeConditions]

        public class GET_EMR_IC_UC_DETAILS
        {
            public string? IM_UNSAFE_ID { get; set; }
            public string? IM_UNSAFENAME { get; set; }
            public string? IM_UNSAFE_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? UNIQUE_ID { get; set; }
            public string? INVE_OTHER_NAME { get; set; }
        }

        public class ADD_EMR_IC_UC_MASTER
        {
            public string? IM_UNSAFE_ID { get; set; }
            public string? IM_UNSAFENAME { get; set; }
            public string? IM_UNSAFE_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? UNIQUE_ID { get; set; }

        }

        #endregion

        #region [Root Causes (Personal factor)]

        public class GET_EMR_RC_PF_DETAILS
        {
            public string? ROOT_CAUSE_ID { get; set; }
            public string? ROOT_CAUSE_NAME { get; set; }
            public string? ROOT_CAUSE_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? UNIQUE_ID { get; set; }
            public string? INVE_OTHER_NAME { get; set; }

        }

        public class ADD_EMR_RC_PF_MASTER
        {
            public string? ROOT_CAUSE_ID { get; set; }
            public string? ROOT_CAUSE_NAME { get; set; }
            public string? ROOT_CAUSE_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? UNIQUE_ID { get; set; }

        }

        #endregion

        #region [Root Causes (System factor)]

        public class GET_EMR_RC_SF_DETAILS
        {
            public string? RC_SF_ID { get; set; }
            public string? RC_SF_NAME { get; set; }
            public string? RC_SF_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? UNIQUE_ID { get; set; }
            public string? INVE_OTHER_NAME { get; set; }

        }

        public class ADD_EMR_RC_SF_MASTER
        {
            public string? RC_SF_ID { get; set; }
            public string? RC_SF_NAME { get; set; }
            public string? RC_SF_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? UNIQUE_ID { get; set; }

        }

        #endregion

        #region [Root Cause (Method)]
        public class GET_EMR_RC_METHOD
        {
            public string? RC_METHOD_ID { get; set; }
            public string? RC_METHOD_NAME { get; set; }
            public string? RC_METHOD_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? INVE_OTHER_NAME { get; set; }
            public string? UNIQUE_ID { get; set; }
        }

        public class ADD_EMR_RC_METHOD_MASTER
        {
            public string? RC_METHOD_ID { get; set; }
            public string? RC_METHOD_NAME { get; set; }
            public string? RC_METHOD_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? UNIQUE_ID { get; set; }
        }
        #endregion
        #region [Root Cause(Environment)]
        public class GET_EMR_RC_ENVIRONMENT
        {
            public string? RC_ENVIRONMENT_ID { get; set; }
            public string? RC_ENVIRONMENT_NAME { get; set; }
            public string? RC_ENVIRONMENT_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? INVE_OTHER_NAME { get; set; }
            public string? UNIQUE_ID { get; set; }
        }

        public class ADD_EMR_RC_ENVIRONMENT_MASTER
        {
            public string? RC_ENVIRONMENT_ID { get; set; }
            public string? RC_ENVIRONMENT_NAME { get; set; }
            public string? RC_ENVIRONMENT_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? UNIQUE_ID { get; set; }
        }
        #endregion

        #region [Root Cause(Material)]
        public class GET_EMR_RC_MATERIAL
        {
            public string? RC_MATERIAL_ID { get; set; }
            public string? RC_MATERIAL_NAME { get; set; }
            public string? RC_MATERIAL_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? INVE_OTHER_NAME { get; set; }
            public string? UNIQUE_ID { get; set; }
        }

        public class ADD_EMR_RC_MATERIAL_MASTER
        {
            public string? RC_MATERIAL_ID { get; set; }
            public string? RC_MATERIAL_NAME { get; set; }
            public string? RC_MATERIAL_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? UNIQUE_ID { get; set; }
        }
        #endregion

        #region [Nature of Injury / Illness]

        public class GET_EMR_NATURE_INJURY_DETAILS
        {
            public string? NATURE_INJURY_ID { get; set; }
            public string? NATURE_INJURY_NAME { get; set; }
            public string? NATURE_INJURY_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? UNIQUE_ID { get; set; }
            public string? INVE_OTHER_NAME { get; set; }

        }

        public class ADD_EMR_NATURE_INJURY_MASTER
        {
            public string? NATURE_INJURY_ID { get; set; }
            public string? NATURE_INJURY_NAME { get; set; }
            public string? NATURE_INJURY_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? UNIQUE_ID { get; set; }

        }

        #endregion

        #region [Mechanism of Injury / Illness]

        public class GET_EMR_MECH_INJURY_DETAILS
        {
            public string? MECH_INJURY_ID { get; set; }
            public string? MECH_INJURY_NAME { get; set; }
            public string? MECH_INJURY_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? UNIQUE_ID { get; set; }
            public string? INVE_OTHER_NAME { get; set; }

        }

        public class ADD_EMR_MECH_INJURY_MASTER
        {
            public string? MECH_INJURY_ID { get; set; }
            public string? MECH_INJURY_NAME { get; set; }
            public string? MECH_INJURY_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? UNIQUE_ID { get; set; }

        }

        #endregion

        #region [Agency / Source of Injury / Illness]

        public class GET_EMR_AGENCY_INJURY_DETAILS
        {
            public string? AGENCY_INJURY_ID { get; set; }
            public string? AGENCY_INJURY_NAME { get; set; }
            public string? AGENCY_INJURY_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? UNIQUE_ID { get; set; }
            public string? INVE_OTHER_NAME { get; set; }


        }

        public class ADD_EMR_AGENCY_INJURY_MASTER
        {
            public string? AGENCY_INJURY_ID { get; set; }
            public string? AGENCY_INJURY_NAME { get; set; }
            public string? AGENCY_INJURY_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? UNIQUE_ID { get; set; }

        }

        #endregion

        #region [ Body Location ]

        #region [Body Location Category Master]

        public class GET_EMR_BODY_LOC_CAT_DETAILS
        {
            public string? BODY_LOC_CAT_ID { get; set; }
            public string? BODY_LOC_CAT_NAME { get; set; }
            public string? BODY_LOC_CAT_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? UNIQUE_ID { get; set; }

        }

        public class ADD_EMR_BODY_LOC_CAT_MASTER
        {
            public string? BODY_LOC_CAT_ID { get; set; }
            public string? BODY_LOC_CAT_NAME { get; set; }
            public string? BODY_LOC_CAT_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? UNIQUE_ID { get; set; }

        }

        #endregion

        #region [Body Location]

        public class GET_EMR_BODY_LOC_DETAILS
        {
            public string? BODY_LOC_ID { get; set; }
            public string? BODY_LOC_CAT_ID { get; set; }
            public string? CAT_NAME { get; set; }
            public string? CAT_NAME_AR { get; set; }
            public string? SUB_CAT_NAME { get; set; }
            public string? SUB_CAT_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? UNIQUE_ID { get; set; }

        }

        public class ADD_EMR_BODY_LOC_MASTER
        {
            public string? BODY_LOC_ID { get; set; }
            public string? BODY_LOC_CAT_ID { get; set; }
            public string? CAT_NAME { get; set; }
            public string? CAT_NAME_AR { get; set; }
            public string? SUB_CAT_NAME { get; set; }
            public string? SUB_CAT_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? STATUS_CODE { get; set; }

            public string? UNIQUE_ID { get; set; }
        }

        #endregion

        #endregion

        //#region [Incident Cause Analysis]

        //public class GET_EMR_INCDT_CA_DETAILS
        //{
        //    public string? INCDT_CAS_ID { get; set; }
        //    public string? INCDT_CAS_NAME { get; set; }
        //    public string? INCDT_CAS_NAME_AR { get; set; }
        //    public string? CREATED_DATE { get; set; }
        //    public string? STATUS { get; set; }

        //    public string? UNIQUE_ID { get; set; }
        //}

        //public class GET_EMR_INCDT_COST_ANALYSIS
        //{
        //    public string? INVE_INCIDENT_COST_ID { get; set; }
        //    public string? INC_ID { get; set; }
        //    public string? INC_COST_ID { get; set; }
        //    public string? INC_COST_AMT { get; set; }
        //    public string? INCDT_CAS_NAME { get; set; }
        //    public string? INCDT_CAS_NAME_AR { get; set; }
        //    public string? UNIQUE_ID { get; set; }

        //}
        //public class ADD_EMR_INCDT_CA_MASTER
        //{
        //    public string? INCDT_CAS_ID { get; set; }
        //    public string? INCDT_CAS_NAME { get; set; }
        //    public string? INCDT_CAS_NAME_AR { get; set; }
        //    public string? CREATED_DATE { get; set; }
        //    public string? STATUS { get; set; }
        //    public string? CREATED_BY { get; set; }
        //    public string? UPDATED_DATE { get; set; }
        //    public string? UPDATED_BY { get; set; }
        //    public string? STATUS_CODE { get; set; }


        //}

        //#endregion

        #region [Risk Assessment Master]

        public class GET_EMR_RISK_ASS_MASTER_DETAILS
        {
            public string? RISK_ASS_MASTER_ID { get; set; }
            public string? RISK_ASS_MASTER_NAME { get; set; }
            public string? RISK_ASS_MASTER_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? UNIQUE_ID { get; set; }

        }

        public class ADD_EMR_RISK_ASS_MASTER_MASTER
        {
            public string? RISK_ASS_MASTER_ID { get; set; }
            public string? RISK_ASS_MASTER_NAME { get; set; }
            public string? RISK_ASS_MASTER_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? STATUS_CODE { get; set; }

            public string? UNIQUE_ID { get; set; }
        }

        #endregion

        #region [Risk Assessment]

        public class GET_EMR_RISK_ASSESSMENT_DETAILS
        {
            public string? RISK_ASS_ID { get; set; }
            public string? RISK_ASS_MASTER_ID { get; set; }
            public string? RISK_ASS_MASTER_NAME { get; set; }
            public string? RISK_ASS_POSSIBILITY { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? UNIQUE_ID { get; set; }

        }

        public class ADD_EMR_RISK_ASSESSMENT
        {
            public string? RISK_ASS_ID { get; set; }
            public string? RISK_ASS_MASTER_ID { get; set; }
            public string? RISK_ASS_POSSIBILITY { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? UNIQUE_ID { get; set; }
        }

        #endregion

        //#region [INCIDENTDETAILS]
        //public class IncidentModel
        //{
        //    public string? INC_ID { get; set; }
        //    public string? INC_CATEGORY { get; set; }
        //    public string? INC_DATE_TIME { get; set; }
        //    public string? INC_NOTIFY_BY { get; set; }
        //    public string? INC_DEPART_ID { get; set; }
        //    public string? INC_LOC_ID { get; set; }
        //    public string? INC_SEC_ID { get; set; }
        //    public string? INC_SEC_LAB_ID { get; set; }
        //    public string? INC_BUIL_ID { get; set; }
        //    public string? IS_PERSON_INVOLVED { get; set; }
        //    public string? IS_FATALITY { get; set; }
        //    public string? DESCRIPTION { get; set; }
        //    public string? INC_TYPE { get; set; }
        //    public string? REPORTED_BY { get; set; }
        //    public string? CREATED_DATE { get; set; }
        //    public string? CREATED_BY { get; set; }
        //    public string? UPDATED_DATE { get; set; }
        //    public string? UPDATED_BY { get; set; }
        //    public string? INC_STATUS { get; set; }
        //    public string? OTHER_NAME { get; set; }
        //    public List<ADQ_INCIDENT_TYPE_DETAILS> INCIDENT_TYPE_DETAILS { get; set; }
        //}

        //public class GET_INCIDENT_DETAILS
        //{
        //    public string? INC_ID { get; set; }
        //    public string? LOC_NAME { get; set; }
        //    public string? LOC_NAME_AR { get; set; }
        //    public string? INC_CAT_NAME { get; set; }
        //    public string? INC_CAT_NAME_AR { get; set; }
        //    public string? INC_STATUS { get; set; }
        //    public string? INC_DATE { get; set; }
        //    public string? UNIQUE_ID { get; set; }
        //    public string? NON_INVEST_STATUS { get; set; }


        //}

        //public class UPDATE_INCIDENT_STATUS
        //{
        //    public string? INC_ID { get; set; }
        //    public string? INC_STATUS { get; set; }
        //    public string? REPORTER_BY { get; set; }
        //}

        //public class ADQ_INCIDENT_TYPE_DETAILS
        //{
        //    public long INC_TYPE_ID { get; set; }
        //    public int INC_ID { get; set; }
        //    public string? INCIDENT_TYPE_ID { get; set; }
        //    public string? SAFETY_EQUIPMENT_ID { get; set; }
        //    public string? EN_EQUIPMENT_ID { get; set; }
        //}

        ////public class VIEW_INCIDENT_DETAILS
        ////{
        ////    public string? INC_ID { get; set; }
        ////    public string? INC_CAT_NAME { get; set; }
        ////    public string? INC_DATE_TIME { get; set; }
        ////    public string? EMP_FIRSTNAME { get; set; }
        ////    public string? DEP_NAME { get; set; }
        ////    public string? LOC_NAME { get; set; }
        ////    public string? SEC_NAME_EN { get; set; }
        ////    public string? SEC_LAB_NAME { get; set; }
        ////    public string? BUIL_NAME { get; set; }
        ////    public string? UNIQUE_ID { get; set; }
        ////    public string? INC_CAT_NAME_AR { get; set; }
        ////    public string? EMP_NAME_AR { get; set; }
        ////    public string? DEP_NAME_AR { get; set; }
        ////    public string? LOC_NAME_AR { get; set; }
        ////    public string? SEC_NAME_ARB { get; set; }
        ////    public string? SEC_LAB_NAME_AR { get; set; }
        ////    public string? BUIL_NAME_AR { get; set; }
        ////    public string? INC_STATUS { get; set; }
        ////    public string? REPORTER_BY { get; set; }
        ////    public string? REPORTED_BY { get; set; }
        ////    public string? DESCRIPTION { get; set; }


        ////    public List<ADQ_INCIDENT_TYPE_DETAILS> INCIDENT_TYPE_DETAILS { get; set; }
        ////}

        ////public class VIEW_INCIDENT_DETAILS_LIST
        ////{
        ////    public List<VIEW_INCIDENT_DETAILS> VIEW_INCIDENT_DETAILS { get; set; }
        ////    public List<ADQ_INCIDENT_TYPE_DETAILS> INCIDENT_TYPE_DETAILS { get; set; }
        ////    public List<UPLOAD_PHOTO_LIST> UPLOAD_PHOTO_LIST { get; set; }

        ////    public List<UPLOAD_INC_VIDEO_LIST> UPLOAD_INC_VIDEO_LIST { get; set; }
        ////    public bool STATUS { get; set; }
        ////    public string? MESSAGE { get; set; }
        ////}


        //public class UPLOAD_INC_VIDEO_LIST
        //{
        //    public string? INC_VIDEO_ID { get; set; }
        //    public string? INC_ID { get; set; }
        //    public string? INC_VIDEO_NAME { get; set; }
        //    public string? INC_VIDEO_PATH { get; set; }
        //    public int? INC_VIDEO_FILE_SIZE { get; set; }
        //    public string? INC_VIDEO_FILE_TYPE { get; set; }
        //    public string? INC_VIDEO_STATUS { get; set; }
        //    public string? INC_VIDEO_EXT { get; set; }
        //}


        //public class UPLOAD_INC_VIDEO
        //{
        //    public string? INC_VIDEO_ID { get; set; }
        //    public string? INC_ID { get; set; }
        //}


        //#endregion

        //#region [INCAT]
        //public class IncidentCategoryModel
        //{
        //    public long INC_CAT_ID { get; set; }
        //    public string? INC_CAT_NAME { get; set; }
        //    public string? INC_CAT_NAME_AR { get; set; }
        //    public DateTime CREATED_DATE { get; set; }
        //    public string? CREATED_BY { get; set; }
        //    public DateTime UPDATED_DATE { get; set; }
        //    public string? UPDATED_BY { get; set; }
        //    public bool STATUS { get; set; }
        //    public string? MESSAGE { get; set; }
        //    public string? STATUS_CODE { get; set; }
        //    public string? UNIQUE_ID { get; set; }

        //}

        //public class GET_INCIDENT_CATEGORY_DETAILS
        //{
        //    public long INC_CAT_ID { get; set; }
        //    public string? INC_CAT_NAME { get; set; }
        //    public string? INC_CAT_NAME_AR { get; set; }
        //    public string? CREATED_DATE { get; set; }
        //    public string? UNIQUE_ID { get; set; }
        //}
        //#endregion

        //#region [PHOTO_UPLOAD]
        //public class UPLOAD_PHOTO
        //{
        //    public List<UPLOAD_PHOTO_LIST>? UPLOAD_PHOTO_LIST { get; set; }
        //}

        ////public class UPLOAD_PHOTO_LIST
        ////{
        ////    public long INC_PHOTO_ID { get; set; }
        ////    public string? INC_ID { get; set; }
        ////    public string? INC_PHOTO_NAME { get; set; }
        ////    public string? INC_PHOTO_PATH { get; set; }
        ////    public string? INC_PHOTO_FILE_SIZE { get; set; }
        ////    public string? INC_PHOTO_FILE_TYPE { get; set; }
        ////    public string? INC_PHOTO_STATUS { get; set; }
        ////    public string? CREATED_DATE { get; set; }
        ////    public string? CREATED_BY { get; set; }
        ////    public string? UPDATED_DATE { get; set; }
        ////    public string? UPDATED_BY { get; set; }
        ////}
        //public class RETURN_MESSAGE
        //{
        //    public string? STATUS_CODE { get; set; }
        //    public string? MESSAGE { get; set; }
        //    public string? UNIQUE_ID { get; set; }
        //    public string? INSP_PLAN_ID { get; set; }
        //    public string? INSP_PLAN_SUB_ID { get; set; }
        //}
        //public class RETURN_MESSAGE_EVALUATION
        //{
        //    public string? STATUS_CODE { get; set; }
        //    public bool STATUS { get; set; }
        //    public string? MESSAGE { get; set; }
        //    public string? TRAINING_TO_EMP_ID { get; set; }
        //    public string? CREATED_BY { get; set; }
        //    public string? UNIQUE_ID { get; set; }


        //}
        //#endregion

        //#region [INVESTIGATION FORM]
        //public class INVESTCATION_DETAILS
        //{
        //    public List<INVE_IM_CASUE_ACT> INVE_IM_CASUE_ACT { get; set; }
        //    public List<INVE_IM_CASUE_UNC> INVE_IM_CASUE_UNC { get; set; }
        //    public List<INVE_IM_ROOT_PF> INVE_IM_ROOT_PF { get; set; }
        //    public List<INVE_IM_ROOT_SF> INVE_IM_ROOT_SF { get; set; }
        //    public List<INVE_IM_ROOT_METHOD> INVE_IM_ROOT_METHOD { get; set; }
        //    public List<INVE_IM_ROOT_ENVI> INVE_IM_ROOT_ENIV { get; set; }
        //    public List<INVE_IM_ROOT_MATERIAL> INVE_IM_ROOT_MATERIAL { get; set; }
        //    public List<INVE_NATURE_OF_INJURY> INVE_NATURE_OF_INJURY { get; set; }
        //    public List<INVE_MECHANISM_OF_INJURY> INVE_MECHANISM_OF_INJURY { get; set; }
        //    public List<INVE_SOURCE_OF_INJURY> INVE_SOURCE_OF_INJURY { get; set; }
        //    public List<INVE_BODY_LOC_CASUE> INVE_BODY_LOC_CASUE { get; set; }
        //    public List<ACTION_TAKEN_IMMEDIATELY> ACTION_TAKEN_IMMEDIATELY { get; set; }
        //    public List<INCIDENT_ROOT_CAUSE> INCIDENT_ROOT_CAUSE { get; set; }
        //    public List<CORRECTIVE_ACTION> CORRECTIVE_ACTION { get; set; }
        //    public List<INCIDENT_COST_ANALYSIS> INCIDENT_COST_ANALYSIS { get; set; }
        //    public List<INJURED_PERSONAL_DETAILS> INJURED_PERSONAL_DETAILS { get; set; }
        //    public List<RISK_ASSESSMENT_DETAILS> RISK_ASSESSMENT_DETAILS { get; set; }
        //    public List<DECLARATION_INJURED_PERSON> DECLARATION_INJURED_PERSON { get; set; }
        //    public List<MEDICAL_REPORT> MEDICAL_REPORT { get; set; }
        //    public List<ADD_INVE_SEQUENCE_EVENT> INVE_SEQUENCE_EVENT { get; set; }
        //    public List<GET_INTERVIEW_DETAILS> INTERVIEW_DETAILS { get; set; }
        //    public List<GET_SITE_INSPECTION> SITE_INSPECTION { get; set; }
        //    public List<GET_NEW_SITE_INSPECTION> NEW_SITE_INSPECTION { get; set; }
        //    public List<UPDATE_INCIDENT_STATUS> UPDATE_INCIDENT_STATUS { get; set; }



        //}
        //public class ADD_INVE_SEQUENCE_EVENT
        //{
        //    public string? SEQUENCE_ID { get; set; }
        //    public string? INC_ID { get; set; }
        //    public string? SEQUENCE_DATE { get; set; }
        //    public string? SEQUENCE_TIME { get; set; }
        //    public string? SEQUENCE_EVENT { get; set; }
        //    public string? CREATED_BY { get; set; }
        //}
        //public class INVE_IM_CASUE_ACT
        //{
        //    public string? INC_ID { get; set; }
        //    public string? INVE_IM_CAUSE_ID { get; set; }
        //    public string? INVE_OTHER_NAME { get; set; }
        //}

        //public class INVE_IM_CASUE_UNC
        //{
        //    public string? INC_ID { get; set; }
        //    public string? INVE_IM_CAUSE_UNC_ID { get; set; }
        //    public string? INVE_OTHER_NAME { get; set; }
        //}

        //public class INVE_IM_ROOT_PF
        //{
        //    public string? INC_ID { get; set; }
        //    public string? INVE_IM_ROOT_PF_ID { get; set; }
        //    public string? INVE_OTHER_NAME { get; set; }
        //}

        //public class INVE_IM_ROOT_SF
        //{
        //    public string? INC_ID { get; set; }
        //    public string? INVE_IM_ROOT_SF_ID { get; set; }
        //    public string? INVE_OTHER_NAME { get; set; }
        //}

        //public class INVE_IM_ROOT_METHOD
        //{
        //    public string? INC_ID { get; set; }
        //    public string? INVE_IM_METHOD_ID { get; set; }
        //    public string? INVE_OTHER_NAME { get; set; }
        //}

        //public class INVE_IM_ROOT_ENVI
        //{
        //    public string? INC_ID { get; set; }
        //    public string? INVE_IM_ENVI_ID { get; set; }
        //    public string? INVE_OTHER_NAME { get; set; }
        //}

        //public class INVE_IM_ROOT_MATERIAL
        //{
        //    public string? INC_ID { get; set; }
        //    public string? INVE_IM_MATERIAL_ID { get; set; }
        //    public string? INVE_OTHER_NAME { get; set; }
        //}

        //public class INVE_NATURE_OF_INJURY
        //{
        //    public string? INC_ID { get; set; }
        //    public string? NATURE_INJURY_NAME_ID { get; set; }
        //    public string? INVE_OTHER_NAME { get; set; }
        //}

        //public class INVE_MECHANISM_OF_INJURY
        //{
        //    public string? INC_ID { get; set; }
        //    public string? MECH_INJURY_NAME_ID { get; set; }
        //    public string? INVE_OTHER_NAME { get; set; }
        //}

        //public class INVE_SOURCE_OF_INJURY
        //{
        //    public string? INC_ID { get; set; }
        //    public string? SOURCE_INJURY_NAME_ID { get; set; }
        //    public string? INVE_OTHER_NAME { get; set; }
        //}

        //public class INVE_BODY_LOC_CASUE
        //{
        //    public string? INC_ID { get; set; }
        //    public string? INVE_IM_BODY_CAT_ID { get; set; }
        //    public string? INVE_IM_SUB_CAT_ID { get; set; }
        //    public string? INVE_OTHER_NAME { get; set; }
        //    public string? IMAGE_PATH { get; set; }
        //}

        //public class ACTION_TAKEN_IMMEDIATELY
        //{
        //    public string? INC_ID { get; set; }
        //    public string? ACTION_NAME { get; set; }
        //    public string? RESPONSIBILITY_ID { get; set; }
        //    public string? DATE { get; set; }
        //    public string? EMP_ID { get; set; }
        //    public string? RESPONSIBILITY_NAME_AR { get; set; }
        //}

        //public class INCIDENT_ROOT_CAUSE
        //{
        //    public string? INC_ID { get; set; }
        //    public string? ROOT_NAME { get; set; }
        //    public string? IMAGE_NAME { get; set; }
        //    public string? IMAGE_PATH { get; set; }
        //}

        //public class CORRECTIVE_ACTION
        //{
        //    public string? INC_ID { get; set; }
        //    public string? S_NO { get; set; }
        //    public string? ACTION { get; set; }
        //    public string? PERSON_RESPONSIBLE { get; set; }
        //    public string? TARGET_DATE { get; set; }
        //    public string? EMP_ID { get; set; }
        //    public string? PERSON_RESPONSIBLE_AR { get; set; }

        //}

        //public class INCIDENT_COST_ANALYSIS
        //{
        //    public string? INC_ID { get; set; }
        //    public string? INC_COST_ID { get; set; }
        //    public string? INC_COST_AMT { get; set; }
        //}

        //public class INJURED_PERSONAL_DETAILS
        //{
        //    public string? INC_ID { get; set; }
        //    public string? RELATIONSHIP_ID { get; set; }
        //    public string? EMPLOYEE_ID { get; set; }
        //    public string? OCCUPATION { get; set; }
        //    public string? NATIONALITY { get; set; }
        //    public string? DOB { get; set; }
        //    public string? PASSPORT_NUMBER { get; set; }
        //    public string? LENGTH_OF_SERVICE { get; set; }
        //    public string? CONTACT_PHONE_NUMBER { get; set; }
        //    public string? GENDER { get; set; }
        //    public string? EMP_ID { get; set; }
        //    public string? OCCUPATION_AR { get; set; }
        //    public string? EMP_NAME_AR { get; set; }
        //}

        //public class RISK_ASSESSMENT_DETAILS
        //{
        //    public string? INC_ID { get; set; }
        //    public string? RISK_ASSESSMENT_ID { get; set; }

        //}

        //public class DECLARATION_INJURED_PERSON
        //{
        //    public string? INC_ID { get; set; }
        //    public string? NAME_INJURED_PERSON { get; set; }
        //    public string? DATE { get; set; }
        //}
        //public class MEDICAL_REPORT
        //{
        //    public string? INC_ID { get; set; }
        //    public string? INJURY_NAME { get; set; }
        //    public string? NO_DAYS_NC { get; set; }
        //    public string? DOCUMENT_UPLOAD { get; set; }
        //}
        //#endregion

        //#region [NEAR_MISS_DETAILS]

        //public class GET_NEAR_MISS
        //{
        //    public string? NEARMISS_ID { get; set; }
        //    public string? DOCUMENT_NUMBER { get; set; }
        //    public string? VERSION_NUMBER { get; set; }
        //    public string? DATE { get; set; }
        //    public string? REPORTER_NAME { get; set; }
        //    public string? LOCATION { get; set; }
        //    public string? BUILDING { get; set; }
        //    public string? SECTOR { get; set; }
        //    public string? DEPARTMENT { get; set; }
        //    public string? SECTION_LAB { get; set; }
        //    public string? DESCRIPTION { get; set; }
        //    public string? STATUS { get; set; }
        //    public string? UNIQUE_ID { get; set; }

        //    public string? INVESTIGATED_BY { get; set; }
        //    public string? INVESTIGATED_DATE { get; set; }
        //    public string? HAZARD { get; set; }
        //    public string? ANTICIPATED_CAUSE { get; set; }
        //    public string? CORRECTIVE_ACTION { get; set; }
        //    public string? ADDITIONAL_RECOMMENDATION { get; set; }
        //}

        //public class ADD_NEAR_MISS
        //{
        //    public string? NEARMISS_ID { get; set; }
        //    public string? DOCUMENT_NUMBER { get; set; }
        //    public string? VERSION_NUMBER { get; set; }
        //    public string? DATE { get; set; }
        //    public string? REPORTER_NAME { get; set; }
        //    public string? LOCATION { get; set; }
        //    public string? BUILDING { get; set; }
        //    public string? SECTOR { get; set; }
        //    public string? DEPARTMENT { get; set; }
        //    public string? SECTION_LAB { get; set; }
        //    public string? DESCRIPTION { get; set; }
        //    public string? STATUS { get; set; }
        //    public string? CREATED_BY { get; set; }

        //    public string? INVESTIGATED_BY { get; set; }
        //    public string? INVESTIGATED_DATE { get; set; }
        //    public string? HAZARD { get; set; }
        //    public string? ANTICIPATED_CAUSE { get; set; }
        //    public string? CORRECTIVE_ACTION { get; set; }
        //    public string? ADDITIONAL_RECOMMENDATION { get; set; }

        //    public string? UPDATED_BY { get; set; }
        //}

        //public class RETURN_MESSAGE_UNIQUEID_EMR
        //{
        //    public string? STATUS_CODE { get; set; }
        //    public bool STATUS { get; set; }
        //    public string? MESSAGE { get; set; }
        //    public string? UNIQUE_ID { get; set; }

        //}
        //public class NEAR_MISS_PHOTO_UPLOAD
        //{
        //    public long NM_PHOTO_ID { get; set; }
        //    public string? NEARMISS_ID { get; set; }
        //    public string? NM_PHOTO_NAME { get; set; }
        //    public string? NM_PHOTO_PATH { get; set; }
        //    public string? NM_PHOTO_FILE_SIZE { get; set; }
        //    public string? NM_PHOTO_FILE_TYPE { get; set; }
        //    public string? NM_PHOTO_STATUS { get; set; }
        //    public string? CREATED_DATE { get; set; }
        //    public string? CREATED_BY { get; set; }
        //    public string? UPDATED_DATE { get; set; }
        //    public string? UPDATED_BY { get; set; }
        //}

        //public class EMP_PHOTO_UPLOAD
        //{
        //    public long EMP_PHOTO_ID { get; set; }
        //    public string? EMP_EMERG_TYPE_ID { get; set; }
        //    public string? EMP_ID { get; set; }
        //    public string? EMR_PHOTO_NAME { get; set; }
        //    public string? EMR_PHOTO_PATH { get; set; }
        //    public string? EMR_PHOTO_FILE_SIZE { get; set; }
        //    public string? EMR_PHOTO_FILE_TYPE { get; set; }
        //    public string? EMR_PHOTO_STATUS { get; set; }
        //    public string? CREATED_DATE { get; set; }
        //    public string? CREATED_BY { get; set; }
        //    public string? UPDATED_DATE { get; set; }
        //    public string? UPDATED_BY { get; set; }
        //    public string? ADDITIONAL { get; set; }
        //}

        //public class NEAR_MISS_CORRECTIVE_ACTION
        //{
        //    public long CR_PHOTO_ID { get; set; }
        //    public string? NEARMISS_ID { get; set; }
        //    public string? CR_PHOTO_NAME { get; set; }
        //    public string? CR_PHOTO_PATH { get; set; }
        //    public string? CR_PHOTO_FILE_SIZE { get; set; }
        //    public string? CR_PHOTO_FILE_TYPE { get; set; }
        //    public string? CR_PHOTO_STATUS { get; set; }
        //    public string? CREATED_DATE { get; set; }
        //    public string? CREATED_BY { get; set; }
        //    public string? UPDATED_DATE { get; set; }
        //    public string? UPDATED_BY { get; set; }
        //    public string? CR_PHOTO_FILE_DATA { get; set; }
        //}


        //public class NEAR_MISS_VIDEO_UPLOAD
        //{
        //    public long NM_VIDEO_ID { get; set; }
        //    public string? NEARMISS_ID { get; set; }
        //    public string? NM_VIDEO_NAME { get; set; }
        //    public string? NM_VIDEO_PATH { get; set; }
        //    public string? NM_VIDEO_FILE_SIZE { get; set; }
        //    public string? NM_VIDEO_FILE_TYPE { get; set; }
        //    public string? NM_VIDEO_STATUS { get; set; }
        //    public string? CREATED_DATE { get; set; }
        //    public string? CREATED_BY { get; set; }
        //    public string? UPDATED_DATE { get; set; }
        //    public string? UPDATED_BY { get; set; }
        //}

        //public class EMP_VIDEO_UPLOAD
        //{
        //    public long EMP_VIDEO_ID { get; set; }
        //    public string? EMP_EMERG_TYPE_ID { get; set; }
        //    public string? EMP_ID { get; set; }
        //    public string? EMR_VIDEO_NAME { get; set; }
        //    public string? EMR_VIDEO_PATH { get; set; }
        //    public string? EMR_VIDEO_FILE_SIZE { get; set; }
        //    public string? EMR_VIDEO_FILE_TYPE { get; set; }
        //    public string? EMR_VIDEO_STATUS { get; set; }
        //    public string? CREATED_DATE { get; set; }
        //    public string? CREATED_BY { get; set; }
        //    public string? UPDATED_DATE { get; set; }
        //    public string? UPDATED_BY { get; set; }
        //    public string? ADDITIONAL { get; set; }
        //}

        //public class GETEMRTEAMFILES
        //{

        //    public List<EMP_PHOTO_UPLOAD> EMP_PHOTO_UPLOAD { get; set; }
        //    public List<EMP_VIDEO_UPLOAD> EMP_VIDEO_UPLOAD { get; set; }

        //}
        //public class RETURN_GETEMRTEAMFILES
        //{
        //    public GETEMRTEAMFILES UPLOADED_FILES { get; set; }
        //    public string? STATUS_CODE { get; set; }
        //    public bool STATUS { get; set; }
        //    public string? MESSAGE { get; set; }
        //}
        //public class UPDATE_NEARMISS_STATUS
        //{
        //    public string? NEARMISS_ID { get; set; }
        //    public string? NEARMISS_STATUS { get; set; }
        //}


        //public class UPDATE_NEARMISS_INVESTIGATION
        //{
        //    public string? NEARMISS_ID { get; set; }
        //    public string? INVESTIGATED_BY { get; set; }
        //    public string? INVESTIGATED_DATE { get; set; }
        //    public string? HAZARD { get; set; }
        //    public string? ANTICIPATED_CAUSE { get; set; }
        //    public string? CORRECTIVE_ACTION { get; set; }
        //    public string? ADDITIONAL_RECOMMENDATION { get; set; }
        //}

        //public class GET_NEAR_MISS_LIST
        //{
        //    public string? MESSAGE { get; set; }
        //    public string? STATUS { get; set; }
        //    public List<GET_NEAR_MISS> NEARMISSLIST { get; set; }
        //}


        //public class GET_NEAR_MISS_DETAILS
        //{
        //    public string? NEARMISS_ID { get; set; }
        //    public string? DOCUMENT_NUMBER { get; set; }
        //    public string? VERSION_NUMBER { get; set; }
        //    public string? DATE { get; set; }
        //    public string? REPORTER_NAME { get; set; }
        //    public string? LOCATION { get; set; }
        //    public string? BUILDING { get; set; }
        //    public string? SECTOR { get; set; }
        //    public string? DEPARTMENT { get; set; }
        //    public string? SECTION_LAB { get; set; }
        //    public string? DESCRIPTION { get; set; }
        //    public string? STATUS { get; set; }
        //    public string? UNIQUE_ID { get; set; }
        //    public string? INVESTIGATED_BY { get; set; }
        //    public string? INVESTIGATED_DATE { get; set; }
        //    public string? HAZARD { get; set; }
        //    public string? ANTICIPATED_CAUSE { get; set; }
        //    public string? CORRECTIVE_ACTION { get; set; }
        //    public string? ADDITIONAL_RECOMMENDATION { get; set; }
        //    public string? LOCATION_AR { get; set; }
        //    public string? BUILDING_AR { get; set; }
        //    public string? SECTOR_AR { get; set; }
        //    public string? DEPARTMENT_AR { get; set; }
        //    public string? SECTION_LAB_AR { get; set; }
        //    public List<NEAR_MISS_PHOTO_UPLOAD> _NEAR_MISS_PHOTO_UPLOAD { get; set; }
        //    public List<NEAR_MISS_VIDEO_UPLOAD> _NEAR_MISS_VIDEO_UPLOAD { get; set; }
        //    public List<NEAR_MISS_CORRECTIVE_ACTION> _NEAR_CORRECTIVE_PHOTO_UPLOAD { get; set; }
        //}


        //public class GET_NEAR_MISS_LIST_DETAILS
        //{
        //    public string? MESSAGE { get; set; }
        //    public string? STATUS { get; set; }
        //    public GET_NEAR_MISS_DETAILS GET_NEAR_MISS_LIST { get; set; }
        //}
        //#endregion

        #region [Emergency Team Activate]
        public class EMERGENCY_TYPE_MASTER_SELECT_ID
        {
            public string? EMERG_TYPE_MAS_ID { get; set; }
            public string? EMP_EMERG_TYPE_ID { get; set; }
            public string? EMP_ID { get; set; }
            public string? EMP_FIRSTNAME { get; set; }
            public string? IS_ACTIVE { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? EMERG_TYPE_MAS { get; set; }
            public string? ACCEPT_REJECT_STATUS { get; set; }
            public string? TASK { get; set; }
            public string? TASK_DES { get; set; }
            public string? REVIEW_DATE { get; set; }
            public string? ACTION_TAKEN { get; set; }
            public string? EMP_NAME_AR { get; set; }
        }

        public class EMERGENCY_TEAM_CORRECTIVE
        {
            public string? EMP_ACTIVE_ID { get; set; }
            public string? IMAGE_PATH { get; set; }
            public string? REMARKS { get; set; }
            public string? EMP_ID { get; set; }

        }
        public class EMERGENCY_TEAM_GET
        {
            public string? EMERG_TYPE_MAS_ID { get; set; }
            public string? LOC_ID { get; set; }
            public string? BUILD_ID { get; set; }
            public string? LEVEL_ID { get; set; }

        }
        public class GET_EMERGENCY_TYPE_MASTER_SELECT
        {
            public string? EMP_ACTIVE_ID { get; set; }
            public string? EMR_TEAM_TYPE { get; set; }
            public string? LEAD_MANAGER { get; set; }
            public string? LOCATION { get; set; }
            public string? BUILDING { get; set; }
            public string? SECTOR { get; set; }
            public string? DEPARTMENT { get; set; }
            public string? SECTIONLAB { get; set; }
            public string? LOCATION_NAME { get; set; }
            public string? BUILDING_NAME { get; set; }
            public string? SECTOR_NAME { get; set; }
            public string? DEPARTMENT_NAME { get; set; }
            public string? SECTION_LAB_NAME { get; set; }
            public string? CREATED_BY_NAME { get; set; }
            public string? EMERG_TYPE_NAME { get; set; }
            public string? SCHEDULE { get; set; }
            public string? UNIQUE_ID { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? ActiveDeactive { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? ACCEPT_REJECT_STATUS { get; set; }
            public string? EMP_NAME_AR { get; set; }
            public string? EMERG_TYPE_NAME_AR { get; set; }
        }

        public class ADD_EMERGENCY_TYPE_MASTER_SELECT
        {
            public string? EMP_ACTIVE_ID { get; set; }
            public string? EMR_TEAM_TYPE { get; set; }
            public string? LEAD_MANAGER { get; set; }
            public string? LOCATION { get; set; }
            public string? BUILDING { get; set; }
            public string? SECTOR { get; set; }
            public string? DEPARTMENT { get; set; }
            public string? SECTIONLAB { get; set; }
            public string? SCHEDULE { get; set; }
            public string? FLOOR { get; set; }
        }

        public class ADD_EMERGENCY_TYPE_CORRECTIVE_ACTION
        {
            public string? EMR_CORRECTIVE_ID { get; set; }
            public string? EMP_ACTIVE_ID { get; set; }
            public string? REMARKS { get; set; }
            public string? DESCRIPTION { get; set; }
            public string? IMAGE_PATH { get; set; }
            public string? IMAGE_NAME { get; set; }
            public string? IMAGE_SIZE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? EMP_ID { get; set; }
            public string? REVIEW_DATE { get; set; }
        }

        public class Get_EMERGENCY_TYPE_CORRECTIVE_ACTION
        {
            public string? EMR_CORRECTIVE_ID { get; set; }
            public string? EMP_ACTIVE_ID { get; set; }
            public string? REMARKS { get; set; }
            public string? DESCRIPTION { get; set; }
            public string? IMAGE_PATH { get; set; }
            public string? IMAGE_NAME { get; set; }
            public string? IMAGE_SIZE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? EMP_ID { get; set; }
            public string? EMP_FIRSTNAME { get; set; }
            public string? REVIEW_DATE { get; set; }
        }
        public class ADD_EMERGENCY_CORRECTIVE_LIST
        {

            public List<ADD_EMERGENCY_TYPE_CORRECTIVE_ACTION> Emergency_corrective_Action { get; set; }
        }

        public class Get_EMERGENCY_CORRECTIVE_LIST
        {

            public List<Get_EMERGENCY_TYPE_CORRECTIVE_ACTION> Emergency_corrective_Action { get; set; }
        }
        public class ADD_EMR_TEAM_ADDITIONAL_ACTION
        {

            public List<EMR_TEAM_ADDITIONAL_ACTION> Emergency_Additional_Action { get; set; }
        }
        public class GET_EMERGENCY_TYPE_BY_ID
        {
            public string? EMP_ACTIVE_ID { get; set; }
            public string? EMR_TEAM_TYPE { get; set; }
            public string? LEAD_MANAGER { get; set; }
            public string? LOCATION { get; set; }
            public string? BUILDING { get; set; }
            public string? SECTOR { get; set; }
            public string? DEPARTMENT { get; set; }
            public string? SECTIONLAB { get; set; }
            public string? CREATED_BY_NAME { get; set; }
            public string? EMERG_TYPE_NAME { get; set; }
            public string? SCHEDULE { get; set; }
            public string? UNIQUE_ID { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? FLOOR { get; set; }
            public List<EMERGENCY_TYPE_MASTER_SELECT_ID> EMERGENCY_TYPE_MASTER_SELECT_ID { get; set; }
            public List<EMERGENCY_TEAM_CORRECTIVE> EMERGENCY_TEAM_CORRECTIVE { get; set; }
            public List<UPLOAD_DOCUMENT> UPLOAD_DOCUMENT { get; set; }
            public List<V_EMR_TEAM_ADDITIONAL_ACTION> EMR_TEAM_ADDITIONAL_ACTION { get; set; }
        }

        public class GET_DOCUMENT_NO
        {
            public string? DOCUMENT_NUMBER { get; set; }
        }
        #endregion


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


        public class EMP_EMR_TASK
        {
            public string? EMP_ID { get; set; }
            public string? TASK { get; set; }
            public string? TASK_DES { get; set; }
            public string? REVIEW_DATE { get; set; }

        }
        public class ADD_REVIEW_AND_APPROVALS
        {
            public string? REVIEW_APPROVAL_ID { get; set; }
            public string? INC_ID { get; set; }
            public string? EXECUTIVE_SUMMARY { get; set; }
            public string? INTRODUCTION { get; set; }
            public string? CONCLUSION { get; set; }
            public string? CONTAINMENT_ACTIONS { get; set; }
            public string? COMPLETE_INVESTIGATION { get; set; }
            public string? RELEVANT_EVIDENCE { get; set; }
            public string? CORRECTIVE_ACTIONS { get; set; }
            public string? INC_INVE_STATUS_CLOSED { get; set; }
            public string? INC_INVE_STATUS_ATTACHED { get; set; }
            public string? CREATED_BY { get; set; }
            public string? EHS_ALERT_ID { get; set; }
            public string? WHAT_HAPPENED { get; set; }
            public string? WHERE_HAPPENED { get; set; }
            public string? WHEN_HAPPENED { get; set; }
            public string? WHO_INVOLVED { get; set; }
            public string? HOW_HAPPENED { get; set; }
            public string? ROOT_CAUSE { get; set; }
            public string? PREVENTIVE_ACTION { get; set; }
            public string? RISK_ASSESSMENT { get; set; }
            public string? SAFETY_AWARENESS { get; set; }
            public string? RECOMMENDED_PPE { get; set; }
            public string? RECOMMENDED_ACTION { get; set; }
            public string? INC_IMAGE { get; set; }
            public string? KEY_IMAGE { get; set; }
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

        public class GET_FINAL_REVIEW_AND_APPROVALS
        {
            public string? FINAL_REVIEW_APPROVAL_ID { get; set; }
            public string? INC_ID { get; set; }
            public string? FINAL_EXECUTIVE_SUMMARY { get; set; }
            public string? FINAL_INTRODUCTION { get; set; }
            public string? FINAL_CONCLUSION { get; set; }
            public string? FINAL_CONTAINMENT_ACTIONS { get; set; }
            public string? CREATED_BY { get; set; }
        }

        public class GET_EMR_SEQUENCE_EVENT
        {
            public string? SEQUENCE_ID { get; set; }
            public string? SEQUENCE_DATE { get; set; }
            public string? SEQUENCE_TIME { get; set; }
            public string? SEQUENCE_EVENT { get; set; }
            public string? INC_ID { get; set; }
        }

        public class GET_EMR_INTERVIEW_DETAILS
        {
            public string? INTERVIEW_ID { get; set; }
            public string? INC_ID { get; set; }
            public string? FEED_BACK { get; set; }
            public string? INTERVIEWER_NAME { get; set; }
            public string? INTERVIEWE_NAME { get; set; }
            public string? INTERVIEWER_ID { get; set; }
            public string? INTERVIEWEE_ID { get; set; }
            public string? INTERVIEWER_NAME_AR { get; set; }
            public string? INTERVIEWE_NAME_AR { get; set; }
        }

        public class GET_EMR_DOCUMENT_DETAILS
        {
            public string? SITE_INSP_ID { get; set; }
            public string? INC_ID { get; set; }
            public string? DOCUMENT_UPLOAD { get; set; }
            public string? DOCUMENT_REVIEWER { get; set; }
            public string? DOCUMENT_NAME { get; set; }
        }
        public class GET_EMR_NEW_SITE_INSPECTION
        {
            public string? NEW_SITE_INSP_ID { get; set; }
            public string? INC_ID { get; set; }
            public string? NEW_SITE_DESCRIPTION { get; set; }
            public string? IMAGE_UPLOAD { get; set; }
            public string? LOC_NAME { get; set; }
            public string? LOC_ID { get; set; }
            public string? LOC_NAME_AR { get; set; }
            public string? INC_PHOTO_PATH { get; set; }
        }

        public class GET_EMR_REVIEW_AND_APPROVALS
        {
            public string? REVIEW_APPROVAL_ID { get; set; }
            public string? INC_ID { get; set; }
            public string? EXECUTIVE_SUMMARY { get; set; }
            public string? INTRODUCTION { get; set; }
            public string? CONCLUSION { get; set; }
            public string? CONTAINMENT_ACTIONS { get; set; }
            public string? COMPLETE_INVESTIGATION { get; set; }
            public string? RELEVANT_EVIDENCE { get; set; }
            public string? CORRECTIVE_ACTIONS { get; set; }
            public string? INC_INVE_STATUS_CLOSED { get; set; }
            public string? INC_INVE_STATUS_ATTACHED { get; set; }

        }
        #region [INVESTIGATION REJECT PLAN]
        public class ADD_INC_REJECT_REASON_PLAN
        {
            public string? INC_REJECT_ID { get; set; }
            public string? INC_ID { get; set; }
            public string? REJECT_DESCRIPTION { get; set; }
            public string? CREATED_BY { get; set; }
            public string? HT_STATUS { get; set; }
            public string? UNIQUE_ID { get; set; }
        }
        public class GET_INV_REJECT_REASON
        {
            public string? INC_REJECT_ID { get; set; }
            public string? INC_ID { get; set; }
            public string? REJECT_DESCRIPTION { get; set; }
            public string? CREATED_BY { get; set; }
            public string? HT_STATUS { get; set; }
            public string? UNIQUE_ID { get; set; }
            public string? EMP_FIRSTNAME { get; set; }
            public string? EMP_NAME_AR { get; set; }
        }
        #endregion


        public class GET_INVE_EHS_ALERT
        {
            public string? INC_ID { get; set; }
            public string? CREATED_BY { get; set; }
            public string? EHS_ALERT_ID { get; set; }
            public string? WHAT_HAPPENED { get; set; }
            public string? WHERE_HAPPENED { get; set; }
            public string? WHEN_HAPPENED { get; set; }
            public string? WHO_INVOLVED { get; set; }
            public string? HOW_HAPPENED { get; set; }
            public string? ROOT_CAUSE { get; set; }
            public string? PREVENTIVE_ACTION { get; set; }
            public string? RISK_ASSESSMENT { get; set; }
            public string? SAFETY_AWARENESS { get; set; }
            public string? RECOMMENDED_PPE { get; set; }
            public string? RECOMMENDED_ACTION { get; set; }
            public string? INC_IMAGE { get; set; }
            public string? KEY_IMAGE { get; set; }
        }
        public class EMR_TEAM_ADDITIONAL_ACTION
        {
            public string? EMR_ADDITIONAL_ID { get; set; }
            public string? TASK { get; set; }
            public string? TASK_DESCRIPTION { get; set; }
            public string? CORRECIVE_REMARK { get; set; }
            public string? EMP_ACTIVE_ID { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? EMP_ID { get; set; }
            public string? REVIEW_DATE { get; set; }
            public string? EMERG_TYPE_MAS_ID { get; set; }
            public string? LEVEL { get; set; }
            public string? LOC_ID { get; set; }
            public string? BUILD_ID { get; set; }
        }
        public class V_EMR_TEAM_ADDITIONAL_ACTION
        {
            public string? EMR_ADDITIONAL_ID { get; set; }
            public string? TASK { get; set; }
            public string? TASK_DESCRIPTION { get; set; }
            public string? CORRECIVE_REMARK { get; set; }
            public string? EMP_ACTIVE_ID { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? EMP_ID { get; set; }
            public string? REVIEW_DATE { get; set; }
            public string? EMERG_TYPE_MAS_ID { get; set; }
            public string? LEVEL { get; set; }
            public string? LOC_ID { get; set; }
            public string? BUILD_ID { get; set; }
            public string? ACTION_TAKEN { get; set; }
            public string? EMP_FIRSTNAME { get; set; }
            public string? EMERG_TYPE_MAS { get; set; }
            public string? EMERG_TYPE_MAS_AR { get; set; }
            public string? EMP_NAME_AR { get; set; }
        }
        public class GET_FS_Acknowledge
        {
            public string? INC_ID { get; set; }
            public string? NAME_INJURED_PERSON { get; set; }
            public string? DATE { get; set; }
        }

        //public class GET_INVE_CORRECTIVE_ACTION
        //{
        //    public string? INC_ID { get; set; }
        //    public string? LOC_NAME { get; set; }
        //    public string? LOC_NAME_AR { get; set; }
        //    public string? INC_CAT_NAME { get; set; }
        //    public string? INC_CAT_NAME_AR { get; set; }
        //    public string? INC_STATUS { get; set; }
        //    public string? INC_DATE { get; set; }
        //    public string? UNIQUE_ID { get; set; }
        //    public string? NON_INVEST_STATUS { get; set; }
        //    public string? ACTION { get; set; }
        //    public string? TARGET_DATE { get; set; }
        //    public string? PERSON_RESPONSIBLE { get; set; }
        //    public string? EMP_FIRSTNAME { get; set; }
        //    public string? EMP_NAME_AR { get; set; }
        //    public string? CORRECTION_STATUS { get; set; }
        //    public string? DUE_DATE { get; set; }
        //    public string? DUE_DATE_AR { get; set; }
        //}

        //public class ADD_INVE_CORRECTIVE_ACTION
        //{
        //    public string? COR_INC_ID { get; set; }
        //    public string? CORR_IMAGE_PATH { get; set; }
        //    public string? CORR_DESCRIPTION { get; set; }
        //    public string? CORR_UPDATED_BY { get; set; }
        //    public string? STATUS { get; set; }

        //}

        //public class VIEW_INVE_CORRECTIVE_ACTION
        //{
        //    public string? INVE_CORRECTIVE_ID { get; set; }
        //    public string? INC_ID { get; set; }
        //    public string? CORR_IMAGE_PATH { get; set; }
        //    public string? CORR_DESCRIPTION { get; set; }
        //    public string? ACTION { get; set; }
        //    public string? TARGET_DATE { get; set; }
        //    public string? UNIQUE_ID { get; set; }

        //}
        //public class UPDATE_INVE_CORRECTIVE_ACTION_STATUS
        //{
        //    public string? COR_INC_ID { get; set; }
        //    public string? APP_STATUS { get; set; }
        //}
        #region [LOST TIME INJURY CALCULATION]
        public class GET_EMR_LTIR_CALC
        {
            public string? LOST_TIME_INJURY_ID { get; set; }
            public string? LOST_TIME_INJURY_VALUE { get; set; }
            public string? YEAR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? UNIQUE_ID { get; set; }
        }
        public class ADD_EMR_EMR_LTIR_CALC
        {
            public string? LOST_TIME_INJURY_ID { get; set; }
            public string? LOST_TIME_INJURY_VALUE { get; set; }
            public string? YEAR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? UNIQUE_ID { get; set; }
        }
        #endregion

        #region [PREVENTIVE ACTION]
        public class REJECT_REASON_CORRECTIVE_ACTION
        {
            public string? REJECT_ID { get; set; }
            public string? REJECT_NAME { get; set; }
            public string? REJECT_DESCRIPTION { get; set; }
            public string? REJECT_REASON_ID { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? REJECT_UNIQUE_ID { get; set; }
        }

        public class GET_REJECT_REASON_CORRECTIVE_ACTION
        {
            public string? REJECT_REASON_ID { get; set; }
            public string? REJECT_NAME { get; set; }
            public string? REJECT_DESCRIPTION { get; set; }
            public string? REJECT_UNIQUE_ID { get; set; }
            public string? REJECT_BY_AR { get; set; }
        }
        #endregion

        #region [NEW SITE INSPECTION PHOTOS]
        public class SITE_INSP_UPLOAD_PHOTO
        {
            public List<SITE_INSPECTION_PHOTO_LIST> SITE_INSPECTION_PHOTO_LIST { get; set; }
        }

        public class SITE_INSPECTION_PHOTO_LIST
        {
            public long SITE_INSP_ID { get; set; }
            public string? INC_ID { get; set; }
            public string? INC_PHOTO_NAME { get; set; }
            public string? INC_PHOTO_PATH { get; set; }
            public string? INC_PHOTO_FILE_SIZE { get; set; }
            public string? INC_PHOTO_FILE_TYPE { get; set; }
            public string? INC_PHOTO_STATUS { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
        }
        #endregion

        #region [DISASTER_TYPE]
        public class GET_EMR_DISASTER_TYPE
        {
            public string? DISASTER_ID { get; set; }
            public string? DISASTER_NAME { get; set; }
            public string? DISASTER_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? UNIQUE_ID { get; set; }
        }

        public class ADD_EMR_DISASTER_TYPE
        {
            public string? DISASTER_ID { get; set; }
            public string? DISASTER_NAME { get; set; }
            public string? DISASTER_NAME_AR { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? UNIQUE_ID { get; set; }
        }
        #endregion

        public class GET_EMR_TYPE_MASTER
        {
            public string? EMERG_TYPE_MAS_ID { get; set; }
            public string? EMERG_TYPE_MAS { get; set; }
            public string? EMERG_TYPE_MAS_AR { get; set; }
            public string? STATUS { get; set; }
            public string? CREATED_DATE { get; set; }
            public string? UNIQUE_ID { get; set; }
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
            public List<EMERG_TYPE_SELECT>? EMERG_TYPE_SELECT { get; set; }
            public string? EMP_EMERG_TYPE_ID { get; set; }
            public string? EMP_ID { get; set; }
            public string? EMERG_TYPE_MAS_ID { get; set; }
            public string? CREATED_BY { get; set; }
            public string? LOC_ID { get; set; }
            public string? BUILD_ID { get; set; }
            public string? LEVEL { get; set; }
        }
    }
}
