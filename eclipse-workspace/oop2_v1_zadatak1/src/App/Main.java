package App;
import java.util.ArrayList;
import java.util.List;

public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		 	Zaposleni zaposleni1 = new Zaposleni("123");
	        Zaposleni zaposleni2 = new Zaposleni("456");
	        Prodavac prodavac1 = new Prodavac("Ilija", "Pope");
	        Prodavnica prodavnica = new Prodavnica();

	        // Kreirajte tehničke proizvode
	        TehnickiProizvod proizvod1 = new TehnickiProizvod("Sony", "TV", new Kategorija("Elektronika", "EL"), 799);
	        TehnickiProizvod proizvod2 = new TehnickiProizvod("Samsung", "Laptop", new Kategorija("Računari", "RC"), 1299);

	        prodavnica.dodajProizvod(proizvod1);
	        prodavnica.dodajProizvod(proizvod2);
	        prodavnica.dodajZaposlenog(zaposleni1);
	        prodavnica.dodajZaposlenog(zaposleni2);
	        
	        // Kreirajte račune i dodajte proizvode na njih
	        Racun račun1 = new Racun(prodavac1);
	        račun1.dodajProizvod(proizvod1);
	        Racun račun2 = new Racun(prodavac1);
	        račun2.dodajProizvod(proizvod2);

	        // Kreirajte kolekciju zaposlenih, tehničkih proizvoda i računa
	        List<Zaposleni> zaposleniLista = new ArrayList<>();
	        zaposleniLista.add(zaposleni1);
	        zaposleniLista.add(zaposleni2);

	        List<TehnickiProizvod> proizvodiLista = new ArrayList<>();
	        proizvodiLista.add(proizvod1);
	        proizvodiLista.add(proizvod2);

	        List<Racun> računiLista = new ArrayList<>();
	        računiLista.add(račun1);
	        računiLista.add(račun2);

	        // Ispišite sadržaj kolekcija
	        System.out.println("Zaposleni:");
	        for (Zaposleni zaposleni : zaposleniLista) {
	            System.out.println(zaposleni);
	        }

	        System.out.println("\nTehnički proizvodi:");
	        for (TehnickiProizvod proizvod : proizvodiLista) {
	            System.out.println(proizvod);
	        }

	        System.out.println("\nRačuni:");
	        for (Racun račun : računiLista) {
	            System.out.println(račun);
	        }
	        prodavnica.ispisPodataka();
	}

}
