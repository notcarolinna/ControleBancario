using System;

namespace ControleBancario {
  class Transacao{
    int id; // id único da transação
    Conta conta; // conta associada a essa transação
    double valor;
    DateTime data;
    String categoria;
    String descricao;
    int tipo; // 1: Receita; 2: Despesa

    public int ID { get => id; set => id = value; }
    public Conta Conta { get => conta; set => conta = value; }
    public double Valor { get => valor; set => valor = value; }
    public DateTime Data { get => data; set => data = value; }
    public string Categoria { get => categoria; set => categoria = value; }
    public string Descricao { get => descricao; set => descricao = value; }
    public int Tipo { get => tipo; set => tipo = value; }

    // construtor desta classe
    public Transacao(int id, Conta conta, double valor, DateTime data,
      String categoria, String descricao, int tipo) {
      this.id = id;
      this.conta = conta;
      this.valor = valor;
      this.data = data;
      this.categoria = categoria;
      this.descricao = descricao;
      this.tipo = tipo;
    }
  }
}

