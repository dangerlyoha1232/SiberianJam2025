using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        HeroData GetHeroData();
        
        void LoadEmployersData();
        EmployeeData ForEmployee(EmployeeType type);
    }
}