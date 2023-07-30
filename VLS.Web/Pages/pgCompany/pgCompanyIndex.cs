using Microsoft.AspNetCore.Components;
using VLS.Web.Helpers.API;

namespace VLS.Web.Pages.pgCompany
{
    public class pgCompanyIndex : ComponentBase
    {
        [Inject]
        private IBaseHttpClient httpClient { get; set; }
        public string EmptyGridText { get; set; } = "Loading";

        public List<Company> companies = new List<Company>();


        protected async override Task OnInitializedAsync()
        {
            var response = await httpClient.GetAsync<List<Company>>("Companies/GetAll");

            if (response.IsSuccess)
            {
                if(response.Data is null)
                {
                    EmptyGridText = "No records found";
                    return;
                }
                companies = response.Data;
            }
        }
    }
}
