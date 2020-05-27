using Proarch.Ems.Core.Application.Common;

namespace Proarch.Ems.Core.Application.Services
{
    public interface IUserService : IService
    {
        string User { get; }
    }
}
