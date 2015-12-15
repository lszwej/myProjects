package pl.krakow.up.inf3;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.UnknownHostException;
import java.util.Scanner;

public class Client {
	private static final String PAGE_ENCODING = "UTF-8";
	private static final String ADRES = "localhost";
	private static final int PORT = 8080;

	public static void main(String[] args) {

		try {
			Socket s = new Socket(ADRES, PORT);
			Scanner czytnik = new Scanner(System.in);

			BufferedReader brs = new BufferedReader(new InputStreamReader(
					System.in));

			BufferedReader br = new BufferedReader(new InputStreamReader(
					s.getInputStream(), PAGE_ENCODING));
			PrintWriter pw = new PrintWriter(new OutputStreamWriter(
					s.getOutputStream(), PAGE_ENCODING));
			String komunikat = "";
			String odpowiedz = "";
			System.out.println("Po³¹czono z serwerem");

			do {
				komunikat = "";
				while ((komunikat.equals(".") == false)
						&& komunikat.equals("q") == false) {
					System.out.println("Wpisz komunikat do serwera");
					komunikat = brs.readLine();
					pw.println(komunikat);
					pw.flush();
				}

				odpowiedz = "";
				while (odpowiedz.equals(".") == false
						&& komunikat.equals("q") == false) {
					odpowiedz = br.readLine();
					System.out.println("Serwer odpowiedzia³\n" + odpowiedz);
				}
			} while (komunikat.equals("q") == false);

			br.close();
			pw.close();
			s.close();
			czytnik.close();
			System.out.println("Koniec po³¹czenia");
		}

		catch (UnknownHostException ex) {
			System.out.println("Z³y adres hosta");
		}

		catch (IOException ex) {
			System.out.println("Nie mo¿na po³¹czyæ siê z serwerem");
		}
	}

}
