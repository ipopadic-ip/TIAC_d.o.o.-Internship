package App;

public class Osoba {
	private String ime;
	private String prezime;	
	public Osoba() {
		super();
		// TODO Auto-generated constructor stub
	}
	public Osoba(String ime, String prezime) {
		super();
		this.ime = ime;
		this.prezime = prezime;
	}
	public String getIme() {
		return ime;
	}
	public void setIme(String ime) {
		this.ime = ime;
	}
	public String getPrezime() {
		return prezime;
	}
	public void setPrezime(String prezime) {
		this.prezime = prezime;
	}	
	 @Override
	 public String toString() {
	        return "Osoba{" +
	                "ime='" + ime + '\'' +
	                ", prezime='" + prezime + '\'' +
	                '}';
	    }
}
