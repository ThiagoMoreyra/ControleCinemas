using ControleCinemas.Business.Notifiacoes;
using System.Collections.Generic;

namespace ControleCinemas.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
