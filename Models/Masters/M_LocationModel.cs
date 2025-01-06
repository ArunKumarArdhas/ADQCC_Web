//using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace ADQCC_New.Models.Masters
{
    public class GET_MASTERS_LIST
    {
        public IReadOnlyCollection<NATIONALITY_MASTER>? Get_All_National { get; set; }
        public IReadOnlyCollection<M_LocationModel>? Get_All_Location { get; set; }
        public M_LocationModel? Get_ById_Location { get; set; }
        public IReadOnlyCollection<BUILDING_MASTER>? Get_All_Building { get; set; }
        public BUILDING_MASTER? Get_ById_Building { get; set; }
        public IReadOnlyCollection<DEPARTMENT_MASTER>? Get_All_Depart { get; set; }
        public DEPARTMENT_MASTER? Get_ById_Depart { get; set; }
        public IReadOnlyCollection<DESIGNATION_MASTER>? Get_All_Design { get; set; }
        public DESIGNATION_MASTER? Get_ById_Design { get; set; }
        public IReadOnlyCollection<SECTION_LAB_MASTER>? Get_All_SecLab { get; set; }
        public SECTION_LAB_MASTER? Get_ById_SecLab { get; set; }
        public IReadOnlyCollection<SECTORTYPE_MASTER>? Get_All_Sect_Type { get; set; }
        public SECTORTYPE_MASTER? Get_ById_Sect_Type { get; set; }
        public IReadOnlyCollection<SECTOR_MASTER>? Get_All_Sector { get; set; }
        public SECTOR_MASTER? Get_ById_Sector { get; set; }
        public IReadOnlyCollection<EMR_TYPE_MASTER>? Get_All_ET { get; set; }
        public EMR_TYPE_MASTER? Get_ById_ET { get; set; }
        public string? MESSAGE { get; set; }
        public string? STATUS { get; set; }
        public string? STATUS_CODE { get; set; }
    }
    #region[NATIONALITY_MASTER]
    public class NATIONALITY_MASTER : M_COMMON_FIELDS
    {
        public string? NATIONALITY_ID { get; set; }
        public string? NATIONALITY_NAME { get; set; }
    }
    #endregion
    #region[LOCATION_MASTER]
    public class M_LocationModel : M_COMMON_FIELDS
    {
        public string? LOC_ID { get; set; }
        public string? LOC_NAME { get; set; }
        public string? LOC_NAME_AR { get; set; }
    }
    #endregion
    #region [BUILDING_MASTER]
    public class BUILDING_MASTER : M_COMMON_FIELDS
    {
        public string? BUIL_ID { get; set; }
        public string? LOC_ID { get; set; }
        public string? LOC_NAME { get; set; }
        public string? LOC_NAME_AR { get; set; }
        public string? BUIL_NAME { get; set; }
        public string? BUIL_NAME_AR { get; set; }
    }
    #endregion
    #region [Department]
    public class DEPARTMENT_MASTER : M_COMMON_FIELDS
    {
        public string? DEP_ID { get; set; }
        public string? SEC_ID { get; set; }
        public string? SEC_NAME_EN { get; set; }
        public string? SEC_NAME_ARB { get; set; }
        public string? DEP_NAME { get; set; }
        public string? DEP_NAME_AR { get; set; }
    }
    #endregion
    #region[DESIGNATION]
    public class DESIGNATION_MASTER: M_COMMON_FIELDS
    {
        public long DESI_ID { get; set; }
        public string? DESI_NAME_EN { get; set; }
        public string? DESI_NAME_ARB { get; set; }
        public int LANG_ID { get; set; }
        public long DESI_IDENTITY { get; set; }
        public string? MESSAGE { get; set; }
    }
    #endregion
    public class EMR_TYPE_MASTER : M_COMMON_FIELDS
    {
        public string? EMERG_TYPE_MAS_ID { get; set; }
        public string? EMERG_TYPE_MAS { get; set; }
        public string? EMERG_TYPE_MAS_AR { get; set; }

    }
    #region [Section_LAB]
    public class SECTION_LAB_MASTER : M_COMMON_FIELDS
    {
        public string? SEC_LAB_ID { get; set; }
        public string? SEC_LAB_TYPE { get; set; }
        public string? DEP_ID { get; set; }
        public string? DEP_NAME { get; set; }
        public string? SEC_LAB_NAME { get; set; }
        public string? SEC_LAB_NAME_AR { get; set; }
    }
    #endregion
    #region [SECTOR_TYPE]
    public class SECTORTYPE_MASTER : M_COMMON_FIELDS
    {
        public string? SEC_TYPE_ID { get; set; }
        public string? SEC_TYPE_NAME_EN { get; set; }
        public string? SEC_TYPE_NAME_ARB { get; set; }
    }
    #endregion
    #region [SECTOR]
    public class SECTOR_MASTER : M_COMMON_FIELDS
    {
        public string? SEC_ID { get; set; }
        public int BUIL_ID { get; set; }
        public string? SEC_TYPE { get; set; }
        public string? SEC_NAME_EN { get; set; }
        public string? SEC_NAME_ARB { get; set; }
    }
    #endregion
    #region[EMPLOYEE DETAILS]
    public class EmployeeDetails : M_COMMON_FIELDS
    {
        public string? EMP_ID { get; set; }
        public string? EMP_NAME { get; set; }
        public string? EMPLOYEE_ID { get; set; }
        public string? EMPLOYEE_NAME { get; set; }
        public string? INSP_PLAN_ID { get; set; }
        public string? INSP_PLAN_SUB_ID { get; set; }
        public string? EMP_NAME_AR { get; set; }
        public string? SECTION_HEAD { get; set; }
        public string? LINE_MANAGER { get; set; }
    }
    public class M_Employee_Master_Filter
    {
        public string? Loc_id { set; get; }
        public string? Build_id { set; get; }
        public string? EMR_Type { set; get; }
        public IReadOnlyCollection<EmployeeDetails>? Get_All_Emp { get; set; }
    }
    #endregion
}
