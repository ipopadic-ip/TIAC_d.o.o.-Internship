package App;

public class TehnickiProizvod {
	private String marka;
	private String model;
	private Kategorija kategorija;
	private int cena;
	public TehnickiProizvod() {
		super();
		// TODO Auto-generated constructor stub
	}
	public TehnickiProizvod(String marka, String model, Kategorija kategorija, int cena) {
		super();
		this.marka = marka;
		this.model = model;
		this.kategorija = kategorija;
		this.cena = cena;
	}
	public String getMarka() {
		return marka;
	}
	public void setMarka(String marka) {
		this.marka = marka;
	}
	public String getModel() {
		return model;
	}
	public void setModel(String model) {
		this.model = model;
	}
	public Kategorija getKategorija() {
		return kategorija;
	}
	public void setKategorija(Kategorija kategorija) {
		this.kategorija = kategorija;
	}
	public int getCena() {
		return cena;
	}
	public void setCena(int cena) {
		this.cena = cena;
	}
	
	 public String toString() {
	        return "TehnickiProizvod{" +
	                "marka='" + marka + '\'' +
	                ", model='" + model + '\'' +
	                ", kategorija=" + kategorija +
	                ", cena=" + cena +
	                '}';
	    }
	 
}
