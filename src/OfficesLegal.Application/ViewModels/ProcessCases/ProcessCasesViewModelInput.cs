using System.ComponentModel.DataAnnotations;

namespace OfficesLegal.Application.ViewModels.CouncilProcessCases
{
    public class ProcessCasesViewModelInput
    {
        [Required]
        public string CaseNumber { get; set; }

        [Required]
        public string CourtName { get; set; }

        [Required]
        public string NameOfTheResponsible { get; set; }
    }
}
