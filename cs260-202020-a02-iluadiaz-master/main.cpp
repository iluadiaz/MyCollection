//----------------------------------------------------------
// CS260 Assignment 2 Starter Code
// Copyright Andrew Scholer (ascholer@chemeketa.edu)
// Neither this code, nor any works derived from it
//    may not be republished without approval.
//----------------------------------------------------------
#include <iostream>
//----------------------------------------------------------
// CS260 Assignment 2 Starter Code
// Copyright Andrew Scholer (ascholer@chemeketa.edu)
// Neither this code, nor any works derived from it
//    may not be republished without approval.
//----------------------------------------------------------
#include <iostream>
#include <ctime>

#include "Address.h"
#include "ArrayList.h"
#include "AddressArrayList.h"
#include "AddressLinkedList.h"

using namespace std;


int main()
{    int size = 0;
     cout << "Enter problem size:" << endl;
     cin >> size;

     ArrayList<Address> aListA;
     ArrayList<Address> aListB;

     AddressFactory aFactory("25000AddressesA.txt");
     AddressFactory aFactory2("25000AddressesB.txt");

     int countA = 0,countB = 0;

     for(int i = 0; i < size / 2; i++, countA++, countB++)
     {
         Address a = aFactory.getNext();
         aListA.insertEnd(a);
         Address a2 = aFactory2.getNext();
         aListB.insertEnd(a2);
     }

     const int TIMING_REPETITIIONS = 1000;
     double seconds;

     cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Part One~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
     cout << " count A is: " << countA << endl; cout << " count B is: " << countB <<endl;

     clock_t start = clock();

     aListA.combine(aListB);

     clock_t end = clock();

     seconds = static_cast<double>(end-start) / CLOCKS_PER_SEC;
     cout << endl;
     cout << "Combining the lists of size " << size << " took " << seconds << " seconds" << endl;
     cout <<endl;

     printListRange(aListA,size/2-2, size/2+1);

     cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Part Two~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;

     Address search;
     search.state = "OR";
     ArrayList<Address> aListC = aListA.extractAllMatches(search);

     int length;
     for(length = 0; length < aListA.listSize(); length++){}
     cout << "aListA has a length of: " << length << endl;
     cout << endl;
     for(length = 0; length < aListC.listSize(); length++){}
     cout << "aListC has a length of: " << length << endl;
     cout << endl;

     cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Part Three~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ " << endl;

     AddressLinkedList linkListA;
     AddressLinkedList linkListB;

     AddressFactory linkFactory("25000AddressesA.txt");
     AddressFactory linkFactory2("25000AddressesB.txt");

     for(int i = 0; i < size /2  ; i++)
     {
         Address link = linkFactory.getNext();
         linkListA.insertEnd(link);

         Address link2 = linkFactory2.getNext();
         linkListB.insertEnd(link2);
    }
    cout<<endl;
    cout<< "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Checking linkListA~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
    linkListA.printRange(2,4);
    cout<< "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Checking linkListB~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
    linkListB.printRange(2,4);

    cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Part Four~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ " << endl;

    AddressLinkedList linkListC;
    AddressLinkedList linkListD;


    linkListC = linkListA;
    linkListD = linkListB;
    linkListC.combine(linkListD);

          for(length = 0; length < linkListC.listSize(); length++){}
          cout << "linkedAlistC has a length of: " << length << endl;
          cout << endl;
          for(length = 0; length < linkListD.listSize(); length++){}
          cout << "linkListD has a length of: " << length << endl;
          cout << endl;

   linkListC.printRange(size/2-2,size/2+1);

   cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Part Five~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ " << endl;


   Address search2;
   search2.state = "OR";
   AddressLinkedList linkListE = linkListC.extractAllMatches(search2);

   linkListE.printRange(0,1);

   cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Part six~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ " << endl;


   linkListA.interleave(linkListB);
   linkListA.printRange(0,4);

   return 0;


}
