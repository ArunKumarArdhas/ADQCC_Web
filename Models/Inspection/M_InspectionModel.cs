
namespace ADQCC_New.Models.Inspection
{

    
    public class GET_INSPECT_LIST
    {
        public IReadOnlyCollection<M_InspectionModel>? Get_All_CheckList { get; set; }
        public M_InspectionModel? Get_ById_CheckList { get; set; }

        public IReadOnlyCollection<Sub_Inspection>? Get_All_CheckListSub { get; set; }
        public Sub_Inspection? Get_ById_CheckListSub { get; set; }

        public IReadOnlyCollection<Get_Sub_Data_Inspection>? Get_All_CheckListSubData { get; set; }
        public Get_Sub_Data_Inspection? Get_ById_CheckListSubData { get; set; }
    }

    #region [INSPECTION CHECKLIST TYPE]

    public class M_InspectionModel : M_COMMON_FIELDS
    {
        public string? CHECKLIST_TYPE_ID { get; set; }
        public string? CHECKLIST_TYPE { get; set; }
        public string? CHECKLIST_TYPE_AR { get; set; }
    }
   
    #endregion

    #region [INSPECTION CHECKLIST SUB TYPE]
    public class Sub_Inspection : M_COMMON_FIELDS
    {
        public string? CHECKLIST_SUB_TYPE_ID { get; set; }
        public string? CHECKLIST_TYPE_ID { get; set; }
        public string? CHECKLIST_SUB_TYPE { get; set; }
        public string? CHECKLIST_SUB_TYPE_AR { get; set; }
    }

    
    #endregion

    #region [INSPECTION CHECKLIST SUB TYPE DATA]
    public class Get_Sub_Data_Inspection : M_COMMON_FIELDS
    {
        public string? CHECKLIST_SUB_TYPE_ID { get; set; }
        public string? CHECKLIST_TYPE_ID { get; set; }
        public string? CHECKLIST_SUB_TYPE { get; set; }

    }
    public class Add_Sub_Data_Inspection : M_COMMON_FIELDS
    {
        public string? CHECKLIST_SUB_TYPE_DATA_ID { get; set; }
        public string? CHECKLIST_SUB_TYPE_ID { get; set; }
        public string? CHECKLIST_TYPE_ID { get; set; }
        public string? CHECKLIST_SUB_TYPE_DATA { get; set; }
        public string? CHECKLIST_SUB_TYPE_DATA_AR { get; set; }

    }
    public class Get_By_ID_Sub_Data_Inspection_List
    {
        public string? CHECKLIST_TYPE_ID { get; set; }
        public string? CHECKLIST_SUB_TYPE_ID { get; set; }
        public List<Get_By_ID_Sub_Data_Inspection>? Get_By_ID_Sub_Data_Inspection { get; set; }
    }
        public class Get_By_ID_Sub_Data_Inspection : M_COMMON_FIELDS
        {
            public string? CHECKLIST_SUB_TYPE_DATA_ID { get; set; }
            public string? CHECKLIST_SUB_TYPE_ID { get; set; }
            public string? CHECKLIST_TYPE_ID { get; set; }
            public string? CHECKLIST_SUB_TYPE_DATA { get; set; }
            public string? CHECKLIST_SUB_TYPE_DATA_AR { get; set; }
            public string? CHECKLIST_TYPE { get; set; }
            public string? CHECKLIST_SUB_TYPE { get; set; }
        }
    #endregion

   

  

}
