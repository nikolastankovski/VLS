using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net.Http.Json;
using VLS.Domain.CustomModels;
using VLS.Web.Helpers.API;

namespace VLS.Web.Pages.pgCompany
{
    public class pgCompanyIndex : ComponentBase
    {
        [Inject]
        private IBaseHttpClient httpClient { get; set; }

        public List<Company> companies = new List<Company>();


        protected async override Task OnInitializedAsync()
        {
            ActionResponse? response = await httpClient.GetAsync<ActionResponse>("Companies/GetAll");

            if (response.IsSuccess && !string.IsNullOrEmpty(response.Data.ToString()))
            {
                companies = JsonConvert.DeserializeObject<List<Company>>(response.Data.ToString());
            }
        }
    }
}
