﻿namespace MathGame.Kriz_J.Games;

public class Subtraction(List<ScoreRecord> scoreKeeper) : Game(scoreKeeper)
{
    protected override void Loop()
    {
        while (true) { };

    }

    protected override void StandardGame()
    {
        throw new NotImplementedException();
    }

    protected override void TimedGame()
    {
        throw new NotImplementedException();
    }

    protected override void CustomGame()
    {
        throw new NotImplementedException();
    }

    public void PrintGameMenu()
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Subtraction}");
        Console.WriteLine("\tThe goal of this game is to....");
        Console.ReadKey();
    }
}