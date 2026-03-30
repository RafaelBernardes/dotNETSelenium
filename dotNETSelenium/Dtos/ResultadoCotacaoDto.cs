namespace dotNETSelenium.Dtos
{
    public class ResultadoCotacaoDto
    {
        public string Data { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public decimal CotacaoCompra { get; set; }
        public decimal CotacaoVenda { get; set; }
        public decimal ParidadeCompra { get; set; }
        public decimal ParidadeVenda { get; set; }
    }
}