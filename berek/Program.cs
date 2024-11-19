//Ebben a feladatban egy cég dolgozóinak 2020-as adatai1 állnak rendelkezésünkre, melyekkel programozási feladatokat kell megoldania.

//A feladat megoldása során vegye figyelembe a következőket:
//-A képernyőre írást igényló' részfeladatok eredményének megjelenítése előtt írja a képernyőre a feladat sorszámát (például:3. feladat:)!
//- Az egyes feladatokban a kiírásokat a minta szerint készítse el!
//- Az ékezetmentes azonosítók és kiírások is elfogadottak.
//- Az azonosítókat kis- és nagybetűkkel is kezdheti.
//- A program megírásakor az állományban lévő adatok helyes szerkezetét nem kell ellenőriznie, feltételezheti, hogy a rendelkezésre álló adatok a leírtaknak megfelelnek.
//- Megoldását úgy készítse el, hogy az azonos szerkezetú, de tetszőleges bemeneti adatok mellett is helyes eredményt adjon! 
//A berek2020.txt UTF-8 kódolású forrásállomány soraiban egy-egy dolgozó adatait tároltuk a következő

//sorrendben: •neve, például: Beri Dániel •neme: nő vagy férfi •a részleg, ahol dolgozik, például: beszerzés •a belépés éve, például: 1979 •a dolgozó bére (fizetése), például: 222 943 Az állomány első sora a mezőneveket tartalmazza, az adatokat pontosvesszővel választottuk el:
//Név; Neme; Részleg; Belépés; Bér
//Beri Dániel; férfi; beszerzés; 1979; 222943
//Csavar Pista; férfi; pénzügy; 1995; 234074

//1.Készítsen grafikus vagy konzolalkalmazást (projektet) a következő feladatok megoldásához, amelynek projektjét berek2020 néven mentse el!
using berek;
using System.Text;

Console.WriteLine("1. feladat");

//2. Olvassa be a berek2020.txt állomány sorait és tárolja az adatokat egy olyan összetett adatszerkezetben, amely használatával a további feladatok megoldhatók! Ügyeljen arra, hogy az állomány első sora az adatok fejlécét tartalmazza!
Console.WriteLine("2. feladat");

List<ber> fizu= new();
using StreamReader sr = new StreamReader(
    path: @"..\..\..\src\berek2020.txt",
    encoding: Encoding.UTF8);

sr.ReadLine();
while (!sr.EndOfStream)
{
    fizu.Add(new ber(sr.ReadLine()));
}

sr.Close();

//3. Határozza meg és írja ki a képernyőre, hogy hány dolgozó adatai találhatók a forrásállományban!
Console.WriteLine("3.feladat");
Console.WriteLine($"Dolgozók száma: {fizu.Count} fő");
//4. Határozza meg és írja ki a képernyőre a 2020-as átlagbéreket! Az eredményt ezer forintban, egy tizedesjegyre kerekítve jelenítse meg!
Console.WriteLine("4.feladat");
var harmas= fizu       
            .Average(s => s.Fizetes) / 1000;   


Console.WriteLine($"A 2020-as átlagbér: {Math.Round(harmas, 1)} ezer Ft");

//5. Kérje be egy részleg nevét a felhasználótól a minta szerint!
Console.WriteLine("5.feladat");
Console.Write("Kérem adja meg a részleg nevét: ");
string otos = Console.ReadLine();

//6. Az előző feladatban megadott részlegen keresse meg és írja ki a legnagyobb bérrel (fizetéssel) rendelkező dolgozó adatait! Ha a megadott részleg nem létezik a cégnél, akkor a „A megadott részleg nem létezik a cégnél!” feliratot jelenítse meg! Feltételezheti, hogy nem alakult ki „holtverseny” egy-egy részlegen dolgozók fizetése között!
Console.WriteLine("6.feladat");
var highestPaidEmployee = fizu
            .Where(e => e.Reszleg.Equals(otos, StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(e => e.Fizetes)
            .FirstOrDefault();

if (highestPaidEmployee != null)
{
    Console.WriteLine($"A(z) '{otos}' részlegen a legnagyobb fizetésű dolgozó:");
    Console.WriteLine($"Név: {highestPaidEmployee.Nev}, Fizetés: {highestPaidEmployee.Fizetes} Ft, Belépés éve: {highestPaidEmployee.Belepes}");
}
else
{
    Console.WriteLine("A megadott részleg nem létezik a cégnél!");
}

//7. Készítsen statisztikát az egyes részlegeken dolgozók számáról! A részlegek kiírásának sorrendje tetszőleges!
Console.WriteLine("7.feladat");
var departmentStats = fizu
       .GroupBy(e => e.Reszleg)
       .Select(g => new { Reszleg = g.Key, Count = g.Count() });

Console.WriteLine("Részlegek statisztikája:");
foreach (var stat in departmentStats)
{
    Console.WriteLine($"- {stat.Reszleg}: {stat.Count} fő");
}
