package pl.krakow.up.inf3;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.Reader;
import java.io.UnsupportedEncodingException;
import java.net.MalformedURLException;
import java.net.URL;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.Date;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.sql.Timestamp;

public class Robot1 {

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

	public void znajdzLinki(Connection polaczenie, String tresc,
			String adresStrony) {
		Pattern p = Pattern.compile("a.+?href=\"(.+?)\"");

		Matcher m = p.matcher(tresc);// ([^>]+)
		while (m.find()) {
			String link = m.group(1);
			// wstawiamy do bazy linki bezwgledne
			if (link.startsWith("http://") || link.startsWith("https://")) {
				try {
					
					// jezeli dlugosc linku przekaracza 255 znakow, to przycianmy go
					if (link.length() > 255)
					{
						PreparedStatement query = polaczenie
							.prepareStatement("INSERT INTO linki_do_odwiedzenia (adres, data_dodania) values (?,?)");
						query.setString(1, link.substring(0, 255));
						query.setTimestamp(2, new Timestamp(new Date().getTime()));
						query.executeUpdate();
						query.close();
					}
					else
					{
						PreparedStatement query = polaczenie
								.prepareStatement("INSERT INTO linki_do_odwiedzenia (adres, data_dodania) values (?,?)");
						query.setString(1, link);
						query.setTimestamp(2, new Timestamp(new Date().getTime()));
						query.executeUpdate();
						query.close();
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
							
							//jezeli dlugosc linku przekaracza 255 znakow, to przycianmy go
							if (nowyAdres.length() > 255)
							{
								PreparedStatement query = polaczenie
										.prepareStatement("INSERT INTO linki_do_odwiedzenia (adres, data_dodania) values (?,?)");
								query.setString(1, nowyAdres.substring(0, 255));
								query.setTimestamp(2,
										new Timestamp(new Date().getTime()));
								query.executeUpdate();
								query.close();
							}
							else
							{
								PreparedStatement query = polaczenie
										.prepareStatement("INSERT INTO linki_do_odwiedzenia (adres, data_dodania) values (?,?)");
								query.setString(1, nowyAdres);
								query.setTimestamp(2,
										new Timestamp(new Date().getTime()));
								query.executeUpdate();
								query.close();
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

	public static void main(String[] args) {
		Robot1 robot = new Robot1();

		try {
			// ustawiamy polaczenie do bazy danych
			Class.forName("org.h2.Driver");
			Connection polaczenie = DriverManager.getConnection(
					"jdbc:h2:tcp://localhost/~/test", "sa", "admin");
			Statement query = polaczenie.createStatement();
			
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
				wynik = query.executeQuery("select adres from linki_do_odwiedzenia where adres = \'" + link + "\'");
				if (wynik.next())
					continue;
				wynik.close();
				
				System.out.println("Odwiedzam link: " + link);
				// wstawiamy odwiedzony link do tabeli
				query2 = polaczenie
						.prepareStatement("INSERT INTO linki_odwiedzone (adres, data_odwiedzin) values(?,?)");
				query2.setString(1, link);
				query2.setTimestamp(2, new Timestamp(new Date().getTime()));
				query2.executeUpdate();

				// pobieramy zawartosc strony WWW i wyszukujemy na niej linki
				URL u = new URL(link);
				InputStream is = u.openStream();
				Reader r = new InputStreamReader(is, "UTF-8");
				String tresc = robot.odczytaj(r);
				robot.znajdzLinki(polaczenie, tresc, link);

				// sprawdzamy liczbe linkow do odwiedzenia, jezeli jest rowna zero to koniec
				wynik = query
						.executeQuery("SELECT count(*) as liczba from linki_do_odwiedzenia");
				if (wynik.next())
					liczba = wynik.getInt("liczba");
				System.out.println("Aktualna liczba linków do odwiedzenia: " + liczba);
			}
			
			polaczenie.close();
		} catch (FileNotFoundException ex) {
		}

		catch (UnsupportedEncodingException ex) {
		}

		catch (MalformedURLException ex) {
			System.out.println("Malformed url");
		}

		catch (IOException ex) {
			System.out.println("B³¹d we/wy");
		}

		catch (ClassNotFoundException ex) {
			System.out.println("Nie znaleziono sterownika do bazy");
		}

		catch (SQLException ex) {
			System.out.println("Wyjatek SQL " + ex);
		}
	}

}
