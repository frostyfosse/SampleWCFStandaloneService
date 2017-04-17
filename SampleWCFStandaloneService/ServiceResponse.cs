using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleWCFStandaloneService
{
    public enum Result
    {
        Success,
        Failure
    }

    [DataContract]
    public class ServiceResponse
    {
        [DataMember]
        public Result Result { get; set; }

        [DataMember]
        public IEnumerable<string> Messages { get; set; }
    }
}
