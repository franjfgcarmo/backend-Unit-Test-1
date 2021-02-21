using System;
using System.IO;

namespace Tictactoe.Utils
{
    public class IO
    {
        private static IO io;

        public static IO Instance()
        {
            if (io == null)
            {
                io = new IO();
            }
            return io;
        }

        private IO()
        {
        }

        public virtual string ReadString(string title)
        {
            string input = null;
            bool ok = false;
            do
            {
                Write(title);
                try
                {
                    input = Console.ReadLine();
                    ok = true;
                }
                catch (IOException)
                {
                    WriteError("de cadena de caracteres");
                }
            } while (!ok);
            return input;
        }

        public virtual int ReadInt(string title)
        {
            int input = 0;
            bool ok = false;
            do
            {
                try
                {
                    input = int.Parse(ReadString(title));
                    ok = true;
                }
                catch (FormatException)
                {
                    WriteError("entero");
                }
            } while (!ok);
            return input;
        }

        public virtual char ReadChar(string title)
        {
            char charValue = ' ';
            bool ok = false;
            do
            {
                string input = ReadString(title);
                if (input.Length != 1)
                {
                    WriteError("caracter");
                }
                else
                {
                    charValue = input[0];
                    ok = true;
                }
            } while (!ok);
            return charValue;
        }

        public virtual void Writeln() => Console.WriteLine();

        public virtual void Write(string @string) => Console.Write(@string);

        public virtual void Writeln(string @string) => Console.WriteLine(@string);

        private void WriteError(string formato) => Console.WriteLine($"ERROR DE FORMATO! Introduzca un valor con formato {formato}.");
    }
}