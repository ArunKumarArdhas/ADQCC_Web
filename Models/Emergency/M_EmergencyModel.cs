using ADQCC_New.Models.Masters;

namespace ADQCC_New.Models.Emergency
{
    public class GET_EMERGENCY_LIST
    {
        public IReadOnlyCollection<M_EmergencyModel>? Get_All_UnSafeAct { get; set; }
        public M_EmergencyModel? Get_ById_UnSafeAct { get; set; }
        public IReadOnlyCollection<UNSAFECONDITION_MASTER>? Get_All_Condition { get; set; }
        public UNSAFECONDITION_MASTER? Get_ById_Condition { get; set; }
        public IReadOnlyCollection<ROOT_CAUSE_PERSONAL_MASTER>? Get_All_Personal { get; set; }
        public ROOT_CAUSE_PERSONAL_MASTER? Get_ById_Personal { get; set; }
        public IReadOnlyCollection<ROOT_CAUSE_SYSTEM_MASTER>? Get_All_System { get; set; }
        public ROOT_CAUSE_SYSTEM_MASTER? Get_ById_System { get; set; }
        public IReadOnlyCollection<ROOT_CAUSE_METHOD_MASTER>? Get_All_Method { get; set; }
        public ROOT_CAUSE_METHOD_MASTER? Get_ById_Method { get; set; }
        public IReadOnlyCollection<ROOT_CAUSE_ENVIRONMENT_MASTER>? Get_All_Environment { get; set; }
        public ROOT_CAUSE_ENVIRONMENT_MASTER? Get_ById_Environment { get; set; }
        public IReadOnlyCollection<ROOT_CAUSE_MATERIAL_MASTER>? Get_All_Material { get; set; }
        public ROOT_CAUSE_MATERIAL_MASTER? Get_ById_Material { get; set; }
        public IReadOnlyCollection<NATURE_INJURY_DETAILS>? Get_All_Nature { get; set; }
        public NATURE_INJURY_DETAILS? Get_ById_Nature { get; set; }
        public IReadOnlyCollection<MECH_INJURY_DETAILS>? Get_All_Mechanism { get; set; }
        public MECH_INJURY_DETAILS? Get_ById_Mechanism { get; set; }
        public IReadOnlyCollection<AGENCY_INJURY_DETAILS>? Get_All_Agency { get; set; }
        public AGENCY_INJURY_DETAILS? Get_ById_Agency { get; set; }
        public IReadOnlyCollection<INCIDENT_DETAILS>? Get_All_Incident { get; set; }
        public INCIDENT_DETAILS? Get_ById_Incident { get; set; }
        public IReadOnlyCollection<INCIDENT_CATEGORY_DETAILS>? Get_All_IncidentDet { get; set; }
        public INCIDENT_CATEGORY_DETAILS? Get_ById_IncidentDet { get; set; }

        //public IReadOnlyCollection<DRILL_TYPE_MASTER>? Get_All_Drill { get; set; }
        //public DRILL_TYPE_MASTER? Get_ById_Drill { get; set; }
        //public IReadOnlyCollection<DRILL_CHECKLIST_MASTER>? Get_All_DrillCheck { get; set; }
        //public DRILL_CHECKLIST_MASTER? Get_ById_DrillCheck { get; set; }
        public IReadOnlyCollection<DISASTER_TYPE_MASTER>? Get_All_Disaster { get; set; }
        public DISASTER_TYPE_MASTER? Get_ById_Disaster { get; set; }

        public string? MESSAGE { get; set; }
        public bool? STATUS { get; set; }
        public string? STATUS_CODE { get; set; }
    }

    #region [ImmediateCause_UnsafeAct]
    public class M_EmergencyModel : M_COMMON_FIELDS
    {
        public string? CAUSE_ID { get; set; }
        public string? CAUSENAME { get; set; }
        public string? CAUSE_NAME_AR { get; set; }
        
    }
    #endregion

    #region [ImmediateCause_UnsafeConditions]

    public class UNSAFECONDITION_MASTER : M_COMMON_FIELDS
    {
        public string? IM_UNSAFE_ID { get; set; }
        public string? IM_UNSAFENAME { get; set; }
        public string? IM_UNSAFE_NAME_AR { get; set; }

    }

    #endregion

    #region [Root Causes (Personal factor)]

    public class ROOT_CAUSE_PERSONAL_MASTER : M_COMMON_FIELDS
    {
        public string? ROOT_CAUSE_ID { get; set; }
        public string? ROOT_CAUSE_NAME { get; set; }
        public string? ROOT_CAUSE_NAME_AR { get; set; }
    }
    #endregion

    #region [Root Causes (System factor)]

    public class ROOT_CAUSE_SYSTEM_MASTER : M_COMMON_FIELDS
    {
        public string? RC_SF_ID { get; set; }
        public string? RC_SF_NAME { get; set; }
        public string? RC_SF_NAME_AR { get; set; }
       
    }
    #endregion

    #region [Root Cause (Method)]
    public class ROOT_CAUSE_METHOD_MASTER : M_COMMON_FIELDS
    {
        public string? RC_METHOD_ID { get; set; }
        public string? RC_METHOD_NAME { get; set; }
        public string? RC_METHOD_NAME_AR { get; set; }
    }
    #endregion

    #region [Root Cause(Environment)]
    public class ROOT_CAUSE_ENVIRONMENT_MASTER : M_COMMON_FIELDS
    {
        public string? RC_ENVIRONMENT_ID { get; set; }
        public string? RC_ENVIRONMENT_NAME { get; set; }
        public string? RC_ENVIRONMENT_NAME_AR { get; set; }
        
    }
    #endregion

    #region [Root Cause(Material)]
    public class ROOT_CAUSE_MATERIAL_MASTER : M_COMMON_FIELDS
    {
        public string? RC_MATERIAL_ID { get; set; }
        public string? RC_MATERIAL_NAME { get; set; }
        public string? RC_MATERIAL_NAME_AR { get; set; }
       
    }
    #endregion

    #region [Nature of Injury / Illness]
    public class NATURE_INJURY_DETAILS : M_COMMON_FIELDS
    {
        public string? NATURE_INJURY_ID { get; set; }
        public string? NATURE_INJURY_NAME { get; set; }
        public string? NATURE_INJURY_NAME_AR { get; set; }

    }
    #endregion

    #region [Mechanism of Injury / Illness]
    public class MECH_INJURY_DETAILS : M_COMMON_FIELDS
    {
        public string? MECH_INJURY_ID { get; set; }
        public string? MECH_INJURY_NAME { get; set; }
        public string? MECH_INJURY_NAME_AR { get; set; }

    }
    #endregion

    #region [Agency / Source of Injury / Illness]
    public class AGENCY_INJURY_DETAILS : M_COMMON_FIELDS
    {
        public string? AGENCY_INJURY_ID { get; set; }
        public string? AGENCY_INJURY_NAME { get; set; }
        public string? AGENCY_INJURY_NAME_AR { get; set; }
        
    }
    #endregion

    #region[Incident Cause Analysis]
    public class INCIDENT_DETAILS : M_COMMON_FIELDS
    {
        public string? INCDT_CAS_ID { get; set; }
        public string? INCDT_CAS_NAME { get; set; }
        public string? INCDT_CAS_NAME_AR { get; set; }
    }
    #endregion

    #region[Incident Category]
    public class INCIDENT_CATEGORY_DETAILS : M_COMMON_FIELDS
    {
        public string? INC_CAT_ID { get; set; }
        public string? INC_CAT_NAME { get; set; }
        public string? INC_CAT_NAME_AR { get; set; }
        public string? INC_CAT_STATUS { get; set; }

    }
    #endregion

    #region [Drill Type]
    public class DRILL_TYPE_MASTER : M_COMMON_FIELDS
    {
        public string? DRILL_TYPE_ID { get; set; }
        public string? DRILL_TYPE_NAME { get; set; }
        public string? DRILL_TYPE_NAME_AR { get; set; }
    }
    #endregion

    #region [Drill Management Checklist]
    public class DRILL_CHECKLIST_MASTER : M_COMMON_FIELDS
    {
        public string? DRILL_CHECKLIST_ID { get; set; }
        public string? DRILL_TYPE_ID { get; set; }
        public List<ADD_DRILL_SUB_CHECKLIST>? ADD_DRILL_SUB_CHECKLIST_LIST { get; set; }
    }
    public class ADD_DRILL_SUB_CHECKLIST : M_COMMON_FIELDS
    {
        public string? DRILL_SUBCHECKLIST_ID { get; set; }
        public string? DRILL_TYPE_ID { get; set; }
        public string? DRILL_CHECKLIST_ID { get; set; }
        public string? DRILL_CHECKLIST_NAME { get; set; }
        public string? DRILL_CHECKLIST_NAME_AR { get; set; }

    }
    public class ADD_DRILL_CHECKLIST : M_COMMON_FIELDS
    {
        public string? DRILL_CHECKLIST_ID { get; set; }
        public string? DRILL_TYPE_ID { get; set; }
        public string? DRILL_CHECKLIST_NAME { get; set; }
        public string? DRILL_CHECKLIST_NAME_AR { get; set; }
    }
    #endregion

    #region [DISASTER_TYPE]
    public class DISASTER_TYPE_MASTER : M_COMMON_FIELDS
    {
        public string? DISASTER_ID { get; set; }
        public string? DISASTER_NAME { get; set; }
        public string? DISASTER_NAME_AR { get; set; }

    }
    #endregion
}