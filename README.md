# EcommerceCheckout

Solução .NET 10 para o cálculo de código de rastreio, pontos de fidelidade e frete grátis de uma loja online.
Atividade da disciplina **Garantia da Qualidade de Software** (Gestão e Qualidade de Software).

## Estrutura

```
EcommerceCheckout.sln
├── EcommerceCheckout.App     -> código de produção (PedidoService)
└── EcommerceCheckout.Tests   -> testes unitários com xUnit
```

## Métodos (`PedidoService`)

| Método | Retorno | Regra |
|---|---|---|
| `GerarCodigoRastreio(string regiao, int numeroPedido)` | `string` | Região em maiúsculas + `-` + número do pedido com 4 dígitos. Ex.: `("sudeste", 42)` → `"SUDESTE-0042"` |
| `CalcularPontosFidelidade(int valorTotal)` | `int` | 2 pontos a cada R$ 10. Ex.: `150` → `30` |
| `TemDireitoAFreteGratis(int valorTotal, bool eClienteVIP)` | `bool` | Frete grátis se `valorTotal >= 200` **ou** cliente VIP |

## Cobertura dos testes (`PedidoServiceTests`)

| Teste | Asserção | Cenário |
|---|---|---|
| `GerarCodigoRastreio_...` | `Assert.Equal` | `"sudeste"`, 42 → `"SUDESTE-0042"` |
| `CalcularPontosFidelidade_...` | `Assert.Equal` | 150 → 30 |
| `TemDireitoAFreteGratis_ClienteVipAbaixoDe200_...` | `Assert.True` | R$ 150, VIP |
| `TemDireitoAFreteGratis_ClienteNaoVipAbaixoDe200_...` | `Assert.False` | R$ 150, não-VIP |
| `TemDireitoAFreteGratis_ClienteNaoVipCom200_...` | `Assert.True` | R$ 200, não-VIP (limite) |

## Como executar

Pré-requisito: [.NET SDK 10](https://dotnet.microsoft.com/download).

```bash
dotnet test
```

Para rodar a aplicação de exemplo:

```bash
dotnet run --project EcommerceCheckout.App
```

## Como a solução foi criada

```bash
dotnet new sln -n EcommerceCheckout
dotnet new console -n EcommerceCheckout.App -f net10.0
dotnet new xunit -n EcommerceCheckout.Tests -f net10.0
dotnet sln add EcommerceCheckout.App/EcommerceCheckout.App.csproj
dotnet sln add EcommerceCheckout.Tests/EcommerceCheckout.Tests.csproj
dotnet add EcommerceCheckout.Tests/EcommerceCheckout.Tests.csproj reference EcommerceCheckout.App/EcommerceCheckout.App.csproj
```

## Licença

[MIT](LICENSE)
