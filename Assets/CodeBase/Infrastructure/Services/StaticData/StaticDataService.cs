using CodeBase.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        public HeroData GetHeroData() =>
            Resources.Load<HeroData>("HeroData/HeroData");
    }
}