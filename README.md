# Desafio Técnico .NET

Projeto desenvolvido como parte de um desafio técnico para a vaga de Desenvolvedor de Sistemas Jr.

## Tecnologias utilizadas

- .NET 10
- C#
- Aplicação Console
- System.Text.Json
- xUnit

## Objetivo

A aplicação resolve três problemas propostos no desafio técnico:

1. Cálculo de comissão de vendedores.
2. Movimentação de estoque.
3. Cálculo de juros por atraso.

## Funcionalidades

### Comissão de vendedores

A aplicação lê um arquivo JSON contendo registros de vendas e calcula a comissão de cada vendedor.

Regras:

- Vendas abaixo de R$ 100,00: sem comissão.
- Vendas entre R$ 100,00 e R$ 499,99: 1% de comissão.
- Vendas a partir de R$ 500,00: 5% de comissão.

### Movimentação de estoque

Permite realizar entradas e saídas dos produtos existentes no arquivo JSON de estoque.

Cada movimentação possui:

- Identificador único.
- Produto.
- Tipo da movimentação.
- Quantidade.
- Descrição.

Também são realizadas validações para:

- Produto inexistente.
- Quantidade menor ou igual a zero.
- Saída superior ao estoque disponível.

### Cálculo de juros

Calcula os juros de um valor vencido considerando uma taxa de 2,5% ao dia.

Foi adotado cálculo de juros simples:

```text
juros = valor × 2,5% × dias em atraso
```

Caso a data ainda não tenha vencido, nenhum juro é aplicado.

## Estrutura do projeto

```text
desafio-tecnico-dotnet/
├── src/
│   └── DesafioTecnico.Console/
│       ├── Data/
│       ├── Models/
│       ├── Services/
│       └── Program.cs
│
├── tests/
│   └── DesafioTecnico.Tests/
│
├── DesafioTecnico.slnx
└── README.md
```

## Executando o projeto

Na raiz do repositório, execute:

```bash
dotnet build
```

Depois:

```bash
dotnet run --project ./src/DesafioTecnico.Console/DesafioTecnico.Console.csproj
```

O menu principal será exibido:

```text
========================================
          DESAFIO TÉCNICO .NET
========================================

1 - Comissão de vendedores
2 - Movimentação de estoque
3 - Cálculo de juros por atraso
0 - Sair
```

## Executando os testes

Na raiz do projeto, execute:

```bash
dotnet test
```

Os testes automatizados cobrem as principais regras de:

- comissão de vendedores;
- entrada de estoque;
- saída de estoque;
- quantidade inválida;
- saída superior ao estoque disponível;
- juros para diferentes quantidades de dias em atraso;
- vencimento atual ou futuro;
- cálculo do valor atualizado.

## Organização do desenvolvimento

O desenvolvimento foi organizado utilizando Issues e Milestones do GitHub.

As etapas foram divididas em:

- Sprint 0 - Preparação do projeto
- Sprint 1 - Comissão de vendedores
- Sprint 2 - Movimentação de estoque
- Sprint 3 - Cálculo de juros
- Sprint 4 - Testes e documentação

Cada funcionalidade foi implementada de forma incremental, com commits separados e validação antes do encerramento de cada Issue.

## Premissas adotadas

- A aplicação foi desenvolvida como Console Application para manter a solução simples e compatível com o escopo do desafio.
- Os dados iniciais de vendas e estoque são lidos diretamente dos arquivos JSON fornecidos no enunciado.
- O cálculo de juros utiliza juros simples de 2,5% ao dia.
- As movimentações de estoque são mantidas apenas durante a execução da aplicação.
- Não foi utilizado banco de dados, pois não há exigência de persistência no desafio.
- Os valores monetários são representados utilizando `decimal`.
- As regras de negócio foram separadas em serviços para facilitar leitura, manutenção e testes.

## Testes automatizados

O projeto utiliza xUnit para validar as regras principais da aplicação.

Atualmente são testados cenários como:

- Venda abaixo de R$ 100,00.
- Venda exatamente em R$ 100,00.
- Venda abaixo de R$ 500,00.
- Venda exatamente em R$ 500,00.
- Entrada de estoque.
- Saída de estoque.
- Quantidade igual a zero.
- Saída superior ao estoque disponível.
- Vencimento na data atual.
- Um dia de atraso.
- Três dias de atraso.
- Data de vencimento futura.
- Cálculo do valor atualizado.

## Autor

Weslley Junio