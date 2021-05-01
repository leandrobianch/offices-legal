using System;

namespace OfficesLegal.Application.ViewModels.CouncilProcessCases
{
    public class ProcessCaseViewModelOutput
    {
        public int Id { get; set; }
        public string CaseNumber { get; set; }

        public string CourtName { get; set; }

        public string NameOfTheResponsible { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
