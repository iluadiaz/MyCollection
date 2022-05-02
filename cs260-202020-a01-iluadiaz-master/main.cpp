#include <iostream>
#include <fstream>
#include <sstream>
#include <cstring>
#include <algorithm>
#include "Person.h"
#include <ctime>

using namespace std;

int main()
{
    int temp = 0;
    int size = 0;
    cout << "Input the number represnting the amount of records you wish to work with" << endl;
    cin >> size;

    Person* persons = new Person[100000];
    Person* personsSorted = new Person[100000];

    string data;
    string zip ;

    ifstream in("people.txt");
    if(in.fail()) {
        cout << "Error check code" <<endl;
        exit(1);
    }
    if(!in.eof() )
    {
        for(int i = 0; i < size; i++)
        {
            getline(in, persons[i].kNum, ',');
            personsSorted[i].kNum = persons[i].kNum;
            getline(in, persons[i].last, ',');
            personsSorted[i].last = persons[i].last;
            getline(in, persons[i].first, ',');
            personsSorted[i].first = persons[i].first;

            in >> zip;

            persons[i].zipCode = stoi(zip);
            personsSorted[i].zipCode = persons[i].zipCode;

        }
        std::sort(personsSorted, personsSorted + size);
        cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Section One~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
        cout << "The last person on your list is: "<< persons[size-1].first << ", " << persons[size-1].last << endl;

        const int TIMING_REPETITIIONS = 10000;
        double seconds;
        clock_t start = clock();

        for(int i = 0; i < TIMING_REPETITIIONS; i++)
        {
            temp = countLastName("Mertz", persons, size);
        }

        cout << "\n" << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Section Two~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
        cout << "There are "<< temp <<" entries for the requested name." << endl;

        clock_t end = clock();

        seconds = static_cast<double>(end-start) / CLOCKS_PER_SEC;
        cout << "Counting the last names for size " << size << " took " << seconds << " seconds" << endl;

        cout << "\n" << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Section Three~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
        cout << "Sorted binary array index location test for Abbott's first occurence: "<< binaryFindFirstByLastName("Abbott", personsSorted, size) << endl;
        cout << "Sorted binary array index location test for Zulauf's first occurence: "<< binaryFindFirstByLastName("Zulauf", personsSorted, size) << endl;
        cout << "Sorted binary array index location test for Abbott's last occurence "<< binaryFindLastByLastName("Abbott", personsSorted, size) << endl;
        cout << "Sorted binary array index location test for Zulauf's last occurence "<< binaryFindLastByLastName("Zulauf", personsSorted, size) << endl;

        clock_t begin = clock();

        for(int j = 0; j < TIMING_REPETITIIONS; j++)
        {
            temp = countLastNameInSorted("Mertz",personsSorted,size);
        }

        clock_t finish = clock();
        seconds = static_cast<double>(finish-begin) / CLOCKS_PER_SEC;
        cout << "\n" << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Section Four~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
        cout << "Counting the last names in sorted for size "<< size << " took " << seconds << " seconds." << endl;

        cout << "\n" << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Section Five~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
        partialZipSort(persons,0,9);

        clock_t initiated = clock();

        cout << "\n" << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Section Six~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
        nameSort(persons, size);

        clock_t stopped = clock();
        seconds = static_cast<double>(stopped-initiated) / CLOCKS_PER_SEC;
        cout << "Funtion nameSort time taken for size "<< size << " took " << seconds << " seconds." << endl;

    }
    cout << endl;
    cout << "All done!" << endl;
    delete [] persons;
    delete [] personsSorted;
}
