//----------------------------------------------------------
// CS260 Assignment 3 Starter Code
// Copyright Andrew Scholer (ascholer@chemeketa.edu)
// Neither this code, nor any works derived from it
//    may not be republished without approval.
//----------------------------------------------------------

#ifndef STACK_H
#define STACK_H

#include <iostream>
using namespace std;

//Turn loops off for the duration of this file.
//You are to use recursion for any repetition.
//Make sure to do any other includes before these defines.
#define for DONOTUSETHIS
#define while DONOTUSETHIS
#define goto DONOTUSETHIS

/**
 * @brief List node for AddressLinkedList
 */
template <class T>
struct StackNode
{
    T data;
    StackNode* next;

    StackNode();
    StackNode(const T& value);
};


/**
 * @brief Stack based on a linked list
 */
template <class T>
class Stack
{
private:
    StackNode<T>* top;

public:
    /**
     * @brief Construct empty stack
     */
    Stack();

    /**
     * @brief Copy constructor
     *
     * Implement if you need it, otherwise not required
     * Declared to prevent default shallow copy
     */
    Stack(const Stack<T>& other);

    /**
     * @brief Assignment Operator
     *
     * Implement if you need it, otherwise not required
     * Declared to prevent default shallow copy
     */
    Stack<T>& operator=(const Stack<T>& other);

    /**
     * @brief Destructor
     */
    ~Stack();

    /**
     * @brief Check if stack is empty
     * @return true if nothing in stack, false otherwise
     */
    bool isEmpty() const;

    /**
     * @brief Add item to stack
     * @param value Item to push a copy of onto the stack
     */
    void push(const T& item);

    /**
     * @brief Remove and return top item from stack
     * @return Item that was at the top of the stack
     * Can throw exception/blow up with assertion if currently empty
     */
    T pop();

    /**
     * @brief Return a copy of the top item on the stack (without removing it)
     * @return Item that is at the top of the stack
     */
    T peek() const;

    /**
     * @brief Output the stack in order to cout
     */
    void print() const;

    /**
     * @brief Output the stack in reverse order to cout
     */
    void reversePrint() const;

    /**
     * @brief helper function for delete;
     */
    void recursiveDelete(StackNode<T>* current);

    /**
     * @brief helper function for print;
     */
    void recursiveReversePrint(StackNode<T>* current) const;

    /**
     * @brief helper function for print;
     */
    void recursivePrint(StackNode<T>* current) const;
};


//--------------------------------------------------------------------
// StackNode implementations
//--------------------------------------------------------------------

template <class T>
StackNode<T>::StackNode()
{
    next = nullptr;
    data = T(); //data will be default initialized
}

template <class T>
StackNode<T>::StackNode(const T& value)
    : data(value)
{
    next = nullptr;
}

template  <class T>
Stack<T>::Stack()
{
    top = nullptr;
}

template  <class T>
Stack<T>::Stack(const Stack<T>& other)
    :top(other){}


//--------------------------------------------------------------------
// Stack Implementations
//--------------------------------------------------------------------




template <class T>
void Stack<T>::recursiveDelete(StackNode<T>* current) { //probably doesnt help since ill have to push the data up. Might have to change this back to
    if (current == nullptr)
        return;
    recursiveDelete(current->next);
    delete(current);

}

template <class T>
Stack<T>::~Stack()
{
    recursiveDelete(top);
    top = nullptr;

}

template <class T>
bool Stack<T>::isEmpty() const
{
    if(top != nullptr)
        return false;
    else
        return true;
}

template <class T>
void Stack<T>::push(const T& item)
{
    StackNode<T>* temp = new StackNode<T>(item);
    temp->next = nullptr;

    if(top == nullptr)
    {
        top = temp;
    }
    else
    {
        temp->next = top;
        top = temp;
    }
}

template <class T>
T Stack<T>::pop()
{
    StackNode<T>* temp = new StackNode<T>;

    if(isEmpty())
    {
        throw "Pop doesnt work becase what youre trying to pop is empty!";
    }
    else
    {
        temp = top;
        top = top->next;
        return temp->data;
        delete temp;
    }
}

template <class T>
T Stack<T>::peek() const
{
    return top->data;
}

template<class T>
void Stack<T>::recursiveReversePrint(StackNode<T>* current) const
{
    if (current == nullptr)
        return;

    if(current != nullptr)
    {
        cout << current->data << endl;
        recursiveReversePrint(current->next);
    }
}

template<class T>
void Stack<T>::reversePrint() const
{
    recursiveReversePrint(top);
}

template<class T>
void Stack<T>::recursivePrint(StackNode<T>* current) const
{
    if (current == nullptr)
    {
        return;
    }

    Stack<T>* temp;

    string stack;

    temp->push(current->data);

    stack = temp->pop();
    recursivePrint(current->next);

    cout << stack << endl;

}

template<class T>
void Stack<T>::print() const
{
    recursivePrint(top);
}

//--------------------------------------------------------------------
// All your code before here
//--------------------------------------------------------------------
//Turn loops back on.
//Otherwise whatever file includes this will not be able to use them.
#undef for
#undef while
#undef goto

#endif // STACK_H
