//----------------------------------------------------------
// CS260 Assignment 2 Starter Code
// Copyright Andrew Scholer (ascholer@chemeketa.edu)
// Neither this code, nor any works derived from it
//    may not be republished without approval.
//----------------------------------------------------------

#include "AddressLinkedList.h"
#include <iostream>

using namespace std;


AddressListNode::AddressListNode() {
    next = nullptr;
    //data will be default initialized
}

AddressListNode::AddressListNode(const Address& value)
    : data(value)
{
    next = nullptr;
}


AddressLinkedList::AddressLinkedList()
{
    head = nullptr;
    tail = nullptr;
    length = 0;
}


AddressLinkedList& AddressLinkedList::operator=(const AddressLinkedList& other)
{
    //        AddressLinkedList temp(other);
    //        std::swap(temp.head, head);
    //        return *this;
    //~~~~~~~~~~~~~~Try above, if it use below~~~~~~~~~~~~~~~~~~~~
    //~~~~~~~~~~~~~~I think both worked. Did not want to run rest for both though~~~~~~~~~~
    if(this == &other)
    {
        return *this;
    }

    AddressListNode* current = other.head;
    while (current!= NULL)
    {
        insertEnd(current->data);
        current = current->next;
    }
    return *this;
}

AddressLinkedList::~AddressLinkedList()
{
    AddressListNode *current = head;

    while (current != NULL)
    {
        head = head -> next;
        delete current;
        current = head;
    }
}


void AddressLinkedList::print() const
{
    AddressListNode* current = head;

    while(current != nullptr) {
        cout << current->data << " ";
        current = current->next;
    }
    cout << endl;

    cout << "Length is: " << length << endl;
    if(tail)
        cout << "Tail points at: " <<  tail->data << endl;
    else
        cout << "Tail has a nullptr" << endl;

}

void AddressLinkedList::insertEnd(const Address &value)
{
    AddressListNode* temp = new AddressListNode(value);
    if(head == nullptr)
    {
        head = temp;
        tail = temp;
    }

    else
    {
        tail->next = temp;

        tail = temp;
    }
    length++;
}

int AddressLinkedList::listSize() const
{
    return this->length;
}

Address AddressLinkedList::retrieveAt(int location) const
{
    AddressListNode* current = head;
    for(int stepsLeft = location; stepsLeft > 0; stepsLeft--)
    {
        current = current->next;
    }

    return current->data;
}


void AddressLinkedList::printRange(int startIndex, int endIndex) const
{

    AddressListNode* temp = head;

    cout << "Your requested data for index " << startIndex << " to index: " << endIndex << " is: " << endl;
    cout << endl;

    for(int i = 0; i <= endIndex; i++)
    {
        if(i >= startIndex)
        {
            cout << temp->data << endl;
        }

        temp = temp->next;
    }
}

void AddressLinkedList::combine(AddressLinkedList &other)
{
    AddressListNode* current = other.head;

    for(int i = 0; i < other.length; i++)
    {
        insertEnd(current->data);
        current = current->next;
    }
    other.~AddressLinkedList();
    other.length = 0;
}

AddressLinkedList AddressLinkedList::extractAllMatches(const Address& itemToMatch)
{
    AddressListNode* current = head;
    AddressLinkedList temp;

    for(int i = 0; i < length; i++)
    {
        if(current->data.state == itemToMatch.state )
        {
            temp.insertEnd(current->data);
        }
        current = current->next;
    }
    return temp;
}

void AddressLinkedList::interleave(AddressLinkedList& other)
{
    for(int i = 0; i < other.length; i++)
    {
        head->next->data = other.head->data;
        other.head->data = other.head->next->data;
        head->next = head->next;
    }

    other.~AddressLinkedList();
    other.length = 0;
}





