using System;

class Program {
  public static void Main (string[] args) {
    
    Program myProgram = new Program();
    String nome;
    DateTime data;
    string formato = "dd/MM/yyyy";
    bool isValido = false;
    double salarioAtual, valorEmprestimo;

    Console.WriteLine ("Nome do colaborador:");
    nome = Console.ReadLine();

    do
    {
        Console.WriteLine("Data de admissao (formato dd/MM/yyyy): ");
        string dataAdmissao = Console.ReadLine();

        if (DateTime.TryParseExact(dataAdmissao, formato, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out data))
        {
            isValido = true;
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

    do{
      Console.WriteLine("Valor emprestimo: ");
      valorEmprestimo = double.Parse(Console.ReadLine());
      
      if (valorEmprestimo % 2 != 0)
      {
          Console.WriteLine("Insira um valor válido! O valor deve ser múltiplo de 2.");
      }
    }while(valorEmprestimo % 2 != 0);

      if(valorEmprestimo % 2 == 0 && (valorEmprestimo <= salarioAtual*2) && (DateTime.Now - data).TotalDays > 1825){
                                    
        Console.WriteLine(myProgram.NotasMaiorValor(valorEmprestimo));
        Console.WriteLine(myProgram.NotasMenorValor(valorEmprestimo));

        Console.WriteLine($"Notas Meio a Meio\n{valorEmprestimo/2} reais em notas de maior valor:");
        Console.WriteLine(myProgram.NotasMaiorValor(valorEmprestimo/2));
        Console.WriteLine($"{valorEmprestimo/2} reais em notas de menor valor:");
        Console.WriteLine(myProgram.NotasMenorValor(valorEmprestimo/2));
        
      }else{
      Console.WriteLine("Agradecemos seu interesse, mas você não atende os requisitos mínimos do programa");
    }
  }

  String NotasMaiorValor(double valorEmprestimo){
    int notasDeCem = (int)(valorEmprestimo / 100);
    int restanteAposCem = (int)(valorEmprestimo % 100);
    int notasDeCinquenta = restanteAposCem / 50;
    int restanteAposCinquenta = restanteAposCem % 50;
    int notasDeVinte = restanteAposCinquenta / 20;
    int restanteAposVinte = restanteAposCinquenta % 20;
    int notasDeDez = restanteAposVinte / 10;
    int restanteAposDez = restanteAposVinte % 10;
    int notasDeCinco = restanteAposDez / 5;
    int notasDeDois = restanteAposDez % 5;

    string resultado = "Notas de Maior Valor\n";

    if (notasDeCem > 0)
    {
        resultado += $"{notasDeCem} x 100\n";
    }
    if (restanteAposCem > 0)
    {
        resultado += $"{notasDeCinquenta} x 50\n";
    }
    if (notasDeVinte > 0)
    {
        resultado += $"{notasDeVinte} x 20\n";
    }
    if (notasDeDez > 0)
    {
        resultado += $"{notasDeDez} x 10\n";
    }
    if (notasDeCinco > 0)
    {
        resultado += $"{notasDeCinco} x 5\n";
    }
    if (notasDeDois > 0)
    {
        resultado += $"{notasDeDois} x 2";
    }
    return resultado; 
  }

  String NotasMenorValor(double valorEmprestimo){
    int notasDeVinte = (int)(valorEmprestimo / 20);
    int restanteAposVinte = (int)(valorEmprestimo % 20);
    int notasDeDez = (restanteAposVinte / 10);
    int restanteAposDez = restanteAposVinte % 10;
    int notasDeCinco = restanteAposDez / 5;
    int notasDeDois = restanteAposDez % 5;

    string resultado = "Notas de Menor Valor\n";

    if (notasDeVinte > 0)
    {
        resultado += $"{notasDeVinte} x 20\n";
    }

    if (notasDeDez > 0)
    {
        resultado += $"{notasDeDez} x 10\n";
    }

    if (notasDeCinco > 0)
    {
        resultado += $"{notasDeCinco} x 5\n";
    }

    if (notasDeDois > 0)
    {
        resultado += $"{notasDeDois} x 2";
    }

    return resultado;
  }
}