﻿using MathGame.Kriz_J.Games;
using static MathGame.Kriz_J.ConsoleHelperMethods;

namespace MathGame.Kriz_J;

public class MainMenu
{
    private readonly List<ScoreRecord> _scoreKeeper = [];

    public char Selection { get; set; }

    public bool Quit => Selection == 'Q';

    public void RouteSelection()
    {
        switch (Selection)
        {
            case 'A' or 'S' or 'M' or 'D':
                RouteGameSection();
                break;
            case 'R':
                ShowRecentGames();
                break;
            case 'H':
            // High Score?
            case 'Q':
                PrintMessage("Exiting game . . .");
                break;
            default:
                PrintMessage("Not a valid selection . . .");
                break;
        }
    }

    private void ShowRecentGames()
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.RecentGames}");
        Console.WriteLine();

        Console.WriteLine($"{"\tGAME TYPE",-15} {"MODE",-15}{"DIFFICULTY",-15}{"SCORE",-15}{"TIME NEEDED",-15}");

        foreach (var record in _scoreKeeper.OrderByDescending(s => s.Timestamp))
        {
            Console.Write("\t");
            Console.Write($"{record.Game,-15}");
            Console.Write($"{record.Mode,-15}");
            Console.Write($"{record.Difficulty,-15}");
            Console.Write($"{$"{record.Score}/{record.NumberOfQuestions} - {record.PercentageScore} %",-15}");

            if (record.TimeNeeded is not null)
                Console.Write($"{$@"{record.TimeNeeded:mm\:ss\.fff}",-15}");

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("\t. . . Press any key to go back.");
        Console.ReadKey();
    }

    private void RouteGameSection()
    {
        Game _ = Selection switch
        {
            'A' => new Addition(_scoreKeeper),
            'S' => new Subtraction(_scoreKeeper),
            'M' => new Multiplication(_scoreKeeper),
            'D' => new Division(_scoreKeeper),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static void Print()
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.MainMenu}");
        Console.WriteLine();
        Console.WriteLine("\tSelect to play one of the following games:");
        Console.WriteLine("\t\t[A]ddition");
        Console.WriteLine("\t\t[S]ubtraction");
        Console.WriteLine("\t\t[M]ultiplication");
        Console.WriteLine("\t\t[D]ivision");
        Console.WriteLine();
        Console.WriteLine("\t\t[R]ecent Games");
        Console.WriteLine("\t\t[H]igh Score");
        Console.WriteLine("\t\t[Q]uit");
        Console.WriteLine();
        Console.Write("\t> ");
    }
}