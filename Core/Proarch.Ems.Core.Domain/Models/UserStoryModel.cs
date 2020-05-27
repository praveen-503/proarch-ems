using FluentValidation;
using Proarch.Ems.Core.Domain.Common;

namespace Proarch.Ems.Core.Domain.Models
{
    public class UserStoryModel : AuditModel
    {
        public string Name { get; set; }

        public bool IsRecurring { get; set; }

        public int RecurringHours { get; set; }

        public int ProjectId { get; set; }

        public int EmployeeId { get; set; }

        public bool IsClosed { get; set; }

        public ProjectModel Project { get; set; }
        public EmployeeModel Employee { get; set; }

        internal bool IsSameAs(UserStoryModel other)
        {
            if (other == null)
            {
                return false;
            }

            if (Id == 0 || other.Id == 0)
            {
                return false;
            }

            return Id == other.Id;
        }
    }
    #region Validation
    public class UserStoryModelValidator : AbstractValidator<UserStoryModel>
    {
        public UserStoryModelValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.ProjectId).NotNull();
            RuleFor(x => x.EmployeeId).NotNull();
        }
    }
    #endregion
}
