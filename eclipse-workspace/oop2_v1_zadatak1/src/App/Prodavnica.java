package App;

import java.util.ArrayList;
import java.util.List;

public class Prodavnica {
    private List<TehnickiProizvod> dostupniProizvodi;
    private List<Zaposleni> zaposleni;

    public Prodavnica() {
        dostupniProizvodi = new ArrayList<>();
        zaposleni = new ArrayList<>();
    }

    // Dodaj proizvod u dostupne proizvode
    public void dodajProizvod(TehnickiProizvod proizvod) {
        dostupniProizvodi.add(proizvod);
    }

    // Ukloni proizvod iz dostupnih proizvoda
    public void ukloniProizvod(TehnickiProizvod proizvod) {
        dostupniProizvodi.remove(proizvod);
    }

    // Dodaj zaposlenog u prodavnicu
    public void dodajZaposlenog(Zaposleni zaposlen) {
        zaposleni.add(zaposlen);
    }

    // Ukloni zaposlenog iz prodavnice
    public void ukloniZaposlenog(Zaposleni zaposlen) {
        zaposleni.remove(zaposlen);
    }

    // Kreiraj račun sa zadatim prodavcem i listom proizvoda iz prodavnice
    public Racun kreirajRačun(Prodavac prodavac, List<TehnickiProizvod> proizvodi) {
        Racun račun = new Racun(prodavac);
        račun.dodajProizvode(proizvodi);
        return račun;
    }

    // Ispis svih podataka o prodavnici
    public void ispisPodataka() {
        System.out.println("Dostupni proizvodi:");
        for (TehnickiProizvod proizvod : dostupniProizvodi) {
            System.out.println(proizvod);
        }

        System.out.println("Zaposleni:");
        for (Zaposleni zaposlen : zaposleni) {
            System.out.println(zaposlen);
        }
    }
}

