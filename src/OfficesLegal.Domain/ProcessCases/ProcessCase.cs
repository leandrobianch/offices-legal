using System;
using System.Text.RegularExpressions;

namespace OfficesLegal.Domain.ProcessCases
{
    public class ProcessCase
    {
        public int Id { get; set; }
        public string CaseNumber { get; private set; }
        public string CourtName { get; private set; }
        public string NameOfTheResponsible { get; private set; }
        public DateTime RegistrationDate { get; private set; }

        private ProcessCase()
        {
            RegistrationDate = DateTime.Now.Date;
        }
        public ProcessCase(
            string caseNumber, 
            string courtName, 
            string nameOfTheResponsible)
        {
            UpdateSetValues(
                caseNumber,
                courtName,
                nameOfTheResponsible);
        }

        public void UpdateSetValues(
            string caseNumber,
            string courtName,
            string nameOfTheResponsible)
        {
            CaseNumber = caseNumber;
            CourtName = courtName;
            NameOfTheResponsible = nameOfTheResponsible;
        }

        /// <summary>
        ///  to the National Council of Justice
        //(CNJ) standard.It has the format: NNNNNNN-NN.NNNN.N.NN.NNNN, where N can be any positive
        ///integer
        /// </summary>
        /// <returns></returns>
        public bool InvalidCaseNumberStandardFormat()
        {
            var regex = new Regex(@"\d{7}-\d{2}.\d{4}.\d{1}.\d{2}.\d{4}");
            return !regex.IsMatch(CaseNumber);
        }
    }
}
