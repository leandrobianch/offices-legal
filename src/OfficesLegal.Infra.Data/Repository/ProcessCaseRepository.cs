using Microsoft.EntityFrameworkCore;
using OfficesLegal.Common;
using OfficesLegal.Domain.ProcessCases;
using ProcessCase.Infra.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficesLegal.Infra.Data.Repository
{
    public class ProcessCaseRepository : Repository<Domain.ProcessCases.ProcessCase>, IProcessCaseRepository
    {
        public ProcessCaseRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
                
        }
        public async Task<bool> CaseNumberExistsAsync(string caseNumber)
        {
            return await DatabaseContext.ProcessCaseLegal.CountAsync(w => w.CaseNumber == caseNumber) > 0;
        }
        public async Task<IEnumerable<Domain.ProcessCases.ProcessCase>> GetAllAsync()
        {
            return await DatabaseContext.ProcessCaseLegal.ToListAsync();
        }

        public async Task<Domain.ProcessCases.ProcessCase> GetByCaseNumberAsync(string caseNumber)
        {
            return await DatabaseContext.ProcessCaseLegal.FirstOrDefaultAsync(w => w.CaseNumber == caseNumber);
        }
        public async Task<Domain.ProcessCases.ProcessCase> GetCaseNumberByIdAsync(int id)
        {
            return await DatabaseContext.ProcessCaseLegal.FirstOrDefaultAsync(w => w.Id == id);
        }
    }
}
