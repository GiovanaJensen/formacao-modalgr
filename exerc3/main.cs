using System;

class Program {
  public static void Main (string[] args) {

    string nome = receberInputString("Nome do colaborador:");
    DateTime data = receberDataInput("Data de admissao (formato dd/MM/yyyy):");
    double salarioAtual = ReceberInputNumero("Salario atual:");
    double valorEmprestimo = VerificarEmprestimo("Valor emprestimo (deve ser múltiplo de 2):", x => x % 2 == 0);

   if (IsElegivel(data, salarioAtual, valorEmprestimo)) {
            Program myProgram = new Program();
            Console.WriteLine(myProgram.NotasMaiorValor(valorEmprestimo));
            Console.WriteLine(myProgram.NotasMenorValor(valorEmprestimo));

            double valorMetadeEmprestimo = valorEmprestimo / 2;
            Console.WriteLine($"Notas Meio a Meio\n{valorMetadeEmprestimo} reais em notas de maior valor:");
            Console.WriteLine(myProgram.NotasMaiorValor(valorMetadeEmprestimo));
            Console.WriteLine($"{valorMetadeEmprestimo} reais em notas de menor valor:");
            Console.WriteLine(myProgram.NotasMenorValor(valorMetadeEmprestimo));
        } else {
            Console.WriteLine("Agradecemos seu interesse, mas você não atende os requisitos mínimos do programa");
        }
   }

  static string receberInputString(string prompt) {
        Console.WriteLine(prompt);
        return Console.ReadLine();
    }

    // Function to get date input
  static DateTime receberDataInput(string prompt) {
      string formato = "dd/MM/yyyy";
      DateTime data = DateTime.MinValue; // Initializing with default value
      bool isValido = false;
      while (!isValido) {
          string input = receberInputString(prompt);
          isValido = DateTime.TryParseExact(input, formato, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out data);
          if (!isValido) {
              Console.WriteLine("Formato inválido. Tente novamente.");
          }
      }
      return data;
  }

    static double ReceberInputNumero(string prompt) {
        Console.WriteLine(prompt);
        return double.Parse(Console.ReadLine());
    }

    static double VerificarEmprestimo(string prompt, Func<double, bool> condicao) {
        double valor;
        do {
            valor = ReceberInputNumero(prompt);
            if (!condicao(valor)) {
                Console.WriteLine("Insira um valor válido!");
            }
        } while (!condicao(valor));
        return valor;
    }

    static bool IsElegivel(DateTime data, double salarioAtual, double valorEmprestimo) {
        return (valorEmprestimo <= salarioAtual * 2) && (DateTime.Now - data).TotalDays > 1825;
    }

    string CalcularNotas(double valor, int[] tiposDeNotas) {
        string resultado = "";
        for (int i = 0; i < tiposDeNotas.Length; i++) {
            int qtdNotas = (int)(valor / tiposDeNotas[i]);
            valor %= tiposDeNotas[i];
            if (qtdNotas > 0) {
                resultado += $"{qtdNotas} x {tiposDeNotas[i]}\n";
            }
        }
        return resultado;
    }

    // Method for higher denomination notes
    string NotasMaiorValor(double valorEmprestimo) {
        int[] tiposDeNotas = { 100, 50, 20, 10, 5, 2 };
        return "Notas de Maior Valor\n" + CalcularNotas(valorEmprestimo, tiposDeNotas);
    }

    // Method for lower denomination notes
    string NotasMenorValor(double valorEmprestimo) {
        int[] tiposDeNotas = { 20, 10, 5, 2 };
        return "Notas de Menor Valor\n" + CalcularNotas(valorEmprestimo, tiposDeNotas);
    }
}