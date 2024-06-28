#ifndef SINGLELIST_H
#define SINGLELIST_H

template <class T>
class SingleList {
   private:
    struct Node {
        T data;
        Node *next;
        Node(T data, Node* next) : data(data), next(next){}
    };
    Node *head;

   public:
    SingleList();
    SingleList(const SingleList &);
    SingleList(T);
    ~SingleList();
    void insert(T);
    void display();
    bool empty();
    T pop_back();
    T pop_front();
    bool operator==(const SingleList &) const;
    SingleList &operator=(const SingleList &);
};
#include "SingleList.cpp"
#endif