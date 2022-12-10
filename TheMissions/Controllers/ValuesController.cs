using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TheMissions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static int _id = 10;
        private static readonly List<MissionModel.MissionsModel>
            allMissions = new List<MissionModel.MissionsModel>();
        [HttpGet]
        public List<MissionModel.MissionsModel> GetAllMissions()
        {
            return allMissions;
        }


        [HttpPost]
        public void AddMission(MissionModel.MissionsModel missionModel)
        {
            missionModel.Id = _id++;
            allMissions.Add(missionModel);
        }

        [HttpDelete]
        public void DeleteMission(int recordKey)
        {
            var mission = allMissions.FirstOrDefault(y => y.Id == recordKey);

            if (mission != null)
            {
                allMissions.Remove(mission);
            }

        }
        [HttpPut]
        public void UpdateMission(int recordKey, MissionModel.MissionsModel newMission)
        {
            var mission = allMissions.FirstOrDefault(y => y.Id == recordKey);
            if (mission != null)
            {
                mission.MissionName = newMission.MissionName;
            }
        }

    }
}
