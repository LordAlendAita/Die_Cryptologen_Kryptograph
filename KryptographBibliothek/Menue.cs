using System;
using ExtendedWinConsole;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace KryptographBibliothek
{
    public class Menue
    {
        private static void CenterText(string text, ConsoleColor color = ConsoleColor.White)
        {
            if (ExConsole.Width < text.Length)
            {
                throw new ArgumentException("CenterText: text size must be smaler than width");
            }
            for (int i = 0; i < (ExConsole.Width / 2 - (text.Length / 2)); i++)
            {
                ExConsole.Write(' ');
            }
            ExConsole.WriteLine(text, (ushort)color);
        }
        private static void VerticalLine(char c = '\u2500', ConsoleColor color = ConsoleColor.White)
        {
            for (int i = 0; i < ExConsole.Width-1; i++)
            {
                ExConsole.Write(c,(ushort)color); 
            }
            //ExConsole.WriteLine();
        }
        private static string GetValidFilePath(string pathToCheck, string error)
        {
            while (!File.Exists(pathToCheck))
            {
                ExConsole.WriteLine(error);
                ExConsole.ReadKey();
                COORD tempCurser = ExConsole.Cursor;
                CHAR_INFO[] buffer = ExConsole.OutputBuffer;
                for (int i = ExConsole.Get2dBufferIndex(tempCurser.x, tempCurser.y); i >= ExConsole.Get2dBufferIndex(0, tempCurser.y - 2); i--)
                {
                    buffer[i].UnicodeChar = ' ';
                }
                tempCurser.y -= 2;
                tempCurser.x = 0;
                ExConsole.OutputBuffer = buffer;
                ExConsole.Cursor = tempCurser;
                ExConsole.UpdateBuffer(false);
                pathToCheck = ExConsole.ReadLine();
            }
            return pathToCheck;
        }
        public static void HauptMenue() //to be added: zeichen ersetzen, ausgabe
        {   
            ExConsole.SetFont(10, 20);
            short width = 100, height = 26;
            ExConsole.SetMaximumBufferSize(width, height);
            ExConsole.SetBufferSize((short)(width+1), height);
            ExConsole.SetWindowSize(width, height+3, true); // set window size is a bit buggy therefor the +3
            ExConsole.SetCursorVisiblity(false);

            ExConsole.WriteLine();
            CenterText("Kryptograph", ConsoleColor.Green);
            ExConsole.WriteLine();
            VerticalLine('\u2500',ConsoleColor.DarkGray);

            ExConsole.Write("In diesem Kryptographen wird die ");
            ExConsole.Write(" Substitution ", (ushort)ConsoleColor.Red);
            ExConsole.WriteLine("benutzt.");
            Thread.Sleep(500);

            ExConsole.WriteLine("Geben Sie den Pfad zur verschlüsselten Datei ein:");
            string cipheredFile, fileNotFound = "Datei konnte nicht gefunden werde. Drück eine taste und probier es nochmal";
            cipheredFile = ExConsole.ReadLine();
            cipheredFile = GetValidFilePath(cipheredFile, fileNotFound);

            string cipheredText = " ";
            //cipheredText = Auslesenciffre.Auslesen(cipheredFile);

            ExConsole.WriteLine("Geben Sie den Pfad zur zeichentabellen Datei ein:");
            string tableFile = ExConsole.ReadLine();
            tableFile = GetValidFilePath(tableFile, fileNotFound);

            Dictionary<char, double> table = new();
            //table = AuslesenTabelle.Auslesen(tableFile);

            SubWindow displayCipheredText = new SubWindow(0,7,(short)(width-2),19);
            displayCipheredText.Write(cipheredText);
            ExConsole.WriteSubWindow(displayCipheredText);
            ExConsole.UpdateBuffer(false);

            { // removes the first file path and question.
                COORD tempCurser = ExConsole.Cursor;
                CHAR_INFO[] buffer = ExConsole.OutputBuffer;
                for (int i = ExConsole.Get2dBufferIndex(ExConsole.Width-1, 6); i >= ExConsole.Get2dBufferIndex(0, 5); i--) 
                {
                    buffer[i].UnicodeChar = ' ';
                }
                tempCurser.y -= 4;
                tempCurser.x = 0;
                ExConsole.OutputBuffer = buffer;
                ExConsole.Cursor = tempCurser;
                ExConsole.UpdateBuffer(false); ;
            }

            Thread.Sleep(700);
            ExConsole.WriteLine("geben sie ein alle zeichen die sie entfernen wollen ein:");
            string listOfChartoRemove = ExConsole.ReadLine();
            foreach (char c in listOfChartoRemove)
            {
                //cipheredText = Entfernen.Remover(cipheredText, c);
                displayCipheredText.Clear();
                displayCipheredText.Write(cipheredText);
                ExConsole.WriteSubWindow(displayCipheredText);
                ExConsole.UpdateBuffer(false);
                Thread.Sleep(500);
            }

            Dictionary<char, double> textTable = new();
            //textTable = Class1.Counter(cipheredText);

            //string clearText = ZeichenErsetzen.Ersetzen(/*to be added arguments*/);

            // add code of: @ayoubcgn

            ExConsole.ReadKey();
        }
        public static void Testing() // purely for debuging 
        {
            ExConsole.SetFont(10, 20);
            short width = 100, height = 26;
            ExConsole.SetMaximumBufferSize(width, height);
            ExConsole.SetBufferSize((short)(width + 1), height);
            ExConsole.SetWindowSize(width, height + 3, true); // set window size is a bit buggy therefor the +2
            ExConsole.SetCursorVisiblity(false);
            for (int i = 0; i < 10; i++)
                if (i % 10 != 0)
                    ExConsole.Write(i % 10, 3);
                else
                    ExConsole.Write(' ');
            ExConsole.Write('\n');
            ExConsole.ReadKey();
            for (int i = 0; i < 10; i++)
            {
                ExConsole.Remove(false);
                Thread.Sleep(200);
            }

            ExConsole.ReadKey(true);
        }
    }
}
