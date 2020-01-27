using System;

namespace GTI_WebCore.Interfaces {
    public interface IEnderecoRepository {
        int RetornaCep(int CodigoLogradouro, short Numero);

    }
}
