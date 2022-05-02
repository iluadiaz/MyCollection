//----------------------------------------------------------
// CS260 Assignment Starter Code
// Copyright Andrew Scholer (ascholer@chemeketa.edu)
// Neither this code, nor any works derived from it
//    may not be republished without approval.
//----------------------------------------------------------
#ifndef MYSET_H
#define MYSET_H

#include <iostream>
#include <vector>

//Node node for Set
template <class T>
struct SetNode
{
    T data;
    SetNode<T>* left;
    SetNode<T>* right;

    SetNode(const T& value);
};


//Set based on a BST
template <class T>
class MySet
{
private:
    SetNode<T>* root;

public:
    //Construct empty set
    MySet();

    //Copy constructor
    MySet(const MySet<T>& other);

    //Assignment operator - implement if needed
    MySet<T>& operator=(const MySet<T>& other);

    //Destructor
    ~MySet();

    //get number of items contained
    int size() const;

    //get depth of underlying tree
    int depth() const;

    //Add item to set
    //  Do not add duplicates of existing items - ignore any duplicate add
    void add(const T& item);

    //Check if item is in the set
    bool contains(const T& item) const;

    //Remove given item from the set if it exists
    void remove(const T& item);

    //returns the smallest item from the set (does not remove it)
    T getSmallest() const;

    //removes the largest item from the set and returns it
    T removeLargest();

    //Generates a new set containing all the items that are in either
    //  this set or another set
    //  intersections of {A, B, C, D} and {B, D, F} would be {A, B, C, D, F}
    //  Both original sets are left unmodified
    MySet<T> unionWith(const MySet<T>& other) const;

    //Generates a new set containing all the items that are in both
    //  this set and another set
    //  intersections of {A, B, C, D} and {B, D, F} would be {B, D}
    //  Both original sets are left unmodified
    MySet<T> intersectionWith(const MySet<T>& other) const;

    //Returns a vector of items in the set that are >= start and < end
    std::vector<T> getRange(const T& startValue, const T& endValue) const;

    //Helper for delete
    void recursiveDelete(SetNode<T>* other);

    //helper for remove
    SetNode<T> *removeHelper(SetNode<T> *other, const T& item);

    //helper for copy const
    SetNode<T> *copyHelper(SetNode<T> *other);

    //helper for add
    SetNode<T>* addHelper(SetNode<T>* node, const T& item);

    int sizeHelper(SetNode<T>* node) const;

    int depthHelper(SetNode<T>* node) const;

    T getSmallestHelper(SetNode<T>* node) const;

    T removeLargestHelper(SetNode<T> * node);

    T deleteNode(SetNode<T>* node);

    T getLargestHelper(SetNode<T>* node) const;

    T getLargest() const;

    bool containsHelper(SetNode<T>* node, const T& item);


};


//--------------------------------------------------------------------
// SetNode implementations
//--------------------------------------------------------------------

template <class T>
SetNode<T>::SetNode(const T& value)
    : data(value)
{
    left = nullptr;
    right = nullptr;
}


//--------------------------------------------------------------------
// Set Implementations
//--------------------------------------------------------------------

//Construct empty set
template <class T>
MySet<T>::MySet()
{
    root = nullptr;
}

template <class T>
SetNode<T>* MySet<T>::copyHelper(SetNode<T> *other)
{
    if(other == nullptr)
        return nullptr;

    SetNode<T>* copy = new SetNode<T>(other->data);

    if(other!= nullptr)
    {
        copy->left = copyHelper(other->left);
        copy->right = copyHelper(other->right);
    }
    return copy;
}

//Copy constructor
template <class T>
MySet<T>::MySet(const MySet<T>& other)
{

    root = copyHelper(other.root);
}

//Assignment operator - implement if needed
template <class T>
MySet<T>& MySet<T>::operator=(const MySet<T>& other)
{
    if(this != &other)
    {
        recursiveDelete(root);
        root = copyHelper(other.root);
    }
    return *this;

}

template <class T>
void MySet<T>::recursiveDelete(SetNode<T>* other) {
    if(other == nullptr)
        return;
    recursiveDelete(other->left);
    recursiveDelete(other->right);
    delete other;
}


//Destructor
template <class T>
MySet<T>::~MySet()
{
    recursiveDelete(root);
}

template <class T>
int MySet<T>::sizeHelper(SetNode<T>* node) const
{
    if(node == nullptr)
        return 0;
    else
        return 1 + sizeHelper(node->left) + sizeHelper(node->right);

}

//get number of items contained
template <class T>
int MySet<T>::size() const
{

    return sizeHelper(root);

}

template <class T>
int MySet<T>::depthHelper(SetNode<T>* node) const
{
    int leftHeight, rightHeight;
    if (node != nullptr)
    {
        leftHeight = depthHelper(node->left);

        rightHeight = depthHelper(node->right);

        if (leftHeight > rightHeight)

            return leftHeight + 1;
        else
            return rightHeight + 1;
    }

    else
        return -1;
}



//get depth of underlying tree
template <class T>
int MySet<T>::depth() const
{
    return depthHelper(root);
}

template <class T>
SetNode<T>* MySet<T>::addHelper(SetNode<T>* node, const T& item) {
    if(node == nullptr)
    {
        return new SetNode<T>(item);
    }

    if(item == node->data)
    {
        return node;
    }

    if(item < node->data)
        node->left = addHelper(node->left, item);
    else
        node->right = addHelper(node->right, item);

    return node;
}

//Add item to set
//  Do not add duplicates of existing items - ignore any duplicate add
template <class T>
void MySet<T>::add(const T& item)//can use insertAt from cpp lab!
{
    root = addHelper(root, item);

}

template <class T>
bool MySet<T>::containsHelper(SetNode<T>* node, const T& item)
{
    if(node == nullptr)
    {
        return false;
    }
    if(node->data == item)
    {
        return true;
    }
    if(item < node->data)
        return containsHelper(node->left, item);
    else
        return containsHelper(node->right, item);
}

//Check if item is in the set
template <class T>
bool MySet<T>::contains(const T& item) const
{
    return containsHelper(root, item);
}

template <class T>
SetNode<T>* MySet<T>::removeHelper(SetNode<T>* other, const T& item)
{
    if(other == nullptr) {
        return nullptr;
    }
    if(item < other->data) {
        other->left = removeHelper(other->left, item);
    }
    else if(other->data < item) {
        other->right = removeHelper(other->right, item);

    }
    else {

        if(other->left == NULL)
        {
            SetNode<T>* temp = other->right;
            delete(other);
            return temp;
        }

        if(other->right == NULL)
        {
            SetNode<T>* temp = other->left;
            delete(other);
            return temp;
        }
        else
        {
            other->data = getSmallestHelper(other->right);
            other->right = removeHelper(other->right, other->data);
        }
    }
    return other;
}


//Remove given item from the set if it exists
template<class T>
void MySet<T>::remove(const T& item)
{
    root = removeHelper(root, item);
}

template <class T>
T MySet<T>::getSmallestHelper(SetNode<T>* node) const
{
    if (node->left == NULL)
        return node->data;
    return getSmallestHelper(node->left);
}

//returns the smallest item from the set (does not remove it)
template <class T>
T MySet<T>::getSmallest() const
{

    return getSmallestHelper(root);

}

template <class T>
T MySet<T>::getLargest() const
{
    return getLargestHelper(root);
}


template<class T>
T MySet<T>::getLargestHelper(SetNode<T>* node) const
{
    if (node->right == NULL)
        return node->data;

    return getLargestHelper(node->right);

}

template <class T>
T MySet<T>::removeLargestHelper(SetNode<T>* node)
{
    if(node == NULL)
        return NULL;

    return removeHelper(node, getLargestHelper(node))->data;

}

//removes the largest item from the set and returns it
template <class T>
T MySet<T>::removeLargest()
{
    return removeLargestHelper(root);
}

//Generates a new set containing all the items that are in either
//  this set or another set
//  intersections of {A, B, C, D} and {B, D, F} would be {A, B, C, D, F}
//  Both original sets are left unmodified
template <class T>
MySet<T> MySet<T>::unionWith(const MySet<T>& other) const
{

}

//Generates a new set containing all the items that are in both
//  this set and another set
//  intersections of {A, B, C, D} and {B, D, F} would be {B, D}
//  Both original sets are left unmodified
template <class T>
MySet<T> MySet<T>::intersectionWith(const MySet<T>& other) const
{

    MySet<T> set;
    while(root != NULL)
    {
    if(root->data == other.root.data)
    {
        set->add(root);
    }
    root = root->right;
    }

    return set;
}

//Returns a vector of items in the set that are >= start and < end
template <class T>
std::vector<T> MySet<T>::getRange(const T& startValue, const T& endValue) const
{

    std::vector<T> vectorA;

    SetNode<T>* node = new SetNode<T>(root->data);

    while(node != NULL)
    {
        if(node->data >= startValue && node->data < endValue)
        {
            vectorA.push_back(node->data);
        }
        if(node->data > endValue)
        {
            node = node->left;
        }
        if(node->data < startValue)
        {

            node = node->right;
        }

    }

    return vectorA;
}


#endif // MYSET_H
