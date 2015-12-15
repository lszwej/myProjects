package pl.krakow.up.inf3;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Scanner;

public class Server {
	private static final String PAGE_ENCODING = "UTF-8";
	private static final int SERVER_PORT = 8080;

	public static void main(String[] args) {

		try {
			ServerSocket serverSocket = new ServerSocket(SERVER_PORT);
			Socket s = serverSocket.accept();
			BufferedReader br = new BufferedReader(new InputStreamReader(
					s.getInputStream(), PAGE_ENCODING));
			PrintWriter pw = new PrintWriter(new OutputStreamWriter(
					s.getOutputStream(), PAGE_ENCODING));
			Scanner czytnik = new Scanner(System.in);
			String komunikat = "";
			String odpowiedz = "";

			System.out.println("Po³¹czono z klientem");
			do {
				komunikat = "";
				while (komunikat.equals(".") == false
						&& komunikat.equals("q") == false) {
					komunikat = br.readLine();
					System.out.println("Klient przys³a³ wiadomoœæ");
					System.out.println(komunikat);
				}
				odpowiedz = "";
				while (odpowiedz.equals(".") == false
						&& komunikat.equals("q") == false) {
					System.out.println("Wpisz komunikat do klienta");
					odpowiedz = czytnik.nextLine();
					pw.println(odpowiedz);
					pw.flush();
				}
			} while (komunikat.equals("q") == false);

			br.close();
			pw.close();
			czytnik.close();
			s.close();
			serverSocket.close();
			System.out.println("Koniec po³¹czenia");

		} catch (IOException ex) {
			System.out.println("Nie mo¿na siê po³¹czyæ z klientem");

		}
	}
}