using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Domain.Enum
{
    public enum StatusPedido
    {
        Submetido,
        AguardandoValidacao,
        EstoqueConfirmado,
        Pago,
        Enviado,
        Cancelado
    }
}
