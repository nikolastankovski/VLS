using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using VLS.Web.Helpers.API;
using VLS.Web.Models;

namespace VLS.Web.Pages.pgCompany
{
    public class pgCompanyIndex : ComponentBase
    {
        protected RadzenDataGrid<Company> grid = new RadzenDataGrid<Company>();
        protected GridConfig<Company> gridConfig = new GridConfig<Company>();

        [Inject]
        private IBaseHttpClient httpClient { get; set; } = null!;
        [Inject]
        private NavigationManager Navigator { get; set; } = null!;
        protected string EmptyGridText { get; set; } = Resources.Loading;

        protected List<Company> companies = new List<Company>();
        protected IList<Company>? selectedCompanies;

        protected bool editBtnDisabled { get; set; } = true;

        protected async override Task OnInitializedAsync()
        {
            var response = await httpClient.GetAsync<List<Company>>("Companies/GetAll");

            if (response.IsSuccess)
            {
                if(response.Data is null)
                {
                    EmptyGridText = Resources.NoRecordsFound;
                    return;
                }
                gridConfig.Data = response.Data;
            }
        }

        protected void EditRecord()
        {
            int? companyId = selectedCompanies.First().CompanyId;
            Navigator.NavigateTo(CompanyRoutes.Edit + $"/{companyId}");
        }

        protected void SelectRow(Company selectedEntity)
        {
            grid.SelectRow(selectedEntity);
            editBtnDisabled = false;
        }

        protected void ClearSelection()
        {
            editBtnDisabled = true;
            selectedCompanies = null;
        }
    }
}
