using PalhasAPI.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalhasAPI.Domain.Entities
{
    public class ContaFinanceira
    {
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public TipoConta Tipo { get; private set; }
        public DateTime Vencimento { get; private set; }
        public DateTime? PagoEm { get; private set; }
        public bool Pago { get; private set; }
        public string? Categoria { get; private set; }
        public DateTime CriadoEm { get; private set; }


        public ContaFinanceira(string descricao, decimal valor, TipoConta tipo, DateTime vencimento, string? categoria)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Valor = valor;
            Tipo = tipo;
            Vencimento = vencimento;
            Pago = false;
            Categoria = categoria;
            CriadoEm = DateTime.UtcNow;
        }


    }
}
