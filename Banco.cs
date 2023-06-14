using System;
using System.Collections;

namespace ControleBancario
{
    public class Banco
    {
        static ArrayList contas = new ArrayList(); // lista de contas
        static ArrayList transacoes = new ArrayList(); // lista de transacões
        static int ultimoIdConta = 0;
        static int ultimoIdTransacao = 0;


        // Bloco da main
        static void Main(string[] args)
        {
            // Duas contas padrão
            ultimoIdConta++; // aumenta o contador de contas para representar o ID
            Conta cb1 = new Conta(ultimoIdConta, "BRADESCO", "001", 18383);
            contas.Add(cb1);

            ultimoIdConta++;
            Conta cb2 = new Conta(ultimoIdConta, "Caixa", "002", 90211);
            contas.Add(cb2);

            // 10 transações na conta 1
            InserirTransacoesIniciais(1, 650.72, "10/01/2020", "Alimentação", "Restaurante", 2);
            InserirTransacoesIniciais(1, 39.20, "20/05/2021", "Transporte", "Uber", 2);
            InserirTransacoesIniciais(1, 5600, "15/06/2022", "Salário", "Recebimento de Salário", 1);
            InserirTransacoesIniciais(1, 4200, "02/03/2023", "Receitas Diversas", "Venda de Computador", 1);
            InserirTransacoesIniciais(1, 250, "04/06/2023", "Casa", "Conserto da TV", 2);
            InserirTransacoesIniciais(1, 3370.20, "15/08/2023", "Educação", "Mensalidade da Faculdade", 2);
            InserirTransacoesIniciais(1, 130.55, "15/08/2023", "Casa", "Internet", 2);
            InserirTransacoesIniciais(1, 150.00, "14/06/2023", "Médico", "Terapia", 2);
            InserirTransacoesIniciais(1, 650.00, "19/06/2023", "Receitas Diversas", "Comissão do Trabalho", 1);
            InserirTransacoesIniciais(1, 50.00, "30/05/2023", "Lazer", "Cinema", 2);


            // 10 transações na conta 2
            InserirTransacoesIniciais(2, 1287, "01/01/2021", "Viagem", "Viagem para o litoral", 2);
            InserirTransacoesIniciais(2, 8320, "06/06/2023", "Salário", "Recebimento de Salário", 1);
            InserirTransacoesIniciais(2, 9349, "06/09/2022", "Salário", "Recebimento de Salário", 1);
            InserirTransacoesIniciais(2, 840, "10/02/2021", "Casa", "Despesas Supermercado", 2);
            InserirTransacoesIniciais(2, 92.18, "12/06/2023", "Alimentação", "Restaurante", 2);
            InserirTransacoesIniciais(2, 9.00, "05/06/2023", "Entretenimento", "Spotify", 2);
            InserirTransacoesIniciais(2, 14.00, "13/06/2023", "Alimentação", "Restaurante Universitário", 2);
            InserirTransacoesIniciais(2, 300.00, "27/05/2023", "Compras Diversas", "Teclado Computador", 2);
            InserirTransacoesIniciais(2, 500.00, "09/05/2023", "Receitas Diversas", "Presente de Aniversário", 1);
            InserirTransacoesIniciais(2, 490.00, "15/06/2023", "Saúde", "Remédios", 2);

            MenuPrincipal();
        }
        static Conta RetornarConta(int id)
        {
            Conta conta = null;

            // pesquisa a conta
            for (int i = 0; i < contas.Count; i++)
            {
                Conta cb = (Conta)(contas[i]);
                if (cb.ID == id)
                {
                    return cb;
                }
            }

            return conta;
        }
        static void InserirTransacoesIniciais(int idConta, double valor, String data, String categoria, String descricao, int tipo)
        {

            // cria um novo objeto da classe Transacao
            ultimoIdTransacao++;
            Conta cb = RetornarConta(idConta);
            String[] dataArray = data.Split("/");
            DateTime dataTransacao = new DateTime(Int32.Parse(dataArray[2]), Int32.Parse(dataArray[1]), Int32.Parse(dataArray[0]));
            Transacao t = new Transacao(ultimoIdTransacao, cb, valor, dataTransacao, categoria, descricao, tipo);
            transacoes.Add(t);

            // atualiza o saldo dessa conta
            if (tipo == 1)
            {
                cb.Saldo = cb.Saldo + valor;
            }
            else
            {
                cb.Saldo = cb.Saldo - valor;
            }
        }
        static void MenuPrincipal()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("------------------------------------");
                Console.WriteLine("          CONTROLE BANCÁRIO");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("1. Gerenciar Contas");
                Console.WriteLine("2. Gerenciar Transações");
                Console.WriteLine("3. Painel Geral");
                Console.WriteLine("4. Sair");
                Console.Write("\nSua opção: ");
                int opcao = Int32.Parse(Console.ReadLine());


                switch (opcao)
                {
                    case 1: // gerencimento de contas
                        GerenciarContas();
                        break;

                    case 2: // gerencimento de transações
                        GerenciarTransacoes();
                        break;

                    case 3: // painel geral
                        PainelGeral();
                        break;

                    case 4:
                        Console.WriteLine("\nObrigada por usar o sistema.\n");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida.");
                        Console.WriteLine("\nPressione uma tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }


        // Bloco do gerenciamento de contas
        static void GerenciarContas()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("     CONTROLE BANCÁRIO - GERENCIAR CONTAS");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("1. Cadastrar Conta");
                Console.WriteLine("2. Listar Contas");
                Console.WriteLine("3. Remover Conta");
                Console.WriteLine("4. Mesclar Contas");
                Console.WriteLine("5. Voltar ao menu anterior");
                Console.Write("\nSua opção: ");

                int opcao = Int32.Parse(Console.ReadLine());

                // gerencia as opções do menu
                switch (opcao)
                {
                    case 1: // cadastra uma nova conta
                        CadastrarNovaConta();
                        break;

                    case 2: // lista as contas
                        ListarContas();
                        break;

                    case 3: // remove uma conta
                        RemoverConta();
                        break;

                    case 4: // Mescla duas contas
                        MesclarDuasContas();
                        break;

                    case 5:
                        continuar = false; // volta ao menu anterior
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida.");
                        Console.WriteLine("\nPressione uma tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void CadastrarNovaConta()
        {
            Console.Write("\nBanco: ");
            String banco = Console.ReadLine();
            Console.Write("Agência: ");
            String agencia = Console.ReadLine();
            Console.Write("Número: ");
            int numero = Int32.Parse(Console.ReadLine());

            // cria um novo objeto da classe Conta
            ultimoIdConta++;
            Conta cb = new Conta(ultimoIdConta, banco, agencia, numero);
            // adiciona esta conta à lista de contas     
            contas.Add(cb);
            Console.WriteLine("\nConta cadastrada com sucesso.");
            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
        }
        static void ListarContas()
        {
            if (contas.Count == 0)
            {
                Console.WriteLine("\nAinda não há contas cadastradas.");
            }
            else
            {
                // percorre todas as contas bancárias
                Console.WriteLine("\nRELAÇÃO DE CONTAS BANCÁRIAS");
                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.WriteLine("ID     BANCO                         AGÊNCIA           NÚMERO         SALDO  ");
                Console.WriteLine("-----------------------------------------------------------------------------");
                for (int i = 0; i < contas.Count; i++)
                {
                    Conta cb = (Conta)(contas[i]);
                    Console.Write(cb.ID.ToString().PadRight(7, ' '));
                    Console.Write(cb.Banco.PadRight(30, ' '));
                    Console.Write(cb.Agencia.PadRight(18, ' '));
                    Console.Write(cb.Numero.ToString().PadRight(10, ' '));
                    Console.Write(FormatarMoeda(cb.Saldo).PadLeft(10, ' '));
                    Console.WriteLine();
                }
                Console.WriteLine("-----------------------------------------------------------------------------\n");
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
        }
        static void RemoverConta()
        {
            if (contas.Count == 0)
            {
                Console.WriteLine("\nAinda não há contas cadastradas.");
            }
            else
            {
                Console.WriteLine("\nAo excluir uma conta todas as suas transações também serão excluídas.\n");
                Console.Write("ID da conta a ser excluída: ");
                int idExclusao = Int32.Parse(Console.ReadLine());
                bool sucesso = false;

                // pesquisa a conta
                for (int i = 0; i < contas.Count; i++)
                {
                    Conta cb = (Conta)(contas[i]);
                    if (cb.ID == idExclusao)
                    {
                        contas.RemoveAt(i);
                        sucesso = true;
                    }
                }

                if (sucesso)
                {
                    Console.WriteLine("\nA conta foi excluída com sucesso.\n");
                }
                else
                {
                    Console.WriteLine("\nA conta pesquisada não foi encontrada.\n");
                }
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
        }
        static void MesclarDuasContas()
        {
            if (contas.Count == 0)
            {
                Console.WriteLine("\nAinda não há contas cadastradas.");
            }
            else
            {
                Console.Write("\nID da conta de origem: ");
                int idOrigem = Int32.Parse(Console.ReadLine());

                Conta origem = RetornarConta(idOrigem);

                if (origem != null)
                {
                    Console.WriteLine("\nDados da conta de origem:\n");
                    Console.WriteLine("Banco: " + origem.Banco);
                    Console.WriteLine("Agência: " + origem.Agencia);
                    Console.WriteLine("Número: " + origem.Numero);
                    Console.WriteLine("Saldo Atual: " + FormatarMoeda(origem.Saldo));

                    Console.Write("\nID da conta de destino: ");
                    int idDestino = Int32.Parse(Console.ReadLine());

                    Conta destino = RetornarConta(idDestino);
                    if (destino != null)
                    {
                        if (idDestino == idOrigem)
                        {
                            Console.WriteLine("\nA conta de destino não pode ser igual à conta de origem");
                        }
                        else
                        {
                            Console.WriteLine("\nDados da conta de destino:\n");
                            Console.WriteLine("Banco: " + destino.Banco);
                            Console.WriteLine("Agência: " + destino.Agencia);
                            Console.WriteLine("Número: " + destino.Numero);
                            Console.WriteLine("Saldo Atual: " + FormatarMoeda(destino.Saldo));

                            Console.Write("\nDeseja mesclar a primeira conta na segunda? [S/N]: ");
                            String resposta = Console.ReadLine();

                            if (resposta.ToUpper().Equals("S"))
                            {
                                // prossegue com a operação
                                for (int i = 0; i < transacoes.Count; i++)
                                {
                                    Transacao aux = (Transacao)transacoes[i];

                                    if (aux.Conta.ID == idOrigem)
                                    {
                                        // atualiza os saldos
                                        if (aux.Tipo == 1)
                                        {
                                            origem.Saldo = origem.Saldo - aux.Valor;
                                            destino.Saldo = destino.Saldo + aux.Valor;
                                        }
                                        else
                                        {
                                            origem.Saldo = origem.Saldo + aux.Valor;
                                            destino.Saldo = destino.Saldo - aux.Valor;
                                        }
                                      ((Transacao)transacoes[i]).Conta = destino;
                                    }
                                }
                                Console.WriteLine("\nAs contas foram mescladas com sucesso.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nConta de destino não foi localizada.");
                    }
                }
                else
                {
                    Console.WriteLine("\nConta de origem não foi localizada.");
                }
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
        }


        // Bloco do gerenciamento de transações
        static void GerenciarTransacoes()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("     CONTROLE BANCÁRIO - GERENCIAR TRANSAÇÕES");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("1. Extrato da Conta");
                Console.WriteLine("2. Incluir Transação");
                Console.WriteLine("3. Editar Última Transação");
                Console.WriteLine("4. Transferir Fundos");
                Console.WriteLine("5. Voltar ao menu anterior");
                Console.Write("\nSua opção: ");
                int opcao = Int32.Parse(Console.ReadLine());

                // gerencia as opções do menu
                switch (opcao)
                {
                    case 1: // exibe o extrato de uma conta
                        ExtratoConta();
                        break;

                    case 2: // inclui uma nova transação
                        IncluirTransacao();
                        break;

                    case 3: // Editar última transação
                        EditarUltimaTransacao();
                        break;

                    case 4: // Transfere fundos entre duas contas
                        Transferencia();
                        break;

                    case 5:
                        continuar = false; // volta ao menu anterior
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida.");
                        Console.WriteLine("\nPressione uma tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void IncluirTransacao()
        {
            Console.Write("\nID da Conta Bancária: ");
            int idConta = Int32.Parse(Console.ReadLine());

            // pesquisa a conta de acordo com o id informado
            Conta cb = RetornarConta(idConta);
            if (cb == null)
            {
                Console.WriteLine("\nA conta não foi localizada.");
            }
            else
            {
                Console.WriteLine("\nDados da conta localizada:\n");
                Console.WriteLine("Banco: " + cb.Banco);
                Console.WriteLine("Agência: " + cb.Agencia);
                Console.WriteLine("Número: " + cb.Numero);
                Console.WriteLine("Saldo Atual: " + FormatarMoeda(cb.Saldo));

                Console.WriteLine("\nInforme os dados da nova transação:\n");
                Console.Write("Data: ");
                String[] dataArray = Console.ReadLine().Split("/");
                DateTime data = new DateTime(Int32.Parse(dataArray[2]), Int32.Parse(dataArray[1]), Int32.Parse(dataArray[0]));
                Console.Write("Tipo [1: Receita; 2: Despesa]: ");
                int tipo = Int32.Parse(Console.ReadLine());
                Console.Write("Categoria: ");
                String categoria = Console.ReadLine();
                Console.Write("Descrição: ");
                String descricao = Console.ReadLine();
                Console.Write("Valor: ");
                double valor = Double.Parse(Console.ReadLine());

                // cria um novo objeto da classe Transacao
                ultimoIdTransacao++;
                Transacao t = new Transacao(ultimoIdTransacao, cb, valor, data, categoria,
                  descricao, tipo);
                // adiciona esta transação na lista de transações da conta atual
                transacoes.Add(t);
                // atualiza o saldo dessa conta
                if (tipo == 1)
                {
                    cb.Saldo = cb.Saldo + valor;
                }
                else
                {
                    cb.Saldo = cb.Saldo - valor;
                }

                Console.WriteLine("\nA transação foi incluída com sucesso.");
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
        }
        static void ExtratoConta()
        {
            double variacaoSaldo = 0.0;
            Console.Write("\nID da Conta Bancária: ");
            int idConta = Int32.Parse(Console.ReadLine());

            // pesquisa a conta de acordo com o id informado
            Conta cb = RetornarConta(idConta);
            if (cb == null)
            {
                Console.WriteLine("\nA conta não foi localizada.");
            }
            else
            {
                Console.WriteLine("\nDados da conta localizada:\n");
                Console.WriteLine("Banco: " + cb.Banco);
                Console.WriteLine("Agência: " + cb.Agencia);
                Console.WriteLine("Número: " + cb.Numero);
                Console.WriteLine("Saldo Atual: " + FormatarMoeda(cb.Saldo));

                // percorre todas as transações desta conta
                Console.WriteLine("\nEXTRATO DA CONTA");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("DATA         TIPO         CATEGORIA              DESCRIÇÃO                                  VALOR         SALDO  ");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");

                // ordena as transações por data
                for (int i = transacoes.Count - 1; i > 1; i--)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (((Transacao)(transacoes[j])).Data > ((Transacao)(transacoes[j + 1])).Data)
                        {
                            Transacao aux = (Transacao)transacoes[j];
                            transacoes[j] = transacoes[j + 1];
                            transacoes[j + 1] = aux;
                        }
                    }
                }

                for (int i = 0; i < transacoes.Count; i++)
                {
                    Transacao t = (Transacao)(transacoes[i]);

                    // essa transação pertence a esta conta?
                    if (t.Conta.ID == cb.ID)
                    {
                        Console.Write(t.Data.ToString("dd/MM/yyyy").PadRight(13, ' '));

                        String sinal = "C";
                        if (t.Tipo == 1)
                        {
                            Console.Write("Receita".PadRight(13, ' '));
                            variacaoSaldo = variacaoSaldo + t.Valor;
                        }
                        else
                        {
                            Console.Write("Despesa".PadRight(13, ' '));
                            variacaoSaldo = variacaoSaldo - t.Valor;
                            sinal = "D";
                        }

                        Console.Write(t.Categoria.PadRight(23, ' '));
                        Console.Write(t.Descricao.PadRight(40, ' '));
                        Console.Write(FormatarMoeda(t.Valor).PadLeft(10, ' ') + sinal);
                        Console.Write(FormatarMoeda(variacaoSaldo).PadLeft(12, ' '));

                        Console.WriteLine();
                    }
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------\n");
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
        }
        static void EditarUltimaTransacao()
        {
            // busca a última transação
            Transacao ultimaTransacao = null;

            for (int i = 0; i < transacoes.Count; i++)
            {
                Transacao tr = (Transacao)transacoes[i];
                if (tr.ID == ultimoIdTransacao)
                {
                    ultimaTransacao = tr;
                    break;
                }
            }

            // mostra os dados da última transação
            Console.WriteLine("\nDADOS DA ÚLTIMA TRANSAÇÃO");
            Console.WriteLine("---------------------------------------------");

            Conta cb = RetornarConta(ultimaTransacao.Conta.ID);
            Console.WriteLine("Conta Bancária:\n");
            Console.WriteLine("Banco: " + cb.Banco);
            Console.WriteLine("Agência: " + cb.Agencia);
            Console.WriteLine("Número: " + cb.Numero);
            Console.WriteLine("Saldo Atual: " + FormatarMoeda(cb.Saldo));

            Console.WriteLine("\nTransação:\n");
            Console.WriteLine("Data: " + ultimaTransacao.Data.ToString("dd/MM/yyyy"));
            if (ultimaTransacao.Tipo == 1)
            {
                Console.WriteLine("Tipo: Receita");
            }
            else
            {
                Console.WriteLine("Tipo: Despesa");
            }
            Console.WriteLine("Categoria: " + ultimaTransacao.Categoria);
            Console.WriteLine("Descrição: " + ultimaTransacao.Descricao);
            Console.WriteLine("Valor: " + FormatarMoeda(ultimaTransacao.Valor));

            Console.WriteLine("\nNOVOS DADOS DA ÚLTIMA TRANSAÇÃO");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Informe os novos dados (campos em branco não serão modificados)");

            for (int i = 0; i < transacoes.Count; i++)
            {
                Transacao tr = (Transacao)transacoes[i];
                if (tr.ID == ultimoIdTransacao)
                {
                    // atualiza o saldo da conta anterior
                    if (tr.Tipo == 1)
                    {
                        cb.Saldo = cb.Saldo - tr.Valor;
                    }
                    else
                    {
                        cb.Saldo = cb.Saldo + tr.Valor;
                    }

                    Console.Write("\nID da Conta Bancária: ");
                    String idContaStr = Console.ReadLine();
                    Conta cbtemp = null;
                    if (idContaStr.Trim().Length > 0)
                    {
                        cbtemp = RetornarConta(Int32.Parse(idContaStr));
                        if (cbtemp != null)
                        {
                            ((Transacao)transacoes[i]).Conta = cbtemp;
                        }
                        else
                        {
                            Console.WriteLine("\nConta não encontrada. A conta atual será considerada.\n");
                        }
                    }

                    Console.Write("Data: ");
                    String dataStr = Console.ReadLine();
                    if (dataStr.Trim().Length > 0)
                    {
                        String[] dataArray = dataStr.Split("/");
                        DateTime data = new DateTime(Int32.Parse(dataArray[2]), Int32.Parse(dataArray[1]), Int32.Parse(dataArray[0]));
                        ((Transacao)transacoes[i]).Data = data;
                    }

                    Console.Write("Tipo [1: Receita; 2: Despesa]: ");
                    String tipoStr = Console.ReadLine();
                    int tipo = 0;
                    if (tipoStr.Trim().Length > 0)
                    {
                        tipo = Int32.Parse(tipoStr);
                        ((Transacao)transacoes[i]).Tipo = tipo;
                    }

                    Console.Write("Categoria: ");
                    String categoria = Console.ReadLine();
                    if (categoria.Trim().Length > 0)
                    {
                        ((Transacao)transacoes[i]).Categoria = categoria;
                    }

                    Console.Write("Descrição: ");
                    String descricao = Console.ReadLine();
                    if (descricao.Trim().Length > 0)
                    {
                        ((Transacao)transacoes[i]).Descricao = descricao;
                    }

                    Console.Write("Valor: ");
                    String valorString = Console.ReadLine();
                    if (valorString.Trim().Length > 0)
                    {
                        ((Transacao)transacoes[i]).Valor = Double.Parse(valorString);
                    }

                    // atualiza o saldo na nova conta ou conta atual
                    if (cbtemp != null)
                    {
                        if (tipo == 1)
                        {
                            cbtemp.Saldo = cbtemp.Saldo + ((Transacao)transacoes[i]).Valor;
                        }
                        else
                        {
                            cbtemp.Saldo = cbtemp.Saldo - ((Transacao)transacoes[i]).Valor;
                        }
                    }
                    else
                    {
                        if (tipo == 1)
                        {
                            cb.Saldo = cb.Saldo + ((Transacao)transacoes[i]).Valor;
                        }
                        else
                        {
                            cb.Saldo = cb.Saldo - ((Transacao)transacoes[i]).Valor;
                        }
                    }

                    Console.WriteLine("\nTransação atualizada com sucesso.");
                    break;
                }
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
        }
        static void Transferencia()
        {
            if (contas.Count == 0)
            {
                Console.WriteLine("\nAinda não há contas cadastradas.");
            }
            else
            {
                Console.Write("\nID da conta de origem: ");
                int idOrigem = Int32.Parse(Console.ReadLine());

                Conta origem = RetornarConta(idOrigem);
                if (origem != null)
                {
                    Console.WriteLine("\nDados da conta de origem:\n");
                    Console.WriteLine("Banco: " + origem.Banco);
                    Console.WriteLine("Agência: " + origem.Agencia);
                    Console.WriteLine("Número: " + origem.Numero);
                    Console.WriteLine("Saldo Atual: " + FormatarMoeda(origem.Saldo));

                    Console.Write("\nID da conta de destino: ");
                    int idDestino = Int32.Parse(Console.ReadLine());

                    Conta destino = RetornarConta(idDestino);
                    if (destino != null)
                    {
                        if (idDestino == idOrigem)
                        {
                            Console.WriteLine("\nA conta de destino não pode ser igual à conta de origem");
                        }
                        else
                        {
                            Console.WriteLine("\nDados da conta de destino:\n");
                            Console.WriteLine("Banco: " + destino.Banco);
                            Console.WriteLine("Agência: " + destino.Agencia);
                            Console.WriteLine("Número: " + destino.Numero);
                            Console.WriteLine("Saldo Atual: " + FormatarMoeda(destino.Saldo));

                            Console.Write("\nInforme o valor a ser transferido: ");
                            double valor = Double.Parse(Console.ReadLine());

                            // a conta de origem possui saldo
                            if (valor > origem.Saldo)
                            {
                                Console.WriteLine("\nA conta de origem não possui saldo suficiente.");
                            }
                            else
                            {
                                origem.Saldo = origem.Saldo - valor;
                                destino.Saldo = destino.Saldo + valor;
                                ultimoIdTransacao++;
                                Transacao t = new Transacao(ultimoIdTransacao, origem, valor,
                                  DateTime.Now, "Saque", "Transferência entre contas", 2);
                                transacoes.Add(t);
                                t = new Transacao(ultimoIdTransacao, destino, valor,
                                  DateTime.Now, "Depósito", "Transferência entre contas", 1);
                                transacoes.Add(t);

                                Console.WriteLine("\nA transferência foi efetuada com sucesso.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nConta de destino não foi localizada.");
                    }
                }
                else
                {
                    Console.WriteLine("\nConta de origem não foi localizada.");
                }
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
        }


        // Bloco do painel geral
        static void PainelGeral()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("        CONTROLE BANCÁRIO - PAINEL GERAL");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("1. Resumo das Contas");
                Console.WriteLine("2. Resumo de Receitas e Despesas do Mês");
                Console.WriteLine("3. Saldo Geral dos Últimos 6 Meses");
                Console.WriteLine("4. Conversor de Moedas");
                Console.WriteLine("5. Voltar ao menu anterior");
                Console.Write("\nSua opção: ");
                int opcao = Int32.Parse(Console.ReadLine());

                // gerencia as opções do menu
                switch (opcao)
                {
                    case 1: // resumo das contas
                        ResumoContas();
                        break;

                    case 2: // resumo receitas e despesas do mês
                        ResumoReceitasDespesasMes();
                        break;

                    case 3: // Saldo geral últimos 6 meses
                        SaldoGeralUltimos6Meses();
                        break;

                    case 4: // Conversor de moedas
                        ConversorMoedas();
                        break;

                    case 5:
                        continuar = false; // volta ao menu anterior
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida.");
                        Console.WriteLine("\nPressione uma tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void ResumoContas()
        {
            double saldoTotal = 0.0;
            if (contas.Count == 0)
            {
                Console.WriteLine("\nAinda não há contas cadastradas.");
            }
            else
            {
                // percorre todas as contas bancárias
                Console.WriteLine("\nRELAÇÃO DE CONTAS BANCÁRIAS");
                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.WriteLine("ID     BANCO                         AGÊNCIA           NÚMERO         SALDO  ");
                Console.WriteLine("-----------------------------------------------------------------------------");
                for (int i = 0; i < contas.Count; i++)
                {
                    Conta cb = (Conta)(contas[i]);
                    Console.Write(cb.ID.ToString().PadRight(7, ' '));
                    Console.Write(cb.Banco.PadRight(30, ' '));
                    Console.Write(cb.Agencia.PadRight(18, ' '));
                    Console.Write(cb.Numero.ToString().PadRight(10, ' '));
                    Console.Write(FormatarMoeda(cb.Saldo).PadLeft(10, ' '));
                    Console.WriteLine();
                    saldoTotal = saldoTotal + cb.Saldo;
                }
                Console.WriteLine("-----------------------------------------------------------------------------");

                Console.WriteLine("SALDO TOTAL: " + FormatarMoeda(saldoTotal));
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
        }
        static void ResumoReceitasDespesasMes()
        {
            int mesAtual = DateTime.Now.Month;
            int anoAtual = DateTime.Now.Year;
            double totalReceitas = 0.0;
            double totalDespesas = 0.0;
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("TOTAL DE RECEITAS E DESPESAS MÊS " + mesAtual.ToString().PadLeft(2, '0') + "/" + anoAtual);
            Console.WriteLine("--------------------------------------------------");

            for (int i = 0; i < transacoes.Count; i++)
            {
                Transacao tr = (Transacao)transacoes[i];
                if ((tr.Tipo == 1) && (tr.Data.Month == mesAtual) && (tr.Data.Year == anoAtual))
                {
                    totalReceitas = totalReceitas + tr.Valor;
                }
                if ((tr.Tipo == 2) && (tr.Data.Month == mesAtual) && (tr.Data.Year == anoAtual))
                {
                    totalDespesas = totalDespesas + tr.Valor;
                }
            }

            Console.WriteLine("RECEITAS: " + FormatarMoeda(totalReceitas));
            Console.WriteLine("DESPESAS: " + FormatarMoeda(totalDespesas));
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
        }
        static void SaldoGeralUltimos6Meses()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("           SALDO GERAL ÚLTIMOS 6 MESES");
            Console.WriteLine("--------------------------------------------------");

            // ordena as transações por data
            for (int i = transacoes.Count - 1; i > 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (((Transacao)(transacoes[j])).Data > ((Transacao)(transacoes[j + 1])).Data)
                    {
                        Transacao aux = (Transacao)transacoes[j];
                        transacoes[j] = transacoes[j + 1];
                        transacoes[j + 1] = aux;
                    }
                }
            }

            // obtém o saldo antes dos seis meses anteriores
            double saldo = 0.0;
            int mes = 6;
            DateTime data = DateTime.Now.AddMonths(-6);

            for (int i = 0; i < transacoes.Count; i++)
            {
                Transacao tr = (Transacao)transacoes[i];
                if (tr.Data < data)
                {
                    if (tr.Tipo == 1)
                    {
                        saldo = saldo + tr.Valor;
                    }
                    else
                    {
                        saldo = saldo - tr.Valor;
                    }
                }
            }

            // obtém dos meses subsequentes
            for (int i = 1; i <= 6; i++)
            {
                data = data.AddMonths(1);
                for (int j = 0; j < transacoes.Count; j++)
                {
                    Transacao tr = (Transacao)transacoes[j];
                    if ((tr.Data.Month == data.Month) && (tr.Data.Year == data.Year))
                    {
                        if (tr.Tipo == 1)
                        {
                            saldo = saldo + tr.Valor;
                        }
                        else
                        {
                            saldo = saldo - tr.Valor;
                        }
                    }
                }
                Console.WriteLine("SALDO EM " + data.Month.ToString().PadLeft(2, '0') + "/" + data.Year + ": " + FormatarMoeda(saldo));
            }

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
        }
        static void ConversorMoedas()
        {

            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("    CONTROLE BANCÁRIO - CONVERSOR DE MOEDAS");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("1. Real para Dólar");
                Console.WriteLine("2. Real para Euro");
                Console.WriteLine("3. Real para Libras");
                Console.WriteLine("4. Voltar ao menu anterior");
                Console.Write("\nSua opção: ");
                int opcao = Int32.Parse(Console.ReadLine());
                double valor, valor_convertido;

                // gerencia as opções do menu
                switch (opcao)
                {
                    case 1: // real para dólar
                        Console.Write("\nInforme o valor em Reais: ");
                        valor = double.Parse(Console.ReadLine());

                        valor_convertido = valor * 4.86;

                        Console.WriteLine("\nO valor convertido para Dólar é: " +
                          FormatarMoeda(valor_convertido));
                        Console.WriteLine("\nPressione uma tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 2: // real para Euro
                        Console.Write("\nInforme o valor em Reais: ");
                        valor = double.Parse(Console.ReadLine());

                        valor_convertido = valor * 5.25;

                        Console.WriteLine("\nO valor convertido para Euro é: " +
                          FormatarMoeda(valor_convertido));

                        Console.WriteLine("\nPressione uma tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 3: // real para Libra
                        Console.Write("\nInforme o valor em Reais: ");
                        valor = double.Parse(Console.ReadLine());

                        valor_convertido = valor * 6.13;

                        Console.WriteLine("\nO valor convertido para Libra é: " +
                          FormatarMoeda(valor_convertido));

                        Console.WriteLine("\nPressione uma tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 4:
                        continuar = false; // volta ao menu anterior
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida.");
                        Console.WriteLine("\nPressione uma tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static string FormatarMoeda(double valor)
        {
            return string.Format("{0:c}", valor).Replace("R$", "");
        }
    }
}


