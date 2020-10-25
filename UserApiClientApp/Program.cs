using System.Threading.Tasks;
using UserApiClient;
using UserApiModels;
using System;
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
                BirthDate = DateTime.Now
            };

            while (true)
            {
                try
                {
                    string str = Console.ReadLine();

                    switch (str)
                    {
                        case "c":
                            await userApiClient.Create(user);
                            break;
                        case "g":
                            var result = await userApiClient.GetDetails(user.IIN);
                            break;
                        case "d":
                            await userApiClient.Delete(user.IIN);
                            break;
                        case "u":
                            await userApiClient.Update(user);
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
