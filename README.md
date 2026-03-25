Projekt to aplikacja konsolowa zarządzająca wypożyczalnią sprzętu na uczelni. 
System pozwala na dodawanie nowych użytkowników i sprzętu, rejestrowanie wypożyczeń i zwrotów, 
naliczanie kar za opóźnienia, kontrolę dostępności oraz generowanie krótkiego raportu.

Aby nie mieszać logiki z danymi i interfejsem rozdzieliłem program na części. 
Modele to obiekty. które przechowują dane o sobie np laptop, czy student. 
Serwis to logika całego programu. Tutaj m. in. dodawane są nowe wypożyczenia, 
kontrolowana jest dostępność  i generowane raporty. Program.cs służy jedynie do 
prezentacji logiki. Tworzę w nim nowych użytkowników, sprzęt i wywołuję metody z 
RentalService. Każda z klas w projekcie ma jedną odpowiedzialność, dzięki czemu 
łatwo jest go rozbudować lub edytować.

Przykładem wysokiej kohezji w moim projekcie jest m. in. rozdzielenie Rental (Modelu), 
który jest reprezentacją danych o wypożyczeniu i RentalService, który obsługuje wypożyczenia. 
Aby uniknąć mocnego sprzężenia klasa RentalService posiada swój własny interfejs IRentalService, 
a wyjątki zostały wydzielone poza klasę. Klasa Program.cs nie ingeruje w logikę systemu, tylko wywołuje 
pożądane operacje. Dziedziczenie użyłem tylko w niezbędnych miejscach. Klasy Laptop, Tablet, Headphones 
dziedziczą po Equipment, które przechowuje wspólne dane, a Student i Employee dziedziczą po User, 
nadpisując metodę GetMaxRentalLimit() służącą do przypisania limitów. Student ma limit 2, 
a pracownik 5 wypożyczeń.

Aby uruchomić program należy sklonować repozytorium i uruchomić je w Riderze. 
Konsola wyświetli przykładowe operacje.