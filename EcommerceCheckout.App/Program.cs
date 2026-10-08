using EcommerceCheckout.App;

var service = new PedidoService();

Console.WriteLine(service.GerarCodigoRastreio("sudeste", 42));
Console.WriteLine(service.CalcularPontosFidelidade(150));
Console.WriteLine(service.TemDireitoAFreteGratis(150, true));
