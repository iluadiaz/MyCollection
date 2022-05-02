//----------------------------------------------------------
// CS260 Assignment 3 Starter Code
// Copyright Andrew Scholer (ascholer@chemeketa.edu)
// Neither this code, nor any works derived from it
//    may not be republished without approval.
//----------------------------------------------------------

#include "DataStream.h"
#include <iostream>
#include <ctime>
#include <sstream>
#include <vector>
#include <queue>
#include "PriorityQueue.h"

using namespace std;

int main() {
    //Set up source of fake random packets. Seed with 0.
    DataStream d(0);

    //Read in a script in the form: "g 16000 r 16000 q";
    string jobScript;
    getline(cin, jobScript);

    //Use stringstream to parse the script
    stringstream scriptedInput(jobScript);

    PriorityQueue<Packet>* myHeap = new PriorityQueue<Packet>;
    clock_t start = clock();

    char jobType;
    scriptedInput >> jobType;
    while(jobType != 'q') {
        if(jobType == 'p') {
            //Print the highest priority packet. Do not remove it.
            Packet p = myHeap->getMax();
            cout << p.priority << " " << p.data << endl;
        }
        else {
            //Getting or removing packets
            int copies;
            scriptedInput >> copies;
            if(jobType == 'g') {
                for(int i = 0; i < copies; i++) {
                    //Get a packet
                    Packet p = d.getPacket();

                    myHeap->add(p);

                }
            }
            else if(jobType == 'r') {
                for(int i = 0; i < copies; i++) {
                    //Remove highest priority packet
                    myHeap->removeMax();
                }
            }
        }
        scriptedInput >> jobType;
    }
    clock_t end = clock();
    cout << "Run performed in " << static_cast<double>(end - start) / CLOCKS_PER_SEC
         << " seconds" << endl;

    delete(myHeap);
}
