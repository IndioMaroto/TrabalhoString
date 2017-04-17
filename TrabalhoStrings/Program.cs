using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Claudio de Jesus Junior - 555835

namespace TrabalhoStrings
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Claudio de Jesus Junior - 555835\n\n");
            Console.WriteLine("1) Arquivo 'nomes_telefones' para cada número de telefone, retirar os parenteses e traços e apresentar no console.\n");
            TextReader reader = new StreamReader("nomes_telefones.txt");
            String linha = reader.ReadLine();
            while (linha != null)
            {
                var pos = linha.IndexOf('(');
                var linhaShow = linha.Substring(pos+1);
                linhaShow = linhaShow.Replace(')',' ').Replace('-',' ');
                Console.WriteLine(linhaShow);
                linha = reader.ReadLine();
            }

            Console.WriteLine("\n2) Arquivo 'nomes_telefones' para cada nome de pessoa, verificar os maiores de 12 caracteres e apresentar na tela os mesmos em UpperCase.\n");
            reader = new StreamReader("nomes_telefones.txt");
            linha = reader.ReadLine();
            while (linha != null)
            {
                var pos = linha.IndexOf('(');
                pos--;
                if (pos > 12)
                {
                    linha = linha.ToUpper();
                    Console.WriteLine(linha);
                }
                linha = reader.ReadLine();
            }

			Console.WriteLine("\n3) Arquivo 'datas' extrair somente o ano e mostrar no console.\n");
			reader = new StreamReader("datas.txt");
			linha = reader.ReadLine();
			while (linha != null)
			{
				string ano = linha.Substring(6,4);
				Console.WriteLine(ano);
				linha = reader.ReadLine();
			}

			Console.WriteLine("\n4) Arquivo 'marcas_carros' extrair somente as marcas e apresentar no console.\n");
			reader = new StreamReader("marcas_carros.txt");
			linha = reader.ReadLine();
			while (linha != null)
			{
				int endMarca = linha.IndexOf('@');
				string marca = linha.Substring(0,endMarca--);
				Console.WriteLine(marca);
				linha = reader.ReadLine();
			}

			Console.WriteLine("\n5) Arquivo 'produtos_estoque' mostrar o valor total de itens em estoque e o valor total em $.\n");
			reader = new StreamReader("produtos_estoque.txt");
			linha = reader.ReadLine();

			int qtdTotal = 0;
			decimal totalGeral = 0;

			while (linha != null)
			{
				linha = linha.Replace('.', ',');

				int startValor = linha.IndexOf('$') + 1;
				int endValor = linha.IndexOf('|') - 1;
				int tamValor = endValor - startValor;
				decimal valor = Convert.ToDecimal(linha.Substring(startValor, tamValor));

				int startQtd = linha.IndexOf('|') + 1;
				int endQtd = linha.Length;
				int tamQtd = endQtd - startQtd;
				int qtd = Convert.ToInt32(linha.Substring(startQtd, tamQtd));

				decimal total = valor * qtd;
				Console.WriteLine(valor + "\t" + qtd + "\t" + total);
				linha = reader.ReadLine();

				qtdTotal = qtdTotal + qtd;
				totalGeral = totalGeral + total;
			}
			Console.WriteLine("\nQuantidade Total: " + qtdTotal);
			Console.WriteLine("\nTotal: R$" + totalGeral);

			Console.ReadKey();
        }
    }
}
