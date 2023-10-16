package App;

public class Sporet {
	private int brojRingli;
	private boolean imaRernu;
	private String boja;
	private double duzina;
	private double sirina;
	private double visina;
	public Sporet() {
		super();
		// TODO Auto-generated constructor stub
	}
	public Sporet(int brojRingli, boolean imaRernu, String boja, double duzina, double sirina, double visina) {
		super();
		this.brojRingli = brojRingli;
		this.imaRernu = imaRernu;
		this.boja = boja;
		this.duzina = duzina;
		this.sirina = sirina;
		this.visina = visina;
	}
	public int getBrojRingli() {
		return brojRingli;
	}
	public void setBrojRingli(int brojRingli) {
		this.brojRingli = brojRingli;
	}
	public boolean isImaRernu() {
		return imaRernu;
	}
	public void setImaRernu(boolean imaRernu) {
		this.imaRernu = imaRernu;
	}
	public String getBoja() {
		return boja;
	}
	public void setBoja(String boja) {
		this.boja = boja;
	}
	public double getDuzina() {
		return duzina;
	}
	public void setDuzina(double duzina) {
		this.duzina = duzina;
	}
	public double getSirina() {
		return sirina;
	}
	public void setSirina(double sirina) {
		this.sirina = sirina;
	}
	public double getVisina() {
		return visina;
	}
	public void setVisina(double visina) {
		this.visina = visina;
	}
	public String toString() {
        return "Sporet{" +
                "brojRingli=" + brojRingli +
                ", imaRernu=" + imaRernu +
                ", boja='" + boja + '\'' +
                ", duzina=" + duzina +
                ", sirina=" + sirina +
                ", visina=" + visina +
                '}';
    }
}
