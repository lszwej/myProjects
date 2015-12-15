# -*- coding: utf-8 -*-
import gracze
import druki
import random

class Gra:

    def __init__(self, postac):
        self.__smierc = False
        self.postac = postac

    def czy_smierc(self):
        return self.__smierc

    def samobojstwo(self):
        print("Popełniłeś samobójstwo!")
        print("Koniec gry!")
        self.__smierc = True

    def macarena(self):
        print("Heeeeey Macarena AAAhAA!")
        print("")

    def ucieczka(self):
        print("Uciekasz z niczym!")
        print("Koniec gry!")
        self.__smierc = True

    def przegrana(self):
        print("Niestety, ale przeciwnik Cię pokonał!")
        print("Koniec gry!")
        self.__smierc = True

    def czy_super_atak(self):
        print("Szansa na super atak!")
        print("")
        return random.randint(0,100) > 50


    def walka(self, klasa_rywal):

        rywal = None
        if klasa_rywal == "Troll":
            hp_rywal = random.randint(1,75)
            atak_rywal = random.randint(1,20)
            rywal = gracze.Troll(hp_rywal, atak_rywal, klasa_rywal)
        elif klasa_rywal == "Ork":
            hp_rywal = random.randint(1,100)
            atak_rywal = random.randint(1,20)
            rywal = gracze.Ork(hp_rywal, atak_rywal, klasa_rywal)

        rywal.__str__()
        i = 0
        while True:
            if i%3 == 0 and self.czy_super_atak():
                    postac.super_atak(rywal)
            else:
                postac.atakuj(rywal)
            postac.__str__()
            if (rywal.get_hp() < 1):
                print("Gratulacje! Pokonałeś {0}".format(rywal.klasa))
                return True
            if i%3 == 0 and self.czy_super_atak():
                    rywal.super_atak(postac)
            else:
                rywal.atakuj(postac)
            rywal.__str__()
            i += 1
            if (postac.get_hp() < 1):
                return  False

    def intro(self):
        postac.__str__()
        choice = 0
        while choice > 4 or choice < 1:
            try:
                druki.print_intro()
                choice = int(input(">>>  "))
                print("")
                if choice == 1:
                    self.macarena()
                elif choice == 2:
                    print("Otwierasz drzwi i wchodzisz do nastepnego pomieszczenia...")
                    self.room1()
                elif choice == 3:
                    print("Otwierasz drzwi...Przechodzisz do nastepnego pomieszczenia...")
                    print("Trujący gaz rozprzestrzenia się po pomieszczeniu. Dusi Cię w mgnieniu oka i umierasz.")
                    print("Koniec gry!")
                    self.__smierc = True
                    break
                elif choice == 4:
                    self.samobojstwo()
                    break
                else:
                    print("Wpisałeś złą opcję")

            except ValueError:
                print("Wpisana wartosc nie jest liczbą!")

    def room1(self):

        postac.__str__()
        choice = 0
        while choice > 4 or choice < 1:
            try:
                druki.print_room1()
                choice = int(input(">>>  "))
                print("")
                if choice == 1:
                    print("Walka rozpoczęta!")
                    print("")

                    if self.walka(gracze.Troll.__name__):
                        self.room1v2()
                    else:
                        self.przegrana()
                        break
                elif choice == 2:
                    self.ucieczka()
                    break
                elif choice == 3:
                    self.samobojstwo()
                    break
                elif choice == 4:
                    self.macarena()
                    print("Troll nie jest zachwycony... Zabija Cię gdy tańczysz.")
                    print("Koniec gry!")
                    self.__smierc = True
                    break
                else:
                    print("Podałeś złą opcję!")
            except ValueError:
                print("Wpisana wartość nie jest liczbą!")

    def room1v2(self):
        postac.__str__()
        choice = 0
        while choice > 3 or choice < 1:
            try:
                druki.print_room1v2()
                choice = int(input(">>>  "))
                print("")
                if choice == 1:
                    print("Przechodzisz przez lewe drzwi.")
                    self.room2()
                elif choice == 2:
                    print("Przechodzisz przez prawe drzwi.")
                    print("Pojawiasz się w pierwszym pomieszczeniu!")
                    self.intro()
                elif choice == 3:
                    self.samobojstwo()
                    break
                else:
                    print("Podałeś złą odpowiedź!")

            except ValueError:
                print("Wpisana wartość nie jest liczbą!")

    def room2(self):
        postac.__str__()
        choice = 0
        while choice > 3 or choice < 1:
            try:
                druki.print_room2()
                choice = int(input(">>>  "))
                print("")
                if choice == 1:
                    print("Przechodzisz przez lewe drzwi. Spadasz w przepaść.")
                    print("Koniec gry!")
                    self.__smierc = True
                    break
                elif choice == 2:
                    print("Przechodzisz przez prawe drzwi.")
                    print("Pojawiasz się w pierwszym pomieszczeniu!")
                    self.intro()
                elif choice == 3:
                    print("Podchodząc do skrzyni zauważasz, że znikąd za Twoimi plecami pojawił się Ork.")
                    self.room2v2()
                else:
                    print("Podałeś złą odpcję!")

            except ValueError:
                print("Wpisana wartość nie jest liczbą!")

    def room2v2(self):

        postac.__str__()
        choice = 0
        while choice > 4 or choice < 1:
            try:
                druki.print_room2v2()
                choice = int(input(">>>  "))
                print("")
                if choice == 1:
                    print("Walka rozpoczęta!")
                    print("")
                    if self.walka(gracze.Ork.__name__):
                        self.skarb()
                    else:
                        self.przegrana()
                        break
                elif choice == 2:
                    self.ucieczka()
                    break
                elif choice == 3:
                    self.samobojstwo()
                    break
                elif choice == 4:
                    self.macarena()
                    print("Ork bez wachania miażdży Cie gdy tańczysz.")
                    print("Koniec gry!")
                    self.__smierc = True
                    break
                else:
                    print("Podałeś złą odpowiedź!")

            except ValueError:
                print("Wpisana wartość nie jest liczbą!")

    def skarb(self):
        print("Gratulacje! Zdobyłeś skarb Orków!")
        print("Możesz teraz bezpiecznie wrócić skąd przyszedłeś!")
        self.__smierc = True

print("Witaj w dziwnej grze!")
print("")
prompt = ""
while prompt.lower() != "start":
    prompt = input("Wpisz start, aby rozpocząć  ")

hp = 100
atak = 20
klasa = input("Wpisz klasę postaci  ")
postac = gracze.Postac(hp, atak, klasa)
gra = Gra(postac)
while not gra.czy_smierc():
    gra.intro()