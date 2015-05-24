using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IRepositorio
{
    public interface IGeolocalizacaoRepositorio
    {
        Task<bool> InserirGeolocalizacao(Geolocalizacao e);
        Task<bool> AtualizarGeolocalizacao(Geolocalizacao e);
        Task<bool> DeletarGeolocalizacao(Geolocalizacao e);
        Task<Geolocalizacao> RetornarGeolocalizacaoPorId(int id);
        Task<ICollection<Geolocalizacao>> RetornarTodasGeolocalizacoes();
    }
}

