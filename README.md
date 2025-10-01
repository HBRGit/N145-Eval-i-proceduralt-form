Skabe en konsol app som kan evaluere en simpel formel som kan indeholde følgende elementer:

Heltal (f.eks. 5)
operatoren
Alle mellemrum ignoreres
I denne version af opgaven skal du løse den uden brug af klasser eller strukturer, og jeg vil foreslå en løsning med en enkelt metode som tager en streng som input og returnerer et heltal som output.

int Eval(string formel)
{
    // din kode her
}

Her er et par eksempler på hvordan metoden skal fungere:
Console.WriteLine(Eval("1+2+3"));                   // Output: 6
Console.WriteLine(Eval("10+20"));                   // Output: 30
Console.WriteLine(Eval("5"));                       // Output: 5
Console.WriteLine(Eval("1+1+1+1+1"));               // Output: 5
Console.WriteLine(Eval("1   + 1      +1+  1+1"));   // Output: 5
Console.WriteLine(Eval("1+1+1+1+1+1+1+1+1"));       // Output: 9
