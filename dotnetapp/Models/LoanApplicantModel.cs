using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class LoanApplicantModel
    {
        [Key]
        public int LoanId { get; set; }

<<<<<<< HEAD
        public string LoanType { get; set; }

        public string ApplicantName { get; set; }

        public string ApplicantAddress { get; set; }

        [Required]
        public string ApplicantEmail { get; set; }

        public string ApplicantMobile { get; set; }

        public string ApplicantAdhaar { get; set; }

        public string ApplicantPan { get; set; }

        public string ApplicantSalary { get; set; }

        public string LoanAmountRequired { get; set; }

        public string LoanRepaymentMonths { get; set; }

        public string Status { get; set; }
=======
        public string? LoanType { get; set; }

        public string? ApplicantName { get; set; }

        public string? ApplicantAddress { get; set; }

        [Required]
        public string? ApplicantEmail { get; set; }

        public string? ApplicantMobile { get; set; }

        public string? ApplicantAdhaar { get; set; }

        public string? ApplicantPan { get; set; }

        public string? ApplicantSalary { get; set; }

        public string? LoanAmountRequired { get; set; }

        public string? LoanRepaymentMonths { get; set; }
>>>>>>> ce8665c87d36bb2bf5997e3d7212fca6efe7b14a

    }

}
