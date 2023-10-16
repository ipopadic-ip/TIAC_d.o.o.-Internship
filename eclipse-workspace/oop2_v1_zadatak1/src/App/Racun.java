package App;
import java.util.ArrayList;
import java.util.List;

public class Racun {
	private Prodavac prodavac;
	private List<TehnickiProizvod> proizvodi;
	
	public Racun(Prodavac prodavac) {
        this.prodavac = prodavac;
        this.proizvodi = new ArrayList<>();
    }
	// Dodaj proizvod na račun
    public void dodajProizvod(TehnickiProizvod proizvod) {
        proizvodi.add(proizvod);
    }
    public void dodajProizvode(List<TehnickiProizvod> proizvodi) {
        this.proizvodi.addAll(proizvodi);
    }


    // Metoda za izračunavanje ukupne cene svih proizvoda na računu
    public double cena() {
        double ukupnaCena = 0.0;
        for (TehnickiProizvod proizvod : proizvodi) {
            ukupnaCena += proizvod.getCena();
        }
        return ukupnaCena;
    }

    public Prodavac getProdavac() {
        return prodavac;
    }

    public void setProdavac(Prodavac prodavac) {
        this.prodavac = prodavac;
    }
    
    
    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("Račun prodavca: ").append(prodavac.getIme()).append("\n");
        sb.append("Proizvodi na računu:\n");
        for (TehnickiProizvod proizvod : proizvodi) {
            sb.append("- ").append(proizvod.getMarka()).append(": ").append(proizvod.getCena()).append(" dinara\n");
        }
        sb.append("Ukupna cena: ").append(cena()).append(" dinara");
        return sb.toString();
    }

}
