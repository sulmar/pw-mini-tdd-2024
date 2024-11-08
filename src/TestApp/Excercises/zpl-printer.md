# Ćwiczenie TDD - ZPL

## Wprowadzenie

Sklep internetowy potrzebuje funkcji drukowania etykiet do paczek. Sklep korzysta z sieciowych drukarek termicznych, które obsługują język ZPL. Twoim zadaniem jest utworzenie biblioteki, którya umożliwi drukowanie etykiet.

## Opis
Składnia ZPL (Zebra Programming Language) umożliwia rozmieszczenie tekstu, grafik, kodów kreskowych i innych elementów na etykiecie. Oto kilka kluczowych cech składni ZPL:


- Przykład - kod w ZPL do wygenerowania etykiety z napisem "Hello World":

```
^XA        ; Rozpoczęcie etykiety
^FO50,50   ; Pozycja początkowa tekstu (x=50, y=50)
^A0N,36,36 ; Wybór czcionki A, normalna orientacja, wysokość i szerokość znaków 36 punktów
^FDHello World^FS ; Wprowadzenie tekstu i zakończenie definicji pola
^XZ        ; Zakończenie etykiety i zlecenie druku

```

- Przykład - kod w ZPL do wygenerowania etykiety z kodem kreskowym "123456":

```
^XA             ; Rozpoczęcie etykiety
^FO50,50        ; Pozycja początkowa tekstu (x=50, y=50)
^B3N,N,100,Y,N  ; Deficja kodu kreskowego
^FD123456^FS    ; Wprowadzenie tekstu i zakończenie definicji pola
^XZ             ; Zakończenie etykiety i zlecenie druku
```


- Przykład - kod w C# do drukowania w sieci za pomocą protokołu TCP:
``` csharp
 TcpClient tcpClient = new TcpClient();
 tcpClient.Connect(ipAdress, port);

 var stream = new StreamWriter(tcpClient.GetStream());
 stream.Write(content);
 stream.Flush(); 
 stream.Close();
 tcpClient.Close();
```

Uwaga:  Nie mamy dostępnej drukarki. Możemy skorzystać tylko z [ZPL Online Viewer](https://labelary.com/viewer.html)

## Zadanie
Przygotuj bibliotekę **LabelGenerator**, która umożliwi drukowanie etykiet w formacie _ZPL_.

Wymagania realizuj pojedynczo w cyklu:
- nowe wymaganie
- test pod wymagania (Red)
- kod przechodzący test (Green)
- refaktoryzacja kodu i testów (Refactor)


## Wymagania
1. Utwórz metodę _CreateLabel(int width, int height)_ do utworzenia etykiety o podanych rozmiarach
1. Utwórz metodę _SetText(string text)_ do umieszczenia pola na etykiecie
2. Pusty tekst powinien rzucać wyjątek _ArgumentNullException_.
3. Utwórz metodę _SetPosition(int x, int y)_ do ustawienia położenia pola 
4. Przekroczenie rozmiaru etykiety powinno rzucać wyjątkiem _ArgumentOutOfRangeException_.
8. Utwórż metodę _SetBarcode(string barcode)_ do drukowania kodu kreskowego w formacie _code 39_
9. Pusty string powinien rzucać wyjątek _ArgumentNullException_.


## Dokumentacja
- Labelary Engine Documentation https://labelary.com/docs.html
- ZPL Commands https://support.zebra.com/cpws/docs/zpl/zpl_Exercises.pdf
- ZPL II Programming Guide https://www.servopack.de/support/zebra/ZPLII-Prog.pdf

