// See https://aka.ms/new-console-template for more information
using Core;
using static Core.SentimentAnalysis;

Console.WriteLine("Hello, World!");

ModelInput modelInput = new ModelInput
{
    LoggedIn = true,
    SentimentText = "this is a great day. congratulations"
};

var salida = SentimentAnalysis.Predict(modelInput);


ModelInput modelInput2 = new ModelInput
{
    LoggedIn = true,
    SentimentText = "you are rude"
};

var salida2 = SentimentAnalysis.Predict(modelInput2);
Console.WriteLine(salida);
Console.ReadKey();