package App;

public class Zaposleni extends Osoba {
	private String sifraZaposlenog;

	public Zaposleni() {
		super();
		// TODO Auto-generated constructor stub
	}

	public Zaposleni(String sifraZaposlenog) {
		super();
		this.sifraZaposlenog = sifraZaposlenog;
	}

	public String getSifraZaposlenog() {
		return sifraZaposlenog;
	}

	public void setSifraZaposlenog(String sifraZaposlenog) {
		this.sifraZaposlenog = sifraZaposlenog;
	}
	 @Override
	    public String toString() {
		 return "Zaposleni{" +
	                " šifraZaposlenog='" + sifraZaposlenog + '\'' +
	                '}';
	    }
}
