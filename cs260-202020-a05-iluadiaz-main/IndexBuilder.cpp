#include <iostream>

#include <sstream>
#include <cassert>
#include "IndexRecord.h"
#include "IndexMap.h"
#include <fstream>
#include <ctime>
using namespace std;

int main()
{
    IndexMap m;
    ifstream inFile("GreatExpectations.txt");
    string t;
    int page = 1;
    int wordNum = 1;

    if( !inFile.is_open() )
    {
        cout << "Error opening file" << endl;
        return 1;
    }
    clock_t start = clock();
    while(!inFile.eof())
    {
        inFile >> t;
                if(t[0] == '-')
                {
                    page++;
                    wordNum = 1;
                }

                if(t[0] != '-' )
                {
                    m.add(t,page,wordNum);
                    wordNum++;
                }
    }
    clock_t end = clock();

    cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Part 3~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
    cout << "Run performed in " << static_cast<double>(end - start) / CLOCKS_PER_SEC
         << " seconds" << endl;
    cout << "There are a total of "
         << m.numKeys() << " unique keys in this passage." << endl;

    IndexRecord record = m.get("fathers");
    cout << endl;
    cout << "The requested word: " << record << endl;

    cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Part 4~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
    cout << " The requested pair's informations is: ";
    m.findWordPairs("great", "expectations");

    cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Part 5~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
    cout <<"The first word on the requested page is: " << m.firstWordOnPage(100) << endl;
}
