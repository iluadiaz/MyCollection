//----------------------------------------------------------
// CS260 Assignment Starter Code
// Copyright Andrew Scholer (ascholer@chemeketa.edu)
// Neither this code, nor any works derived from it
//    may not be republished without approval.
//----------------------------------------------------------

#include "IndexMap.h"

using namespace std;

void IndexMap::grow()
{
    keyCount = 0;
    IndexRecord* tempBuckets = buckets;
    int oldNum = numBuckets;
    numBuckets = oldNum * 2 +1 ;
    buckets = new IndexRecord[numBuckets];

    for(int i = 0; i < oldNum; i++)
    {
        if(tempBuckets[i].word != "?")
        {
            for(unsigned int j = 0; j < tempBuckets[i].locations.size(); j++)
            {
                add(tempBuckets[i].word, tempBuckets[i].locations.at(j).pageNum, tempBuckets[i].locations.at(j).wordNum);
            }
        }
    }
    delete [] tempBuckets;
}

unsigned int IndexMap::getLocationFor(const std::string& key) const
{
    hash<string> hash;
    for (unsigned int i = hash(key) % numBuckets; i < numBuckets; i++)
    {
        if (buckets[i].word == key)
        {
            return i;
        }
    }
    return -1;
}

IndexMap::IndexMap(int startingBuckets)
{
    keyCount = 0;
    numBuckets = startingBuckets;
    buckets = new IndexRecord[startingBuckets];

    for(int i = 0; i < numBuckets; i++)
        buckets[i].word = "?";
}

IndexMap::~IndexMap()
{
    delete [] buckets;
}

IndexMap::IndexMap(const IndexMap &other)
{
    keyCount = other.keyCount;
    numBuckets = other.numBuckets;

    for(int i = 0; i < numBuckets; i++)
        buckets[i].word = other.buckets[i].word;
}

IndexMap& IndexMap::operator=(const IndexMap& other)
{
    if(this != &other)
        delete [] buckets;

    keyCount = 0;
    numBuckets = 0;

    buckets = other.buckets;
    keyCount = other.keyCount;
    numBuckets = other.numBuckets;

    return *this;
}

bool IndexMap::contains(const std::string& key) const
{
    if(key == "?")
        throw invalid_argument("Invalid key");

    hash<string> hasher;
    string temp = key;
    temp.at(0) = tolower(temp.at(0));
    for(int i = hasher(key) % numBuckets; i < numBuckets; i++)
    {
        if(buckets[i].word == temp)
        {
            return true;
        }
    }
    return false;
}

void IndexMap::add(const std::string& key, int pageNumber, int wordNumber)
{
    if(key == "?" || key == "#")
        throw invalid_argument("Invalid key");

    string word = key;
    word.at(0) = tolower(word.at(0));
    if(keyCount > numBuckets * 0.7)
    {
        grow();
    }

    hash<string> hasher;
    unsigned int hash = hasher(word) % numBuckets;
    if(this->contains(word))
    {
        IndexRecord temp = get(word);
        temp.addLocation(IndexLocation(pageNumber, wordNumber));
        unsigned int bucketNum = getLocationFor(word);
        buckets[bucketNum] = temp;
    }
    else
    {
        IndexRecord temp(word);
        temp.addLocation(IndexLocation(pageNumber, wordNumber));
        while(buckets[hash].word != "?")
        {
            hash++;
            hash = hash % numBuckets;
        }
        buckets[hash] = temp;
        keyCount++;
    }
}

int IndexMap::numKeys() const
{
    return keyCount;
}


void IndexMap::print() const
{
    for(int i = 0; i < numBuckets; i++)
    {
        IndexRecord temp(buckets[i]);

        if(buckets[i].word != "?")
        {
            cout << buckets[i] << endl;
        }
    }
}

IndexRecord IndexMap::get(const std::string& word) const
{
    int temp = 0;
    for(int i = 0; i < numBuckets; i++)
    {
        if(buckets[i].word == word)
            temp = i;
    }
    return buckets[temp];
}

void IndexMap::findWordPairs(const std::string& key1, const std::string& key2) const
{
    if(this->contains(key1) && this->contains(key2))
    {
        IndexRecord temp = get(key1);
        IndexRecord temp2 = get(key2);
        cout << "\"" << temp.word << " " << temp2.word << "\" : " << endl;

        for(int i = 0; i < temp.locations.size(); i++)
        {
            for(int j = 0; j < temp2.locations.size(); j++)
            {
                if(temp.locations.at(i).pageNum < temp2.locations.at(j).pageNum)
                {
                    continue;
                }
                if(temp.locations.at(i).pageNum == temp2.locations.at(j).pageNum &&
                   temp.locations.at(i).wordNum+1 == temp2.locations.at(j).wordNum)
                {
                    cout << temp.locations.at(i).pageNum << "-" << temp.locations.at(i).wordNum << " " << temp2.locations.at(j).pageNum << "-" <<
                            temp2.locations.at(j).wordNum << endl;
                }
            }
        }
    }
}

string IndexMap::firstWordOnPage(int pageNumber) const
{
    for(int i = 0; i < numBuckets; i++)
    {
        for(unsigned int j = 0; j < buckets[i].locations.size(); j++)
        {
            if(buckets[i].locations.at(j).pageNum == pageNumber && buckets[i].locations.at(j).wordNum == 1)
            {
                return buckets[i].word;
            }
        }
    }
    return "nothing :(";
}
