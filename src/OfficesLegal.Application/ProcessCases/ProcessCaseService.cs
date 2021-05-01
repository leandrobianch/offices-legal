using OfficesLegal.Application.ViewModels.CouncilProcessCases;
using OfficesLegal.Common;
using OfficesLegal.Domain.ProcessCases;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficesLegal.Application.ProcessCases
{
    public class ProcessCaseService : IProcessCaseService
    {
        private readonly INotificationValidation _notificationValidation;
        private readonly  IProcessCaseRepository _processCaseLegalRepository;
        public ProcessCaseService(
            INotificationValidation notificationValidation,
            IProcessCaseRepository processCaseLegalRepository)
        {
            _notificationValidation = notificationValidation;
            _processCaseLegalRepository = processCaseLegalRepository;
        }
        public async Task<bool> Delete(int idProcessCase)
        {
            var processCaseLegal = await _processCaseLegalRepository.GetAsync(idProcessCase);
            if (processCaseLegal == null)
            {
                _notificationValidation.AddMessage(new NotificationMessageValidation("Process Case Legal not found"));
                return await Task.FromResult(false);
            };
            _processCaseLegalRepository.Delete(processCaseLegal);
            await _processCaseLegalRepository.UnitOfWork.CommitAsync();
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<ProcessCaseViewModelOutput>> GetAll()
        {
            IEnumerable<ProcessCaseViewModelOutput> processCasesViewLegalModelOutput = null;
            var processCasesLegal = await _processCaseLegalRepository.GetAllAsync();
            if (processCasesLegal.Count() == 0)
            {
                _notificationValidation.AddMessage(new NotificationMessageValidation("Process Cases Legal not found"));
                return await Task.FromResult(processCasesViewLegalModelOutput);
            };

            return await Task.FromResult(processCasesLegal.Select(s => new ProcessCaseViewModelOutput()
            {
                Id = s.Id,
                CaseNumber = s.CaseNumber,
                CourtName = s.CourtName,
                NameOfTheResponsible = s.NameOfTheResponsible,
                RegistrationDate = s.RegistrationDate,
            }));
        }

        public async Task<ProcessCaseViewModelOutput> GetByCaseNumber(string caseNumber)
        {
            ProcessCaseViewModelOutput processCaseViewLegalModelOutput = null;
            var processCaseLegal = await _processCaseLegalRepository.GetByCaseNumberAsync(caseNumber);
            if (processCaseLegal == null)
            {
                _notificationValidation.AddMessage(new NotificationMessageValidation("Process Case Legal not found"));
                return await Task.FromResult(processCaseViewLegalModelOutput);
            };
            processCaseViewLegalModelOutput = new ProcessCaseViewModelOutput
            {
                Id = processCaseLegal.Id,
                CaseNumber = processCaseLegal.CaseNumber,
                CourtName = processCaseLegal.CourtName,
                NameOfTheResponsible = processCaseLegal.NameOfTheResponsible,
                RegistrationDate = processCaseLegal.RegistrationDate
            };
            return await Task.FromResult(processCaseViewLegalModelOutput);
        }

        public async Task<int?> New(ProcessCasesViewModelInput processCaseLegalViewModelInput)
        {
            int? newIdprocessCase = null;
            if (await _processCaseLegalRepository.CaseNumberExistsAsync(processCaseLegalViewModelInput.CaseNumber))
            {
                _notificationValidation.AddMessage(new NotificationMessageValidation("Process Case Legal already exists"));
                return await Task.FromResult(newIdprocessCase);
            };

            var processCaseLegal = new ProcessCase(
                                                        processCaseLegalViewModelInput.CaseNumber,
                                                        processCaseLegalViewModelInput.CourtName,
                                                        processCaseLegalViewModelInput.NameOfTheResponsible
                );

            if (!processCaseLegal.InvalidCaseNumberStandardFormat())
            {
                _notificationValidation.AddMessage(new NotificationMessageValidation("CaseNumber invalid"));
                return await Task.FromResult(newIdprocessCase);
            }

            await _processCaseLegalRepository.AddAsync(processCaseLegal);
            await _processCaseLegalRepository.UnitOfWork.CommitAsync();
            return processCaseLegal.Id;
        }

        public async Task<bool> Update(int id, ProcessCasesViewModelInput processCaseLegalViewModelInput)
        {
            var processCaseLegal = await _processCaseLegalRepository.GetAsync(id);
            if(processCaseLegal == null)
            {
                _notificationValidation.AddMessage(new NotificationMessageValidation("Process Case Legal not found"));
                return await Task.FromResult(false);
            };
            processCaseLegal.UpdateSetValues(
                                              processCaseLegalViewModelInput.CaseNumber,
                                              processCaseLegalViewModelInput.CourtName,
                                              processCaseLegalViewModelInput.NameOfTheResponsible
              );
            await _processCaseLegalRepository.UnitOfWork.CommitAsync();
            return await Task.FromResult(true);
        }
    }
}
