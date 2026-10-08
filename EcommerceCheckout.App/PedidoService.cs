namespace EcommerceCheckout.App;

public class PedidoService
{
    /// <summary>
    /// Gera o código de rastreio: região em maiúsculas + "-" + número do pedido com 4 dígitos.
    /// Ex.: ("sudeste", 42) => "SUDESTE-0042"
    /// </summary>
    public string GerarCodigoRastreio(string regiao, int numeroPedido)
    {
        return $"{regiao.ToUpper()}-{numeroPedido.ToString("D4")}";
    }

    /// <summary>
    /// A cada R$ 10 em compras, o cliente ganha 2 pontos.
    /// Ex.: 150 => 15 * 2 = 30
    /// </summary>
    public int CalcularPontosFidelidade(int valorTotal)
    {
        return (valorTotal / 10) * 2;
    }

    /// <summary>
    /// Frete grátis se valorTotal >= 200 OU se o cliente for VIP.
    /// </summary>
    public bool TemDireitoAFreteGratis(int valorTotal, bool eClienteVIP)
    {
        return valorTotal >= 200 || eClienteVIP;
    }
}
