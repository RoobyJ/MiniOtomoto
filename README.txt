# MiniOtomoto
MiniOtomoto to projekt do wyświetlania ogłoszeń z samochodami wraz z prostym panelem administracyjnym. Działa na Asp Net Core 5, Angular CLI 6.0.0 oraz Mysql 8.0.29
#Instalacja
Do uruchoemienia projektu potrzeba wszystkich paczek które są zapisane w "MiniOtomoto.csproj", dostosować ścieżkę do zdjęć w "CarController.cs" w wierszu 83
## Opis
Na stronie startowej wyświetlają się nam wszystkie ogłoszenia. Po kliknięciu w któreś przekierowuje nas do niego i wyświetla stronę z szczegółami.
Na górze jest pasek nawigacyjny gdzie mamy opcje przekierowania nas do home lub do rejestracji/logowania. Wstępnie każdy może się zarejestrować i zalogować i mieć
dostęp do panela administratora. Panel ten wygląda jak home ale ma opcję edycji i usuwania. Usuwanie polega na klinieciu i potwierdzeniu potem czy na pewno chcemy usunąć 
ten samochód. Edycja polega na tym że otwiera nam się dodatkowe okienko, w którym możemy wpisać inne dane i je zapisać po udanej edycji wyświetli się komunikat. że sie udało.
## Problemy
Po edycji albo usunięciu nie działa automatyczne odświeżenie danych trzeba ręcznie odświerzyc stronę.

## TODO
podzielić userów na admin i user, dać możliwość wyszukiwania po id, marce