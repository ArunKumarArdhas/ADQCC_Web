
namespace ADQCC_New.Models.RiskManagement
{
    public class RiskManagementModel
    {
        public class COMMON
        {
            public string? CREATED_DATE { get; set; }
            public string? CREATED_BY { get; set; }
            public string? UPDATED_DATE { get; set; }
            public string? UPDATED_BY { get; set; }
            public string? UNIQUE_ID { get; set; }
            public string? STATUS_CODE { get; set; }
            public string? STATUS { get; set; }
            public string? IS_ACTIVE { get; set; }
        }


        #region [Hazard Master ]
        public class GET_RM_HAZARD_MASTER : COMMON
        {
            public string HAZARD_MAS_ID { get; set; }
            public string HAZ_RISK_CAT_MAS_ID { get; set; }
            public string HAZARD_MAS_NAME { get; set; }
            public string HAZARD_MAS_NAME_AR { get; set; }
            public string RISK_CAT_MAS_NAME { get; set; }
            public string RISK_CAT_MAS_NAME_AR { get; set; }
            public string STATUS { get; set; }
            public object Get_All_HazardMaster { get; internal set; }
        }

        public class ADD_RM_HAZARD_MASTER : COMMON
        {
            public string HAZARD_MAS_ID { get; set; }
            public string HAZ_RISK_CAT_MAS_ID { get; set; }
            public string HAZARD_MAS_NAME { get; set; }
            public string HAZARD_MAS_NAME_AR { get; set; }
            public string STATUS { get; set; }
        }

        public class GET_HAZRDMASTER
        {
            public List<GET_RM_HAZARD_MASTER>? Get_All { get; set; }
            public string? STATUS_CODE { get; set; }
            public bool? SUCCESS { get; set; }
            public string? MESSAGE { get; set; }

           
        }


        #endregion


        #region[RISKS_OTHER_RISKS]
        public class GET_RM_RISKS_OTHER_RISKS : COMMON
        {
            public string RISKS_OTHER_RISKS_ID { get; set; }
            public string RISK_CAT_MAS_ID { get; set; }
            public string RISKS_HAZARD_MAS_ID { get; set; }
            public string RISKS_OTHER_RISKS_NAME { get; set; }
            public string RISKS_OTHER_RISKS_NAME_AR { get; set; }
            public string RISK_CAT_MAS_NAME { get; set; }
            public string HAZARD_MAS_NAME { get; set; }
            public string RISK_CAT_MAS_NAME_AR { get; set; }
            public string HAZARD_MAS_NAME_AR { get; set; }
            public string STATUS { get; set; }

        }
        public class ADD_RM_RISKS_OTHER_RISKS : COMMON
        {
            public string RISKS_OTHER_RISKS_ID { get; set; }
            public string RISK_CAT_MAS_ID { get; set; }
            public string RISKS_HAZARD_MAS_ID { get; set; }
            public string RISKS_OTHER_RISKS_NAME { get; set; }
            public string RISKS_OTHER_RISKS_NAME_AR { get; set; }
            public string STATUS { get; set; }

        }

        public class GET_RISKSOTHERRISKS
        {
            public List<GET_RM_RISKS_OTHER_RISKS>? Get_All { get; set; }
            public string? STATUS_CODE { get; set; }
            public bool? SUCCESS { get; set; }
            public string? MESSAGE { get; set; }

        }
        #endregion

        #region [Risk Category Master]
        public class GET_RM_RISK_CAT_MASTER
        {
            public string RISK_CAT_MAS_ID { get; set; }
            public string RISK_CAT_MAS_NAME { get; set; }
            public string RISK_CAT_MAS_NAME_AR { get; set; }
            public string CREATED_DATE { get; set; }
            public string STATUS { get; set; }
        }

        public class ADD_RM_RISK_CAT_MASTER
        {
            public string RISK_CAT_MAS_ID { get; set; }
            public string RISK_CAT_MAS_NAME { get; set; }
            public string RISK_CAT_MAS_NAME_AR { get; set; }
            public string CREATED_DATE { get; set; }
            public string STATUS { get; set; }
            public string CREATED_BY { get; set; }
            public string UPDATED_DATE { get; set; }
            public string UPDATED_BY { get; set; }
            public string STATUS_CODE { get; set; }


        }

        #endregion

        #region [Persons/Groups Exposed]
        public class GET_RM_PERSONS_GROUPS
        {
            public string PERSON_GROUP_ID { get; set; }
            public string RISK_CAT_MAS_ID { get; set; }
            public string PG_HAZARD_MAS_ID { get; set; }
            public string PERSON_GROUP_NAME { get; set; }
            public string PERSON_GROUP_NAME_AR { get; set; }
            public string RISK_CAT_MAS_NAME { get; set; }
            public string HAZARD_MAS_NAME { get; set; }
            public string CREATED_DATE { get; set; }
            public string STATUS { get; set; }
            public string UNIQUE_ID { get; set; }
        }

        public class ADD_RM_PERSONS_GROUPS
        {
            public string PERSON_GROUP_ID { get; set; }
            public string RISK_CAT_MAS_ID { get; set; }
            public string PG_HAZARD_MAS_ID { get; set; }
            public string PERSON_GROUP_NAME { get; set; }
            public string PERSON_GROUP_NAME_AR { get; set; }
            public string CREATED_DATE { get; set; }
            public string STATUS { get; set; }
            public string CREATED_BY { get; set; }
            public string UPDATED_DATE { get; set; }
            public string UPDATED_BY { get; set; }
            public string STATUS_CODE { get; set; }
            public string UNIQUE_ID { get; set; }
        }

        public class GET_PERSONSGROUPS
        {
            public List<GET_RM_PERSONS_GROUPS>? Get_All { get; set; }
            public string? STATUS_CODE { get; set; }
            public bool? SUCCESS { get; set; }
            public string? MESSAGE { get; set; }

        }
        #endregion

        #region [Details of any Existing Controls]
        public class GET_RM_DETAILS_EXIST_CONT : COMMON
        {
            public string DETAILS_EXIST_CONT_ID { get; set; }
            public string RISK_CAT_MAS_ID { get; set; }
            public string DEC_HAZARD_MAS_ID { get; set; }
            public string DETAILS_EXIST_CONT_NAME { get; set; }
            public string DETAILS_EXIST_CONT_NAME_AR { get; set; }
            public string RISK_CAT_MAS_NAME { get; set; }
            public string HAZARD_MAS_NAME { get; set; }
            public string STATUS { get; set; }
        }

        public class ADD_RM_DETAILS_EXIST_CONT : COMMON
        {
            public string DETAILS_EXIST_CONT_ID { get; set; }
            public string RISK_CAT_MAS_ID { get; set; }
            public string DEC_HAZARD_MAS_ID { get; set; }
            public string DETAILS_EXIST_CONT_NAME { get; set; }
            public string DETAILS_EXIST_CONT_NAME_AR { get; set; }
            public string STATUS { get; set; }

        }


        public class GET_DETAILS
        {
            public List<GET_RM_DETAILS_EXIST_CONT>? Get_All { get; set; }
            public string? STATUS_CODE { get; set; }
            public bool? SUCCESS { get; set; }
            public string? MESSAGE { get; set; }

        }
        #endregion
        #region [Additional Control Measures]
        public class GET_RM_ADD_CONT_MEAS : COMMON
        {
            public string ADD_CONT_MEAS_ID { get; set; }
            public string RISK_CAT_MAS_ID { get; set; }
            public string ACM_HAZARD_MAS_ID { get; set; }
            public string ADD_CONT_MEAS_NAME { get; set; }
            public string ADD_CONT_MEAS_NAME_AR { get; set; }
            public string RISK_CAT_MAS_NAME { get; set; }
            public string HAZARD_MAS_NAME { get; set; }
            public string STATUS { get; set; }
        }

        public class ADD_RM_ADD_CONT_MEAS : COMMON
        {
            public string ADD_CONT_MEAS_ID { get; set; }
            public string RISK_CAT_MAS_ID { get; set; }
            public string ACM_HAZARD_MAS_ID { get; set; }
            public string ADD_CONT_MEAS_NAME { get; set; }
            public string ADD_CONT_MEAS_NAME_AR { get; set; }
            public string STATUS { get; set; }
        }

        public class GET_ADDITIONAL
        {
            public List<GET_RM_ADD_CONT_MEAS>? Get_All { get; set; }
            public string? STATUS_CODE { get; set; }
            public bool? SUCCESS { get; set; }
            public string? MESSAGE { get; set; }

        }
        #endregion

    }
}