package pl.krakow.up.inf3;

import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.Reader;
import java.io.UnsupportedEncodingException;
import java.io.Writer;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.sql.Timestamp;
import java.util.Date;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Sqlite implements Runnable {

	public int liczbaLinkow2 = 0;
	
	@Override
	public void run() {

		do
		{
		try {
			// ustawiamy polaczenie do bazy danych
			Class.forName("org.sqlite.JDBC");
			Connection polaczenie = DriverManager
					.getConnection("jdbc:sqlite:c:/sql/database.db");
			Statement query = polaczenie.createStatement();
			FileOutputStream fos = new FileOutputStream("sqlite_stats.txt");
			OutputStreamWriter fsw = new OutputStreamWriter(fos);

			// zmienna przechowuje liczbe linkow do odwiedzenia
			int liczba = 0;

			// sprawdzamy czy w bazie sa jakies linki do odwiedzenia
			ResultSet wynik = query
					.executeQuery("SELECT count(*) as liczba from linki_do_odwiedzenia");
			if (wynik.next())
				liczba = wynik.getInt("liczba");

			// zmienne przechowuja adres linku oraz jego id
			String link = "";
			int id = 0;

			while (liczba != 0) {
				// pobranie pierwszego elementu z bazy
				wynik = query
						.executeQuery("SELECT id, adres from linki_do_odwiedzenia where data_dodania = (select min(data_dodania) from linki_do_odwiedzenia)");
				if (wynik.next()) {
					id = wynik.getInt("id");
					link = wynik.getString("adres");
				}

				// usuwanie pierwszego elementu z bazy
				PreparedStatement query2 = polaczenie
						.prepareStatement("DELETE from linki_do_odwiedzenia where id = ?");
				query2.setInt(1, id);
				query2.executeUpdate();
				
				// sprawdzenie czy w tablie istnieja juz takie same linki
				wynik = query
						.executeQuery("select adres from linki_do_odwiedzenia where adres = \'"
								+ link + "\'");
				if (wynik.next())
					continue;
				wynik.close();

				System.out.println("Odwiedzam link(Sqlite): " + link);
				++liczbaLinkow2;
				long start2 = System.nanoTime();
				// wstawiamy odwiedzony link do tabeli
				query2 = polaczenie
						.prepareStatement("INSERT INTO linki_odwiedzone (id,adres, data_odwiedzin) values(NULL,?,?)");
				query2.setString(1, link);
				query2.setTimestamp(2, new Timestamp(new Date().getTime()));
				query2.executeUpdate();
				long koniec2 = System.nanoTime();
				
				zapisz(fsw,
						"Silnik: org.sqlite.JDBC, wstawiony link do tabeli linki_odwiedzone: "
								+ link + ", czas operacji "
								+ (koniec2 - start2) + "\r\n");
				// pobieramy zawartosc strony WWW i wyszukujemy na niej linki
				URL u = new URL(link);
				
				HttpURLConnection conn = (HttpURLConnection)u.openConnection();
				if (conn.getResponseCode() == 401 || conn.getResponseCode() == 403 || conn.getResponseCode() == 404)
				{
					query2 = polaczenie.prepareStatement("delete from linki_do_odwiedzenia where id = (select min(id) from linki_do_odwiedzenia);");
					query2.executeUpdate();
					System.out.println("Usunieto blad " + conn.getResponseCode());
				
					// usuwanie pierwszego elementu z bazy
					query2 = polaczenie
							.prepareStatement("DELETE from linki_do_odwiedzenia where id = (select min(data_dodania) from linki_do_odwiedzenia);");
					query2.executeUpdate();
					
				}
				
				InputStream is = u.openStream();
				Reader r = new InputStreamReader(is, "UTF-8");
				String tresc = odczytaj(r);
				znajdzLinki(polaczenie, tresc, link, fsw);

				// sprawdzamy liczbe linkow do odwiedzenia, jezeli jest rowna
				// zero to koniec
				wynik = query
						.executeQuery("SELECT count(*) as liczba from linki_do_odwiedzenia");
				if (wynik.next())
					liczba = wynik.getInt("liczba");
				System.out.println("Aktualna liczba linków do odwiedzenia: "
						+ liczba);
			}

			polaczenie.close();
			fos.close();
			fsw.close();
			
		} catch (FileNotFoundException ex) {
		}

		catch (UnsupportedEncodingException ex) {
		}

		catch (MalformedURLException ex) {
			System.out.println("Malformed url");
		}

		catch (IOException ex) {
			System.out.println("B³¹d we/wy");
			continue;
			
		}

		catch (ClassNotFoundException ex) {
			System.out.println("Nie znaleziono sterownika do bazy");
		}

		catch (SQLException ex) {
			System.out.println("Wyjatek SQL " + ex);
		}
		}while (true);
	}

	private String odczytaj(Reader r) {
		int b = 0;
		StringBuilder result = new StringBuilder();
		try {
			while ((b = r.read()) != -1) {
				char c = (char) b;
				result.append(c);
			}
		} catch (IOException ex) {
			System.out.println("Problem z odczytem");
		}
		return result.toString();
	}

	private void zapisz(Writer w, String dane) {

		try {
			w.write(dane);
			w.flush();
		}

		catch (IOException ex) {
			System.out.println("Blad podczas zapisu do pliku");
		}
	}

	public void znajdzLinki(Connection polaczenie, String tresc,
			String adresStrony, Writer w) {
		Pattern p = Pattern.compile("a.+?href=\"(.+?)\"");

		Matcher m = p.matcher(tresc);// ([^>]+)
		while (m.find()) {
			String link = m.group(1);
			// wstawiamy do bazy linki bezwgledne
			if (link.startsWith("http://") || link.startsWith("https://")) {
				try {

					// jezeli dlugosc linku przekaracza 255 znakow, to
					// przycianmy go
					if (link.length() < 254) {
						
						long start2 = System.nanoTime();

						PreparedStatement query = polaczenie
								.prepareStatement("INSERT INTO linki_do_odwiedzenia (id,adres, data_dodania) values (NULL,?,?)");
						query.setString(1, link);
						query.setTimestamp(2,
								new Timestamp(new Date().getTime()));
						query.executeUpdate();
						query.close();
						long koniec2 = System.nanoTime();
						zapisz(w,
								"Silnik: org.sqlite.JDBC, wstawiony link do tabeli linki_odwiedzone: "
										+ link + ", czas operacji "
										+ (koniec2 - start2) + "\r\n");
					}
				}

				catch (SQLException ex) {
					System.out.println("Wyjatek SQL " + ex);
				}

			} else {
				if (link.startsWith("/")) {
					Pattern p2 = Pattern.compile("(https?://[^/]+)/");
					Matcher m2 = p2.matcher(adresStrony);
					if (m2.find()) {
						String poczatekAdresu = m2.group(1);
						String nowyAdres = poczatekAdresu + link;
						// wstawiamy do tabeli linki wzgledne
						try {

							// jezeli dlugosc linku przekaracza 255 znakow, to
							// przycianmy go
							if (nowyAdres.length() < 254) {
								
								long start2 = System.nanoTime();

								PreparedStatement query = polaczenie
										.prepareStatement("INSERT INTO linki_do_odwiedzenia (id,adres, data_dodania) values (NULL,?,?)");
								query.setString(1, nowyAdres);
								query.setTimestamp(2,
										new Timestamp(new Date().getTime()));
								query.executeUpdate();
								query.close();
								long koniec2 = System.nanoTime();
								zapisz(w,
										"Silnik: org.sqlite.JDBC wstawiony link do tabeli linki_odwiedzone: "
												+ link + ", czas operacji "
												+ (koniec2 - start2) + "\r\n");
							}
						}

						catch (SQLException ex) {
							System.out.println("Wyjatek SQL " + ex);
						}
					}
				}
			}
		}
	}

}
