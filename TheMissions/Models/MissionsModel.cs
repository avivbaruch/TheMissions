using System.ComponentModel.DataAnnotations;

namespace TheMissions.MissionModel
{
    public class MissionsModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "יש לשלוח שדה עבור שם משימה")]
        [MinLength(20, ErrorMessage = "שם משימה צריך להכיל 20 תווים לפחות")]
        public string MissionName { get; set; }
    }
}
