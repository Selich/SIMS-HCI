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

- [ ] UseCase diagram (patient, secretary, director, doctor)
- [ ] Class diagram
- [ ] Medju tabela Lek , Oprema, Room
- [ ] Wireframe ( KLM )

## Pitanja za konsultacije

- [x] Koji specijalizacije doktora postoje?
- [x] Koje vrste zaposlenih postoje?
- [x] Koji zaposleni uvek moraju da budu na raspolaganju?
- [x] Da li sve specijalizacije moraju postojati u bolnici? Kako se zakazuje ako je potreban specijalista koji ne postoji u bolnici?
- [x] Specijalizovani doktori mogu izdavati dalje upute (snimanja npr.)?
- [x] Sta moze specijalista da radi? Da li opsta praksa moze jos nesto pored izdavanja uputa i zakazivanja operacija?
- [x] Razlika izmedju kartona i medicinske istorije?  
####  20.03.2020  
- [ ] Da li su fiksne duzine termina? Da li zaviste od vrste pregleda operacije? Da li sekretar moze da menja duzine termina?
- [ ] Slucaj ako pacijent izabere vise doktora za trazenje termina?
- [ ] Prioritet pacijenta; Termin ili lekar?
- [ ] Da li mi znambdevamo lekovima pacijente ili to radi neki treci cinioc u zdravstvenom sistemu (npr. tip entiteta apoteka )?
- [ ] Koliko magacina postoje?
- [ ] Da li pacijent moze da zakaze pregled samo kod izabranog lekara? Koja je uopste razlika izmedju izabranog lekara i bilo ko drugog?
- [ ] Ko ima pristup zdravstvenom kartonu konkretnog pacijenta?
####  22.03.2020  
- [ ] #33 Zar je zaista potrebno?
- [ ] #30 Da li se odobrava koriscenje operacionih sala od strane sekretara
- [ ] Ko sve koristi operacione sale
- [ ] #29 Lekovi iz naseg "Magacina" ili ne
- [ ] #23 Sta ako je veoma hitna operacija - Sekretar
- [ ] #22 Da li je potrebno da vidi sve pacijente i koje informacije ima PRAVO da vidi - Sekretar
- [ ] #18 Tokom renoviranja, da li mogu da se menja broj i vrste soba
- [ ] Duzina termina kod lekara, fiksna ili ne
- [ ] #6 CRUD za sve
- [ ] Koji sve izvestaji postoje (Magacin, Sobe, Lekovi, Oprema, Pacijenti)

