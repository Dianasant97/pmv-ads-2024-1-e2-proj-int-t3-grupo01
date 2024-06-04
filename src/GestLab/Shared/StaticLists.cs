namespace GestLab.Shared
{
    public static class StaticLists
    {
        public static IEnumerable<string> ObterCores()
        {
            return new List<string>() {
                "Azul",
                "Verde",
                "Amarelo",
                "Preto",
                "Transparente"
            };
        }

        public static IEnumerable<string> ObterStatusPedidos()
        {
            return new List<string>() {
                "Novo",
                "Pendente Lentes e Armação",
                "Pendente Armação",
                "Pendente Lentes"
            };
        }

        public static IEnumerable<string> ObterTiposProduto()
        {
            return new List<string>() {
                "Lentes",
                "Armação"
            };
        }

        public static IEnumerable<string> ObterTiposUsuario()
        {
            return new List<string>() {
                "Administrador",
                "Cliente",
                "Assistente",
                "Montador"
            };
        }

        public static IEnumerable<string> ObterStatusPedido()
        {
            return new List<string>() {
                "Pedido Feito",
                "Pedido Aprovado",
                "Nota Pedido Enviada",
                "Montagem Iniciada",
                "Pedido Concluído"
            };
        }
    }
}
