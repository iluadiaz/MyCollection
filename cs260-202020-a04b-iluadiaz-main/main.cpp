//----------------------------------------------------------
// CS260 Assignment Starter Code
// Copyright Andrew Scholer (ascholer@chemeketa.edu)
// Neither this code, nor any works derived from it
//    may not be republished without approval.
//----------------------------------------------------------
#include <iostream>
#include <sstream>
#include <iomanip>
#include <vector>
#include <fstream>

#include "MySet.h"

using namespace std;

//Returns a vector containing all valid IP addresses starting with 192.168
vector<string> getLocalIPs() {
    vector<string> localIPs;
    localIPs.reserve(256 * 256);		//reserve space in advance to minimize grows

    char ip[] = "192.166.XXX.XXX";
    for(int i = 0; i < 256; i++) {
        for(int j = 0; j < 256; j++) {
            sprintf(ip, "192.168.%03d.%03d", i, j);
            localIPs.push_back(ip);
        }
    }

    return localIPs;
}


int main()
{
    int size;
    cin >> size;
    string ipAddresses;

    stringstream stream;
    vector<string> vectorA;
    vectorA = getLocalIPs();

    int count = 0;
    MySet<string> setA; //= new MySet<string>;

    ifstream inFile("IPListA.txt");
    if( !inFile.is_open() )
    {
        cout << "Error opening file" << endl;
        return 1;
    }

//    clock_t start = clock();
//    const int TIMING_REPETITIIONS = 100000;

    while(!inFile.eof() && count < size)
    {
        inFile >> ipAddresses;
        setA.add(ipAddresses);
        count++;
    }

    //clock_t end = clock();

    cout << "~~~~~~~~~~~~~~~~~~~~Part One~~~~~~~~~~~~~~~~~~~~~~" << endl;
    cout <<"There are a total of " << setA.size() << " unique IP addresses in this list" << endl;
    cout << endl;
    cout << "The binary tree has a depth of "<< setA.depth() << endl;
    cout << endl;
//    cout << "Run performed in " << static_cast<double>(end - start) / CLOCKS_PER_SEC / TIMING_REPETITIIONS
//         << " seconds" << endl;

   //start = clock();

//   for(int i = 0; i < TIMING_REPETITIIONS; i++)
//   {
//   setA->getSmallest();
//   }

   //end = clock();

    cout << "~~~~~~~~~~~~~~~~~~~~Part Two~~~~~~~~~~~~~~~~~~~~~~" << endl;
    cout << "The smallest value in this tree is : " << setA.getSmallest() << endl;
    cout << endl;

//    cout << "Run performed in " << static_cast<double>(end - start) / CLOCKS_PER_SEC / TIMING_REPETITIIONS
//         << " seconds" << endl;


    MySet<string>* set2A = new MySet<string>(setA);// = setA;

    cout << "~~~~~~~~~~~~~~~~~~~~Part Three~~~~~~~~~~~~~~~~~~~~" << endl;
    cout <<"There are a total of " << set2A->size() << " unique IP addresses in Set2A list" << endl;
    cout << endl;

    cout << "The smallest value in this tree is " << set2A->getSmallest() << endl;
    cout << endl;

    for(int i = 0; i <  10; i++)
    {
        cout << "The value removed is " << set2A->getLargest() << endl;
        set2A->removeLargest();

    }
    cout << endl;
    cout << "There is now a total of  " << set2A->size() << " unique addresses in this Set2A." <<endl;
    cout << endl;

    MySet<string>* set3A = new MySet<string>(setA);

    cout << "~~~~~~~~~~~~~~~~~~~~Part Four~~~~~~~~~~~~~~~~~~~~~" << endl;

    for(unsigned int i = 0; i < vectorA.size(); i++)
    {
        set3A->remove(vectorA[i]);
    }
    cout << "The amount of unique records in set3A after removing local Ip addresses is " << set3A->size() << endl;
    cout << endl;
    cout << "~~~~~~~~~~~~~~~~~~~~Part Five~~~~~~~~~~~~~~~~~~~~~" << endl;
    vector<string> vectorB;

    //    vectorB = setA->getRange("100.000.000.000", "110.000.000.000");

    //    cout << "The first five Ip addresses in the vector are: " << endl;

    //    for(unsigned int i = 0; i < 5; i++)
    //{
    //        cout << vectorB[i] << endl;
    //    }

    cout << "~~~~~~~~~~~~~~~~~~~~Part Six~~~~~~~~~~~~~~~~~~~~~~" << endl;

    MySet<string> setB;
    int count2 = 0;

    ifstream inFile2("IPListB.txt");
    if( !inFile2.is_open() )
    {
        cout << "Error opening file" << endl;
        return 1;
    }

    while(!inFile2.eof() && count2 < size)
    {
        inFile2 >> ipAddresses;
        setB.add(ipAddresses);
        count2++;
    }

    MySet<string> setAIB;
    //setAIB = setA.intersectionWith(setB);




    //delete(setA);

    delete(set2A);
    delete(set3A);

}
