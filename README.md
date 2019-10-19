# Obsługa wystawiania zwolnień lekarskich
Projekt studencki na przedmiot Inżynieria Oprogramowania.

**Platforma docelowa**: Windows
**Wykorzystane technologie**: WPF, MSSQL, MigraDoc

![Zwolnienie](https://github.com/BialyPingwin/aplikacja-przychodnia/blob/master/extras/Aplikacja%20przychodnia%20zwolnienie.png?raw=true)

Aplikacja jest prostą adaptacją systemu wystawiania zwolnień online. Umożliwia stworzenie dwóch typów kont: administratora i lekarza. Administrator zarządza kontami lekarzy, dodaje, usuwa i resetuje hasła. Lekarz wybiera pacjenta po numerze PESEL i numerze NIM z bazy danych, a następnie wystawia mu zwolnienie L4 lub L10, które można eksportować do PDF, a także przesłać do bazy danych.  

# Specyfikacja
1. Moduł administratora
    -dodawanie i usuwanie konta użytkowników(lekarzy)
    -resetowanie haseł użytkowników
    -dostęp do raportów z obsługi lekarzy
    -przegląd i edycja baz danych do których aplikacja ma dostęp
2. Moduł Lekarza
    -Wyszukiwanie pacjenta po numerze PESEL i numerze NIP firmy w której pracuje
    -Wystawianie zwolnienia
    -Eksport zwolnienia do pliku PDF
    -Automatyczne wysłanie zwolnienia do bazy danych

# Wersja demonstracyjna
W pełni działająca aplikacja podpięta do bazy danych - [Pobierz teraz](https://github.com/BialyPingwin/aplikacja-przychodnia/releases/tag/v1.0)

# Przydatne pliki
[Instrukcja obsługi](https://github.com/BialyPingwin/aplikacja-przychodnia/files/3590580/Instrukcja-obslugi.docx)
[Sprawozdanie z testów](https://github.com/BialyPingwin/aplikacja-przychodnia/files/3590592/Sprawozdanie.z.testow.pdf)

# Współtwórcy
CODE/UXUI:
@BialyPingwin - kierownik projektu
@Abaddon27
@mariapsz
@elstanicki

Dokumentacja/Test:
@JulaHula
@zuzzbi
@eugeniuszG
@mavlevich
