using System.ComponentModel.DataAnnotations;


namespace MyFirstAspNetCoreApp.Models.Enums
{
    public enum CandidateType
    {
        [Display(Name = "Junior Developer")]
        JuniorDeveloper = 1,
        [Display(Name = "Regular Developer")]
        RegularDeveloper = 2,
        [Display(Name = "Senior Developer")]
        SeniorDeveloper = 3,
        [Display(Name = "Junior QA")]
        JuniorQA = 4,
    }
}
