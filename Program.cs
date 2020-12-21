using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {

            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;
            string opcaoUsuario = obterOpcaoUsuario();

            //casos

            while (opcaoUsuario.ToUpper() != "4")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        Console.WriteLine("Informe a nota do aluno: ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota informado é inválido");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                    case "2":
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} NOTA: {a.Nota}");
                            }
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        int qtdAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++){
                            if (!string.IsNullOrEmpty(alunos[i].Nome)){
                                notaTotal = notaTotal + alunos[i].Nota;
                                qtdAlunos ++;
                            }    
                        }
                        var mediaGeral = notaTotal / qtdAlunos;
                        ConceitoEnum conceitoGeral;

                        if(mediaGeral < 3) {
                            conceitoGeral = ConceitoEnum.E;
                        }
                        else if (mediaGeral < 5) {
                            conceitoGeral = ConceitoEnum.D;
                        }
                        else if (mediaGeral < 7) {
                            conceitoGeral = ConceitoEnum.C;
                        }
                        else if (mediaGeral < 8) {
                            conceitoGeral = ConceitoEnum.B;
                        }
                        else {
                            conceitoGeral = ConceitoEnum.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = obterOpcaoUsuario();
            }
        }

        private static string obterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("===============================");
            Console.WriteLine("====== SCHOOL SYSTEM 1.0 ======");
            Console.WriteLine("===============================");
            Console.WriteLine();
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("4 - Sair");
            Console.WriteLine();

            String opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
