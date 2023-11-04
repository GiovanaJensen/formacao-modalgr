using System;

class Program {
  public static void Main (string[] args) {

    String nome;
    DateTime data;
    string format = "dd/MM/yyyy";
    bool validInput = false;
    double salarioAtual, valorEmprestimo;
    
    Console.WriteLine ("Nome do colaborador:");
    nome = Console.ReadLine();

    do
    {
        Console.WriteLine("Data de admissao (formato dd/MM/yyyy): ");
        string dataAdmissao = Console.ReadLine();

        if (DateTime.TryParseExact(dataAdmissao, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out data))
        {
            validInput = true;
        }
        else
        {
            Console.WriteLine("Formato inválido. Tente novamente.");
        }
    } while (!validInput);

    Console.WriteLine("Salario atual: ");
    salarioAtual = double.Parse(Console.ReadLine());

    Console.WriteLine("Valor emprestimo: ");
    valorEmprestimo = double.Parse(Console.ReadLine());

      if(valorEmprestimo % 2 == 0 && (valorEmprestimo <= salarioAtual*2) && (DateTime.Now - data).TotalDays > 1825){
        Console.WriteLine("Voce atende a todos os requisitos!");
      }else{
      Console.WriteLine("Infelizmente voce nao atende aos requisitos para o emprestimo!");
    }
  }
}