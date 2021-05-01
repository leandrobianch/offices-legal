using OfficesLegal.Application.ViewModels.CouncilProcessCases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficesLegal.Application.ProcessCases
{
    public interface IProcessCaseService
    {   
        Task<int?> New(ProcessCasesViewModelInput processCaseLegalViewModelInput);
        Task<bool> Update(int id, ProcessCasesViewModelInput processCaseLegalViewModelInput);
        Task<bool> Delete(int id);
        Task<ProcessCaseViewModelOutput> GetByCaseNumber(string caseNumber);
        Task<IEnumerable<ProcessCaseViewModelOutput>> GetAll();
    }
}
