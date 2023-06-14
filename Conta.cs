using System;
using System.Collections;

namespace ControleBancario
{
    class Conta
    {
        private int id; // identifica qual conta é, conta 1, conta 2, conta 3...
        private String banco;
        private String agencia;
        private int numero;
        private double saldo;

        public int ID { get => id; set => id = value; }
        public string Banco { get => banco; set => banco = value; }
        public string Agencia { get => agencia; set => agencia = value; }
        public int Numero { get => numero; set => numero = value; }
        public double Saldo { get => saldo; set => saldo = value; }

        public Conta(int id, String banco, String agencia, int numero)
        {
            this.ID = id;
            this.Banco = banco;
            this.Agencia = agencia;
            this.Numero = numero;
            this.Saldo = 0.0;
        }
    }
}
