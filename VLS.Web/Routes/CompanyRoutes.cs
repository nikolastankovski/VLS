using VLS.Domain.DbModels;

namespace VLS.Web.Routes
{
    public static class CompanyRoutes
    {
        private const string Base = nameof(Company);

        public const string Index = $"{Base}";
        public const string Create = $"{Base}/Create";
        public const string Edit = $"{Base}/Edit";
        //public const string Delete = $"{Base}/Create";
    }
}
