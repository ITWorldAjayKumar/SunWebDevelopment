using System.Runtime.Serialization;

namespace DataContracts
{
    [DataContract]
    public static class ReadOnlyMessage
    {
        //Application Status Message
        [DataMember]
        public static string strAlreadyExist = " already exist in system.";
        [DataMember]
        public static string strAddedSuccessfully = " has been added successfully.";
        [DataMember]
        public static string strUpdatedSuccessfully = " has been updated successfully.";
        [DataMember]
        public static string strFailed = "Service Request Failed";

        public enum StatusCode
        {
            Plain,

            Success,

            Information,

            Warning,

            Danger,

            Primary,

            Duplicate,

            Failed,
        };


    }
}
