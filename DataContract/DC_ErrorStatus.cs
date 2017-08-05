﻿using System.Runtime.Serialization;

namespace DataContracts
{
    [DataContract]
    public class DC_ErrorStatus
    {
        System.Net.HttpStatusCode _ErrorStatusCode;
        string _ErrorMessage;

        [DataMember]
        public System.Net.HttpStatusCode ErrorStatusCode
        {
            get
            {
                return _ErrorStatusCode;
            }

            set
            {
                _ErrorStatusCode = value;
            }
        }
        [DataMember]
        public string ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }

            set
            {
                _ErrorMessage = value;
            }
        }
    }
}
