//----------------------------------------------------------
// CS260 Assignment 3 Starter Code
// Copyright Andrew Scholer (ascholer@chemeketa.edu)
// Neither this code, nor any works derived from it
//    may not be republished without approval.
//----------------------------------------------------------

#ifndef PRIORITYQUEUE_H
#define PRIORITYQUEUE_H

#include <iostream>
#include "DataStream.h"

template<typename T>
class PriorityQueue
{
private:
    T* data;        //array containing the heap
    int capacity;   //maximum size
    int queueSize;   //current logical size

    //Double the size of the underlying array
    void grow();

public:
    //Get a copy of the top item
    T getMax();

    //Rmove the top item and return it
    T removeMax();

    //Add the given value to the heap
    void add(const T& value);

    //Construct a max heap with initial space for 32 items
    PriorityQueue();

    //Destroy the max heap and release memory
    ~PriorityQueue();

    //You do not need to implement copy ctor and assignment operator
    // Declared to prevent accidental use of defaults
    PriorityQueue(const PriorityQueue& other);
    PriorityQueue& operator=(const PriorityQueue& other);
};
template<typename T>
T PriorityQueue<T>::getMax()
{
    if(queueSize == 0)
        throw std::logic_error("getMax in empty heap");

    return data[0];
}

template<typename T>
T PriorityQueue<T>::removeMax()
{
    if(queueSize == 0)
        throw std::logic_error("removeTop in empty heap");


    int currentIndex = 0;
    T max = data[0];
    data[0] = data[queueSize-1];
    queueSize--;

    while (currentIndex < queueSize)
    {
        int left = 2 * currentIndex + 1;
        int right = 2 * currentIndex + 2;

        if (left >= queueSize) break;

        int maxIndex = left;

        if(right < queueSize)
        {
            if(data[maxIndex] < data[right])
            {
                maxIndex = right;
            }
        }

        if(data[currentIndex] < data[maxIndex])
        {
            T temp = data[maxIndex];
            data[maxIndex] = data[currentIndex];
            data[currentIndex] = temp;
            currentIndex = maxIndex;
        }
        else
            break;
    }
    return max;
}

template<typename T>
void PriorityQueue<T>::add(const T& value)
{
    if(queueSize == capacity)
        grow();

    int currentIndex = queueSize;
    data[queueSize] = value;
    while (currentIndex > 0)
    {
        int parentIndex = (currentIndex - 1) / 2;
        if (data[currentIndex] > data[parentIndex])
        {
            T temp = data[currentIndex];
            data[currentIndex] = data[parentIndex];
            data[parentIndex] = temp;
        }
        else
            break;

        currentIndex = parentIndex;
    }
    queueSize++;
}

template<typename T>
PriorityQueue<T>::PriorityQueue()
{
    queueSize = 0;
    capacity = 32;
    data = new T[capacity];
}

template<typename T>
PriorityQueue<T>::~PriorityQueue()
{
    delete [] data;
}

template<typename T>
void PriorityQueue<T>::grow()
{
    T* temp = data;
    capacity *= 2;
    data = new T[capacity * 2];
    for(int i = 0; i < queueSize; i++)
        data[i] = temp[i];

    delete [] temp;
}
#endif // PRIORITYQUEUE_H
