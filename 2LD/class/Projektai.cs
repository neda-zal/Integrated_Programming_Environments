using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
public class Projektai
{
    private String ProjPavadinimas;
    private String VadPavarde;
    private int ZmSk;
    private double biudzetas;
    private int trukme;

    public Projektai() {}

    public Projektai(String ProjPavadinimas, String VadPavarde, int ZmSk, double biudzetas, int trukme) {
        this.ProjPavadinimas = ProjPavadinimas;
        this.VadPavarde = VadPavarde;
        this.ZmSk = ZmSk;
        this.biudzetas = biudzetas;
        this.trukme = trukme;
    }

	public String getProjPavadinimas() {
		return this.ProjPavadinimas;
	}

	public void setProjPavadinimas(String ProjPavadinimas) {
		this.ProjPavadinimas = ProjPavadinimas;
	}

	public String getVadPavarde() {
		return this.VadPavarde;
	}

	public void setVadPavarde(String VadPavarde) {
		this.VadPavarde = VadPavarde;
	}

	public int getZmSk() {
		return this.ZmSk;
	}

	public void setZmSk(int ZmSk) {
		this.ZmSk = ZmSk;
	}

	public double getBiudzetas() {
		return this.biudzetas;
	}

	public void setBiudzetas(double biudzetas) {
		this.biudzetas = biudzetas;
	}

	public int getTrukme() {
		return this.trukme;
	}

	public void setTrukme(int trukme) {
		this.trukme = trukme;
	}

    public static double VidProjBiudzetas(List<Projektai> projektai) {
        double tmp = 0;
        foreach(var item in projektai) {
            tmp += item.getBiudzetas();
        }
        return tmp / projektai.Count;
    }

    public static List<Projektai> Filtravimas(List<Projektai> projektai, String VadPavarde) {
        List<Projektai> results = new List<Projektai>();
        foreach(Projektai proj in projektai) {
            if(proj.getVadPavarde().Contains(VadPavarde)) {
                results.Add(proj);
            }
        }
        return results;
    }

    public static List<Projektai> Filtravimas(List<Projektai> projektai, String ProjPavadinimas, double biudzetas, int trukme) {
        List <Projektai> results = new List<Projektai> {};
        foreach(Projektai proj in projektai) {
            if(proj.getProjPavadinimas().Contains(ProjPavadinimas) && proj.getBiudzetas().Equals(biudzetas)
            && proj.getTrukme().Equals(trukme)) {
                results.Add(proj);
            }
        }
        return results;
    }

    public static void CsvSaugojimas(List<Projektai> projektai, string failoVardas) {
        // failą duomenis saugoti sukursime dabartiniame foldery
        var csv = new StringBuilder();
        foreach(Projektai proj in projektai) {
            var newline = string.Format("{0},{1},{2},{3},{4}", proj.getProjPavadinimas(), proj.getVadPavarde(),
            proj.getZmSk(), proj.getBiudzetas(), proj.getTrukme());
            csv.AppendLine(newline);  
        }
        File.WriteAllText(failoVardas + ".csv", csv.ToString());
    }
}