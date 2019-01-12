namespace DB.Entity.ServiceResp
{
    public static class AppMessages
    {
        public static Messages DataRetrievedSuccessfully => new Messages
        {
            Code = "3500",
            Description = "Data Retrieved Successfully."
        };
        public static Messages DataAlreadyExist => new Messages
        {
            Code = "3500",
            Description = "Data already exist."
        };
        public static Messages DataSavedSuccessfully => new Messages
        {
            Code = "3501",
            Description = "Data Saved Successfully."
        };
        public static Messages DataupdatedSuccessfully => new Messages
        {
            Code = "3502",
            Description = "Data updated Successfully."
        };
        public static Messages DataDeletedSuccessfully => new Messages
        {
            Code = "3503",
            Description = "Data Deleted Successfully."
        };
        public static Messages DataNotFound => new Messages
        {
            Code = "3504",
            Description = "Record does not exist."
        };
        public static Messages TechincalProblemOccured => new Messages
        {
            Code = "100",
            Description = "We are unable to process your request at this time. Please try again later, and if the problem persists, contanct your system administrator."
        };
    }   
}
