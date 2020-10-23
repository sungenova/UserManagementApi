using System.Threading.Tasks;
using UserApiClient;
using UserApiModels;

namespace UserApiClientApp
{
    class Program
    {
        static async Task Main()
        {
            var userApiClient = new ApiClient();

            var user = new User
            {
                IIN = "300716163019",
                FirstName = "Leojo",
                LastName = "Capiro",
                BirthDate = System.DateTime.Now
            };

            userApiClient.Create(user);
            await userApiClient.Update(user);
            var result = await userApiClient.GetDetails("300716163019");
        }
    }
}
