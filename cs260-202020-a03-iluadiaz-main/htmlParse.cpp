//----------------------------------------------------------
// CS260 Assignment 3 Starter Code
// Copyright Andrew Scholer (ascholer@chemeketa.edu)
// Neither this code, nor any works derived from it
//    may not be republished without approval.
//----------------------------------------------------------

#include <iostream>
#include <fstream>
#include <cstring>
#include <algorithm>
#include <sstream>
#include <vector>


#include "Stack.h"

using namespace std;

int main()
{
    ifstream inFile("Document.html");
    if( !inFile.is_open() )
    {
        cout << "Error opening file" << endl;
        return 1;
    }

    string line;
    string holder;
    string startTag = "";
    string word = "";
    string endTag = "";
    string hasItEnded;

    Stack<string>* stack = new Stack<string>;

    int flag;
    string stackString, tempString;

    while(!inFile.eof())
    {
        inFile >> line;
        int length = line.length();

        if(line[0] != '<')//if its not a start Tag
        {
            flag = 2;
        }
        else if(line[0] == '<' && line[1] != '/' && line[length-1] == '>')//if it starts like a start tag check next index
        {
            flag = 1;

        }
        else if(line[1] == '/'&& line[length-1] == '>')//if the next character is /, its end tag
        {
            flag = 0;
        }


        if(flag == 1 )
        {
            startTag = line;
            stackString+= line;
        }

        if(flag == 0)
        {
            endTag = line;

            stackString.erase(stackString.length() - startTag.length(), stackString.length());
        }

        if(flag == 2)
        {
            word = line;
            tempString = stackString;
            stackString+=word;
            stack->push(stackString);
            stackString = tempString;
        }

        if(inFile.eof())
        {
            if(line != "</html>")
                throw "Did not end file properly!";
        }
    }
    cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ testing Print ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
    stack->print();
    cout << endl;
    cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ testing Reverse Print ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
    stack->reversePrint();

    delete(stack);
}

