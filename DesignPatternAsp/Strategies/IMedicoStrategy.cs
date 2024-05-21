using DesignPatternAsp.Models.ViewModels;
using PatronesDiseño.Repository;

namespace DesignPatternAsp.Strategies
{
    public interface IMedicoStrategy
    {
        public void Add(MedicoViewModel medicoVM,IUnitOfWork unitOfWork);
    }
}
