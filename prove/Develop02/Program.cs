using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new(); //HOLY CRAP IM UNDERSTANDING IT!! This makes the Journal Object se llama my Journal
        myJournal.Initialize(); // this initializes it

        Menu mainMenu = new Menu(); //this creates the menu object
        mainMenu.mainMenu(myJournal); // and this setup this way allows us to PASS IT INTO THE MENU.CS file!

        // write out menu and call Journal


        //constructors and override method
    }
}