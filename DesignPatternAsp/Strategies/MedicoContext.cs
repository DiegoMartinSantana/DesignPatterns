using DesignPatternAsp.Models.ViewModels;
using PatronesDiseño.Repository;

namespace DesignPatternAsp.Strategies
{
    public class MedicoContext
    {

        private IMedicoStrategy _medicoStrategy;

        public IMedicoStrategy MedicoStrategy
        {
            set
            { _medicoStrategy = value; } //asigna la estrategia recibida para cambiarla en ejecucion
        }

        public MedicoContext(IMedicoStrategy medicoStrategy)
        {
            _medicoStrategy = medicoStrategy;
        }
        public void Add(MedicoViewModel medicoVM, IUnitOfWork unitOfWork)
        {
            _medicoStrategy.Add( medicoVM,unitOfWork); //delega la responsabilidad a la estrategia concreta
        }

      
    }
}
