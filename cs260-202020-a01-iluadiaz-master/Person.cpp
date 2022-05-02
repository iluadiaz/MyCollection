//----------------------------------------------------------
// CS260 Assignment 1 Starter Code
// Copyright Andrew Scholer (ascholer@chemeketa.edu)
// Neither this code, nor any works derived from it
//    may not be republished without approval.
//----------------------------------------------------------
#include "Person.h"
#include <iostream>

using namespace std;

bool operator==(const Person& p1, const Person& p2) {
    if(p1.kNum == p2.kNum)
        return true;
    else
        return false;
}

bool operator<(const Person& p1, const Person& p2) {
    if(p1.last < p2.last || (p1.last == p2.last && p1.first < p2.first))
        return true;
    else
        return false;
}

void partialZipSort(Person* array, int start, int end) {

    if(start<=end)
    {
        for (int i = 0; i <= end; i++)
        {
            int temp = i;
            for (int j = i + 1; j < end; j++)
            {
                if (array[j].zipCode < array[temp].zipCode && i >= 2 && i <= 7  && j >= 2 && j <= 7)
                {
                    temp = j;
                }
            }
            swap(array[i], array[temp]);
            cout << "Your partial sort has returned: "  << "\n" << array[i].last << ", " << array[i].first << ", " << array[i].zipCode << endl;
        }
    }
}

void nameSortHelper(Person* arr, int low, int mid, int size, Person* temp){

    int i, j, k;
    i = low;
    k = low;
    j = mid + 1;

    while (i <= mid && j <= size)
    {
        if (arr[i].last < arr[j].last || (arr[i].first < arr[j].first && arr[i].last == arr[j].last)) {
            temp[k] = arr[i];
            k++;
            i++;
        }
        else
        {
            temp[k] = arr[j];
            k++;
            j++;
        }
    }
    while (i <= mid)
    {
        temp[k] = arr[i];
        k++;
        i++;
    }
    while (j <= size)
    {
        temp[k] = arr[j];
        k++;
        j++;
    }
    for (i = low; i < k; i++)
    {
        arr[i] = temp[i];
    }
}

void nameSortHelperII(Person* arr[], int low, int high, Person* temp[]) {

    if (low >= high)
    {
        return;
    }

    int mid = (high + low) / 2;
    nameSortHelperII(arr, low, mid, temp);
    nameSortHelperII(arr, mid + 1, high, temp);

    nameSortHelper(*arr, low, mid, high, *temp);

}

void nameSort(Person* array, int size) {

    Person* temp = new Person[size];
    nameSortHelperII(&array, 0, size-1, &temp);

    for(int n = 0; n < 10; n++)
    {
        cout << temp[n].last << ", " << temp[n].first << endl;
    }

    delete [] temp;

}


int countLastName(const std::string& lastName, const Person* array, int size) {

    int count = 0;
    for(int i = 0; i < size; i++)
    {
        if(array[i].last == lastName)
            count++;
    }

    return count;
}

int firstHelper(const std::string& value, const Person* array, int start, int finish, int size){

    int mid = 0;

    if(start<=finish)
    {
        mid = (start+finish)/2;

        if((mid == 0 || value > array[mid-1].last) && array[mid].last == value )
            return mid;
        else if(value > array[mid].last)
            return firstHelper(value, array, mid+1, finish, size);
        else
            return firstHelper(value, array, start, mid-1, size);
    }

    return -1;
}


int lastHelper(const std::string& value, const Person* array, int start, int finish, int size){

    int mid = 0;

    if(start<=finish)
    {
        mid = (start+finish)/2;

        if((mid == size - 1 || value < array[mid+1].last) && array[mid].last == value )
            return mid;
        else if(value < array[mid].last)
            return lastHelper(value, array, start, mid -1, size);
        else
            return lastHelper(value, array, mid + 1, finish, size);
    }

    return -1;
}


int binaryFindFirstByLastName(const std::string& value, const Person* array, int size) {

    return firstHelper(value, array, 0, size, size);
}

int binaryFindLastByLastName(const std::string& value, const Person* array, int size) {

    return lastHelper(value, array, 0, size, size);
}

int countLastNameInSorted(std::string lastName, const Person* array, int size) {

    int count = binaryFindLastByLastName(lastName, array, size) - binaryFindFirstByLastName(lastName, array, size);
    if(count > 0)
        count = count + 1;

    return count;
}
