using myCvApi.Models;

namespace myCvApi.Data.DTOs.Formacao
{
    public class ReadFormacaoDto
    {
        public string Nome { get; set; }
        public string Local { get; set; }
        public string Periodo { get; set; }
        public string Imagem { get; set; }
    }
}