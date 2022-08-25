﻿// See https://aka.ms/new-console-template for more information
using Core;

Console.WriteLine("Hello, World!");
 
var cadena = "255,216,255,224,0,16,74,70,73,70,0,1,1,0,0,1,0,1,0,0,255,219,0,132,0,9,6,7,19,18,18,18,19,19,18,21,21,19,23,21,21,21,21,21,21,21,21,21,23,21,23,21,21,23,24,23,23,21,21,24,29,40,32,24,26,37,29,21,21,33,49,33,37,41,43,46,46,46,23,31,51,56,51,44,55,40,45,46,43,1,10,10,10,14,13,14,26,16,16,26,50,29,29,29,47,45,45,45,43,43,43,45,43,45,45,45,45,45,45,43,43,45,45,45,45,45,43,45,45,43,45,45,45,45,45,45,45,45,55,45,43,45,45,45,55,43,43,45,45,43,55,43,45,43,255,192,0,17,8,0,168,1,43,3,1,34,0,2,17,1,3,17,…,92,93,48,224,65,209,114,228,209,123,24,242,156,75,6,88,100,14,206,144,1,37,47,87,14,27,4,136,249,46,92,182,66,77,155,184,249,101,164,10,137,115,12,78,102,187,72,185,29,32,234,19,88,108,217,229,167,189,165,185,9,238,230,185,114,141,154,219,61,22,5,243,125,22,132,174,92,184,220,143,220,198,253,51,56,163,114,186,157,97,171,14,87,245,166,248,7,200,134,187,192,173,22,185,114,228,145,40,151,165,168,85,205,54,136,49,127,220,34,202,229,202,193,8,204,170,231,46,92,161,10,56,161,23,41,92,137,15,255,217";
var arrayOfBytes = cadena.Split(',');
var arr = new byte[arrayOfBytes.Length];
var valor = "";
try
{
    for (int i = 0; i < arr.Length; i++)
    {
        valor = arrayOfBytes.ElementAt(i);
        arr[i] = byte.Parse(arrayOfBytes.ElementAt(i));
    }
}
catch (Exception ex)
{
    var a = ex;
}
var input = new RecognizeNaturalImages.ModelInput()
{
    ImageSource = arr
};
var resut  = RecognizeNaturalImages.Predict(input);
Console.WriteLine(resut.PredictedLabel);