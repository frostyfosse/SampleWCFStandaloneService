using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWCFStandaloneService
{
    public class DataSourceService : IDataSourceService
    {
        static DataSourceService()
        {
            PersonDataSource = new List<Person>();
        }

        public static List<Person> PersonDataSource { get; set; }

        #region ISampleWCFService methods
        public ServiceResponse DeletePerson(string id)
        {
            var errorMessage = "";

            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    PersonDataSource.RemoveAll(x => string.Equals(x.Id, id, StringComparison.OrdinalIgnoreCase));
                }
                catch (Exception e)
                {
                    var error = string.Join(Environment.NewLine, $"Error while removing persons with id '{id}'.", e);
                    Console.WriteLine(error);
                    errorMessage = error;
                }
            }
            else
                errorMessage = "Id cannot be null";

            var response = new ServiceResponse();

            if (!string.IsNullOrEmpty(errorMessage))
            {
                response.Result = Result.Failure;
                response.Messages = new[] { errorMessage };
                Console.WriteLine(errorMessage);
            }
            else
                Console.WriteLine($"Person '{id}' deleted.");

            return response;
        }

        public ServiceResponse SavePerson(Person person)
        {
            var response = new ServiceResponse();

            if (!string.IsNullOrEmpty(person.Id))
            {
                PersonDataSource.Add(person);

                Console.WriteLine($"Person '{person.Id}' added.");
            }
            else
            {
                var message = "Id cannot be null";
                response.Result = Result.Failure;
                response.Messages = new[] { message };

                Console.WriteLine(message);
            }

            return response;
        }
        #endregion
    }
}
