using OfficesLegal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficesLegal.Domain.ProcessCases
{
    public interface IProcessCaseRepository : IRepository<ProcessCase>
    {
        Task<ProcessCase> GetCaseNumberByIdAsync(int id);
        Task<bool> CaseNumberExistsAsync(string caseNumber);
        Task<ProcessCase> GetByCaseNumberAsync(string caseNumber);
        Task<IEnumerable<ProcessCase>> GetAllAsync();
    }
}
