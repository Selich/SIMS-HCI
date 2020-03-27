## Styleguide

Za pisanje C# koda, koristicemo Microsoft style guide.
Vise informacija mozete videti ovde: [style guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions).

## Testiranje

Praticemo Microsoft guide za TDD. Vise informacija mozete videti [ovde](https://docs.microsoft.com/en-us/visualstudio/test/quick-start-test-driven-development-with-test-explorer?view=vs-2019)

## Git style guide

Za stvaranje novih branch-ova koristimo npr. za user story: "Add ability to login" i servis "Director"

```bash
    git commit -m "Add ability to login"
    git commit -m <USER-STORY>
```
  
```bash
    git checkout -b add-login-feature/director
    git checkout -b <GLAGOL>-<KEYWORD>-feature/<ROLE>
```
  
Branch za poseban servis npr. "Patient" bice:
  
```bash
    git checkout -b patient
```

## TODO

- [ ] Use case dijagram za uloge 
- [ ] Extend za specijaliste
- [ ] Registrovan/neregistrovan pacijent 
- [ ] Wireframe ( KLM )
- [ ] Class diagram
- [ ] Medju tabela Lek , Oprema, Room

## Pitanja za konsultacije

- [ ] Nikola - Da li Upravnik moze da menja duzine termina?
- [ ] Uros   - Da li su fiksne duzine termina? 
- [ ] Filip  - Zajednicki Use Case za slanje zahteva?
- [ ] Dusan  - Da li se lekovi nalaze u magacinu?
- [ ] Dusan  - Da li se vodi evidencija lekova na nivou sobe?
- [ ] Dusan  - Da li mi znambdevamo lekovima pacijente ili to radi neki treci cinioc u zdravstvenom sistemu (npr. tip entiteta apoteka )?
- [ ] Dusan  - #30 Da li se odobrava koriscenje operacionih sala od strane sekretara
-- Hirurzi
- [ ] Dusan  - #29 Lekovi iz naseg "Magacina" ili ne
- [ ] Dusan  - #23 Sta ako je veoma hitna operacija - Sekretar ili jos neko osim njega
- [ ] Dusan  - Koji sve izvestaji postoje (Magacin, Sobe, Lekovi, Oprema, Pacijenti)
-- Sobama,Pacijentima,Lekarima...
- [ ] Dusan  - Duzina termina kod lekara, fiksna ili ne
- [ ] Dusan  - Da li izdvojiti pretrage kao use casove
- [ ] Dusan  - Tok nabavke?
- [ ] Dusan  - Evidencija novog/postojeceg leka?
- [ ] Dusan  - Pacijent ima pristup sopstvenoj istoriji lecenja?
- [ ] Dusan  - Da li lekar moze da izda recept za apoteku?
- [ ] Dusan  - Doktor ima uvid svih poslanih zahteva sa njegove strane?
- [ ] Dusan  - Doktor zahteva lekove/opremu?
- [ ] Dusan  - Kako odredjujemo kompatibilnost sobe sa lekarom i opremom?
- [ ] Dusan  - Kako se zapisiju alternativni tokovi ako imam extends/include use cases?

## Odgovori

- [x] Koji specijalizacije doktora postoje?
- [x] Koje vrste zaposlenih postoje?
- [x] Koji zaposleni uvek moraju da budu na raspolaganju?
- [x] Da li sve specijalizacije moraju postojati u bolnici? Kako se zakazuje ako je potreban specijalista koji ne postoji u bolnici?
- [x] Specijalizovani doktori mogu izdavati dalje upute (snimanja npr.)?
- [x] Sta moze specijalista da radi? Da li opsta praksa moze jos nesto pored izdavanja uputa i zakazivanja operacija?
- [x] Razlika izmedju kartona i medicinske istorije?  
- [x] Soba ima neophodne iteme?
- Da. Lekovi se gledaju globalno 
- [x] Prioritet pacijenta; Termin ili lekar?
- Bira izmedju prioriteta
- [x] Slucaj ako pacijent izabere vise doktora za trazenje termina?
- Bira izmedju prioriteta
- [x] Da li pacijent moze da zakaze pregled samo kod izabranog lekara? Koja je uopste razlika izmedju izabranog lekara i bilo ko drugog?
- Ne postoji izabran lekar
- [x] Ko ima pristup zdravstvenom kartonu konkretnog pacijenta?
- Svako ko je vrsio pregled lekara i zadao dijagnozu ili operaciju
- [x] #33 Zar je zaista potrebno?
- Jeste
- [x] Ko sve koristi operacione sale
- [x] #22 Da li je potrebno da vidi sve pacijente i koje informacije ima PRAVO da vidi - Sekretar i Upravnik
- Moze
- [x] #18 Tokom renoviranja, da li mogu da se menja broj i vrste soba
- Moze, pregradjivanje i rusenje
- [x] #6 CRUD za sve zaposlene
- Da
- [x] Da li da omogucimo lekarima da isprave opis leka?
- Moze ali ne mora
- [x] Da li Upravnik moze da prebaci lekove i opreme iz jedne sobe u drugu, ili mora preko Magacina
- Ne moze iz jedne sobe u drugu
- [x] Da li postoji ogranicenje na to gde oprema i lekovi mogu da budu?
- Samo neophodna oprema za datu vrstu sobe moze da postoji u njoj
