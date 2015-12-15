# -*- coding: utf-8 -*-
import random

class Postac:

    def __init__(self, hp, atak, klasa = "nieokreślono"):

        if klasa.lower() == "mag":
            hp += 20
            atak -= 10
        elif klasa.lower() == "wojownik":
            atak += 10
        elif klasa.lower() == "strzelec":
            atak += 5
            hp += 5
        self.hp = hp
        self.atak = atak
        self.klasa = klasa

    def get_hp(self):
        return self.hp

    def get_atak(self):
        return  self.atak

    def get_klasa(self):
        return self.klasa

    def atakuj(self, rywal):

        print("Atak wykonuje {0}. Jego przeciwnik stracił {1:d} hp".format(self.klasa, self.atak))
        rywal.hp -= self.atak

    def super_atak(self, rywal):
        print("Super atak wykonuje {0}. przeciwnik stracił {1:d} hp".format(self.klasa, self.atak*2))
        rywal.hp -= self.atak*2

    def __str__(self):
        print ("Klasa: {0}, HP: {1:d}, Atak: {2:d}".format(self.klasa, self.hp, self.atak))


class Troll(Postac):

    def __init__(self,hp, atak, klasa):
        super(Troll,self).__init__(hp, atak, klasa)
        self.__obrona = random.randint(0,20)
        self.hp += self.__obrona

    def __str__(self):
        super(Troll, self).__str__()
        print("Obrona zwiekszająca ilość hp {0:d}".format(self.__obrona))


class Ork(Postac):

    def __init__(self, hp, atak, klasa):
        super(Ork, self).__init__(hp, atak, klasa)
        self.__sila = random.randint(0,15)
        self.atak += self.__sila

    def __str__(self):
        super(Ork, self).__str__()
        print("Siła zwiekszająca moc ataku {0:d}".format(self.__sila))