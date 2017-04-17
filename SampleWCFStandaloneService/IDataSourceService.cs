using System.Collections.Generic;
using System.ServiceModel;

namespace SampleWCFStandaloneService
{
    [ServiceContract]
    public interface IDataSourceService
    {
        [OperationContract]
        ServiceResponse SavePerson(Person person);

        [OperationContract]
        ServiceResponse DeletePerson(string id);
    }
}
