using AdapterPattern;

//var t = new InternetThermometer();

//Console.WriteLine(t.Themperature);

var detector = new Detector(new InternetThermometerAdapter(new InternetThermometer()));
Console.WriteLine(detector.Detect());

//var detector = new Detector(new MercuryThermometer());

//for (int i = 0; i < 20; i++)
//{
//    Console.WriteLine(detector.Detect());
//}